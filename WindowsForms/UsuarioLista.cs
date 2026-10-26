using API.Clients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UsuarioLista : Form
    {
        public UsuarioLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void UsuarioLista_Load(object sender, EventArgs e)
        {
            await CargarUsuariosAsync();
        }

        private async Task CargarUsuariosAsync()
        {
            try
            {
                var pagina = await UsuarioApiClient.GetPaginadoAsync(paginador.NumeroPagina, paginador.TamanioPagina);

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = pagina.Items;
                paginador.Actualizar(pagina);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las usuarios: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void paginador_PaginaCambiada(object? sender, EventArgs e)
        {
            await CargarUsuariosAsync();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var usuarioDetalleForm = new UsuarioDetalle();

            if (usuarioDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarUsuariosAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un usuario para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var usuarioId = (int)dgvUsuarios.CurrentRow.Cells["colId"].Value;

            var usuarioDetalleForm = new UsuarioDetalle();

            await usuarioDetalleForm.CargarUsuarioAsync(usuarioId);

            if (usuarioDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un usuario para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var usuarioId = (int)dgvUsuarios.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await UsuarioApiClient.DeleteAsync(usuarioId);

                    MessageBox.Show(
                        "Usuario eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarUsuariosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar el usuario: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
