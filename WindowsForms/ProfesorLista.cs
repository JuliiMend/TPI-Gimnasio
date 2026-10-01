using API.Clients; 
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ProfesorLista : Form
    {
        public ProfesorLista()
        {
            InitializeComponent();
        }

        private async void ProfesorLista_Load(object sender, EventArgs e)
        {
            await CargarProfesoresAsync();
        }

        private async Task CargarProfesoresAsync()
        {
            try
            {
                var profesores = await ProfesorApiClient.GetAllAsync();

                dgvProfesores.DataSource = null; 
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
            var profesorDetalleForm = new ProfesorDetalle();

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

            var profesorId = (int)dgvProfesores.CurrentRow.Cells["colId"].Value;

            var profesorDetalleForm = new ProfesorDetalle();

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

            var profesorId = (int)dgvProfesores.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este profesor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await ProfesorApiClient.DeleteAsync(profesorId);

                    MessageBox.Show(
                        "Profesor eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarProfesoresAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}