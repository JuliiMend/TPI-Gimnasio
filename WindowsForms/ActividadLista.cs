using API.Clients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ActividadLista : Form
    {
        public ActividadLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void ActividadLista_Load(object sender, EventArgs e)
        {
            await CargarActividadesAsync();
        }

        private async Task CargarActividadesAsync()
        {
            try
            {
                var actividades = await ActividadApiClient.GetAllAsync();

                dgvActividades.DataSource = null;
                dgvActividades.DataSource = actividades;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las actividades: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var actividadDetalleForm = new ActividadDetalle();

            if (actividadDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarActividadesAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una actividad para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var actividadId = (int)dgvActividades.CurrentRow.Cells["colId"].Value;

            var actividadDetalleForm = new ActividadDetalle();

            await actividadDetalleForm.CargarActividadAsync(actividadId);

            if (actividadDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarActividadesAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una actividad para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var actividadId = (int)dgvActividades.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar esta actividad?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await ActividadApiClient.DeleteAsync(actividadId);

                    MessageBox.Show(
                        "Actividad eliminada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarActividadesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar la actividad: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
