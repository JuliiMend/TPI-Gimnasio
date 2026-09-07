using Application.Services;
using DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class SocioLista : Form
    {
        private readonly ISocioService _socioService;

        public SocioLista(ISocioService socioService)
        {
            InitializeComponent();
            _socioService = socioService;

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
                var socios = await _socioService.ObtenerTodosAsync(new SocioCriteriaDTO());

                dgvSocios.DataSource = null;
                dgvSocios.DataSource = socios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnNuevo_Click(object? sender, EventArgs e)
        {
            var socioDetalleForm = Program.ServiceProvider.GetRequiredService<SocioDetalle>();

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

            var socioDetalleForm = Program.ServiceProvider.GetRequiredService<SocioDetalle>();

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
                    await _socioService.EliminarAsync(socioSeleccionado.IdPersona);
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