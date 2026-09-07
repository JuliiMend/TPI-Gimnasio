using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TurnoLista : Form
    {
        private readonly ITurnoService _turnoService;

        public TurnoLista(ITurnoService turnoService)
        {
            InitializeComponent();
            _turnoService = turnoService;
        }

        private async void TurnoLista_Load(object sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private async System.Threading.Tasks.Task CargarTurnosAsync()
        {
            try
            {
                var turnos = await _turnoService.ObtenerTodosAsync();

                dgvTurnos.DataSource = turnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los turnos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var turnoDetalleForm = Program.ServiceProvider.GetRequiredService<TurnoDetalle>();

            if (turnoDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarTurnosAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un turno para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var turnoId = (int)dgvTurnos.CurrentRow.Cells["colId"].Value;

            var turnoDetalleForm = Program.ServiceProvider.GetRequiredService<TurnoDetalle>();

            await turnoDetalleForm.CargarTurnoAsync(turnoId);

            if (turnoDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarTurnosAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un turno para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var turnoId = (int)dgvTurnos.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás segura de que querés eliminar este turno?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await _turnoService.EliminarAsync(turnoId);

                MessageBox.Show(
                    "Turno eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CargarTurnosAsync();
            }
        }
    }
}