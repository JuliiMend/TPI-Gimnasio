using API.Clients; 
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class AdministradorLista : Form
    {
        public AdministradorLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void AdministradorLista_Load(object sender, EventArgs e)
        {
            await CargarAdministradoresAsync();
        }

        private async Task CargarAdministradoresAsync()
        {
            try
            {
                var administradores = await AdministradorApiClient.GetAllAsync();

                dgvAdministradores.DataSource = null; 
                dgvAdministradores.DataSource = administradores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los administradores: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var administradorDetalleForm = new AdministradorDetalle();

            if (administradorDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarAdministradoresAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAdministradores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un administrador para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var administradorId = (int)dgvAdministradores.CurrentRow.Cells["colId"].Value;

            var administradorDetalleForm = new AdministradorDetalle();

            await administradorDetalleForm.CargarAdministradorAsync(administradorId);

            if (administradorDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarAdministradoresAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAdministradores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un administrador para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var administradorId = (int)dgvAdministradores.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este administrador?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await AdministradorApiClient.DeleteAsync(administradorId);

                    MessageBox.Show(
                        "Administrador eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarAdministradoresAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el administrador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
