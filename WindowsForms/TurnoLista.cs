using API.Clients; 
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TurnoLista : Form
    {
        public TurnoLista()
        {
            InitializeComponent();
        }

        private async void TurnoLista_Load(object sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private async Task CargarTurnosAsync()
        {
            try
            {
                var turnos = await TurnoApiClient.GetAllAsync();

                dgvTurnos.DataSource = null; 
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
            var turnoDetalleForm = new TurnoDetalle();

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

            var turnoDetalleForm = new TurnoDetalle();

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
                "¿Estás seguro de que querés eliminar este turno?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await TurnoApiClient.DeleteAsync(turnoId);

                    MessageBox.Show(
                        "Turno eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarTurnosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar el turno: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}