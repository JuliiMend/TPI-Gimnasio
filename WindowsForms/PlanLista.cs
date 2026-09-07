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
    }
}