using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ProfesorLista : Form
    {
        private readonly IProfesorService _profesorService;

        public ProfesorLista(IProfesorService profesorService)
        {
            InitializeComponent();
            _profesorService = profesorService;
        }

        private async void ProfesorLista_Load(object sender, EventArgs e)
        {
            await CargarProfesoresAsync();
        }

        private async Task CargarProfesoresAsync()
        {
            try
            {
                var profesores = await _profesorService.ObtenerTodosAsync();

                dgvProfesores.DataSource = profesores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los profesores: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var profesorDetalleForm =
                Program.ServiceProvider.GetRequiredService<ProfesorDetalle>();

            if (profesorDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarProfesoresAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un profesor para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var profesorId =
                (int)dgvProfesores.CurrentRow.Cells["colId"].Value;

            var profesorDetalleForm =
                Program.ServiceProvider.GetRequiredService<ProfesorDetalle>();

            await profesorDetalleForm.CargarProfesorAsync(profesorId);

            if (profesorDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarProfesoresAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un profesor para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var profesorId =
                (int)dgvProfesores.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás segura de que querés eliminar este profesor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await _profesorService.EliminarAsync(profesorId);

                MessageBox.Show(
                    "Profesor eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CargarProfesoresAsync();
            }
        }
    }
}
