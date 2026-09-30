using Application.Services;
using DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PlanLista : Form
    {
        private readonly IPlanService _planService;

        public PlanLista(IPlanService planService)
        {
            InitializeComponent();
            _planService = planService;

            this.Load -= PlanLista_Load;
            this.Load += PlanLista_Load;

            btnNuevo.Click -= btnNuevo_Click;
            btnNuevo.Click += btnNuevo_Click;

            btnActualizar.Click -= btnActualizar_Click;
            btnActualizar.Click += btnActualizar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private async void PlanLista_Load(object? sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }

        private async Task CargarPlanesAsync()
        {
            try
            {
                var planes = await _planService.ObtenerTodosAsync();

                dgvPlanes.DataSource = null;
                dgvPlanes.DataSource = planes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevo_Click(object? sender, EventArgs e)
        {
            var planDetalleForm = Program.ServiceProvider.GetRequiredService<PlanDetalle>();

            planDetalleForm.PlanId = null;

            if (planDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarPlanesAsync();
            }
        }

        private async void btnActualizar_Click(object? sender, EventArgs e)
        {
            if (dgvPlanes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un plan para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var planSeleccionado = (PlanDTO)dgvPlanes.CurrentRow.DataBoundItem;

            var planDetalleForm = Program.ServiceProvider.GetRequiredService<PlanDetalle>();

            planDetalleForm.PlanId = planSeleccionado.IdPlan;

            if (planDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarPlanesAsync();
            }
        }

        private async void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvPlanes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un plan para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var planSeleccionado = (PlanDTO)dgvPlanes.CurrentRow.DataBoundItem;

            var respuesta = MessageBox.Show($"¿Estás seguro de que querés eliminar el plan '{planSeleccionado.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await _planService.EliminarAsync(planSeleccionado.IdPlan);
                    MessageBox.Show("Plan eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarPlanesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el plan: {ex.Message}\n\nAsegurate de que no haya socios usando este plan antes de borrarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}