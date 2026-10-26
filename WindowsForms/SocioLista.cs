using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class SocioLista : Form
    {
        // DNI aplicado con "Buscar"; vacío = todos los socios
        private string dniFiltro = string.Empty;

        public SocioLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;

            this.Load -= SocioLista_Load;
            this.Load += SocioLista_Load;

            btnNuevo.Click -= btnNuevo_Click;
            btnNuevo.Click += btnNuevo_Click;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private async void SocioLista_Load(object? sender, EventArgs e)
        {
            await CargarSociosAsync();
        }

        private async Task CargarSociosAsync()
        {
            try
            {
                var pagina = await SocioApiClient.GetPaginadoAsync(paginador.NumeroPagina, paginador.TamanioPagina, dniFiltro);

                dgvSocios.DataSource = null;
                dgvSocios.DataSource = pagina.Items;
                paginador.Actualizar(pagina);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BuscarAsync()
        {
            dniFiltro = txtDni.Text.Trim();
            paginador.Reiniciar();
            await CargarSociosAsync();

            if (dgvSocios.DataSource is List<SocioMostrarDTO> { Count: 0 } && !string.IsNullOrEmpty(dniFiltro))
            {
                MessageBox.Show($"No se encontró ningún socio con DNI \"{dniFiltro}\".", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnBuscar_Click(object? sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void txtDni_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await BuscarAsync();
            }
        }

        private async void btnVerTodos_Click(object? sender, EventArgs e)
        {
            txtDni.Clear();
            await BuscarAsync();
        }

        private async void paginador_PaginaCambiada(object? sender, EventArgs e)
        {
            await CargarSociosAsync();
        }

        private async void btnNuevo_Click(object? sender, EventArgs e)
        {
            var socioDetalleForm = new SocioDetalle();

            if (socioDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarSociosAsync();
            }
        }

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un socio para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var socioSeleccionado = (SocioMostrarDTO)dgvSocios.CurrentRow.DataBoundItem;

            var socioDetalleForm = new SocioDetalle();

            await socioDetalleForm.CargarSocioAsync(socioSeleccionado.IdPersona);

            if (socioDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarSociosAsync();
            }
        }

        private async void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un socio para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var socioSeleccionado = (SocioMostrarDTO)dgvSocios.CurrentRow.DataBoundItem;

            var respuesta = MessageBox.Show($"¿Estás seguro de que querés eliminar al socio {socioSeleccionado.Nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await SocioApiClient.DeleteAsync(socioSeleccionado.IdPersona);

                    MessageBox.Show("Socio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarSociosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}