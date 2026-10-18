using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ClaseLista : Form
    {
        public ClaseLista()
        {
            InitializeComponent();
        }

        private async void ClaseLista_Load(object sender, EventArgs e)
        {
            // Profesor (solo sus clases, lo filtra la API) y Socio: solo consulta
            var authService = AuthServiceProvider.Instance;

            if (!await authService.HasPermissionAsync(Roles.Admin))
            {
                btnNuevo.Visible = btnModificar.Visible = btnEliminar.Visible = lblOpciones.Visible = false;

                if (await authService.HasPermissionAsync(Roles.Profesor))
                {
                    Text = lblTitulo.Text = "Mis clases";
                }
            }

            await CargarClasesAsync();
        }

        private async Task CargarClasesAsync()
        {
            try
            {
                var clases = await ClaseApiClient.GetAllAsync();

                dgvClases.DataSource = null;
                dgvClases.DataSource = clases;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las clases: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var claseDetalleForm = new ClaseDetalle();

            if (claseDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarClasesAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una clase para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var claseId = (int)dgvClases.CurrentRow.Cells["colId"].Value;

            var claseDetalleForm = new ClaseDetalle();

            await claseDetalleForm.CargarClaseAsync(claseId);

            if (claseDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarClasesAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una clase para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var claseId = (int)dgvClases.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar esta clase?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await ClaseApiClient.DeleteAsync(claseId);

                    MessageBox.Show(
                        "Clase eliminada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarClasesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar la clase: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
