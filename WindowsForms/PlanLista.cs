using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsFormsApp
{
    public partial class PlanLista : Form
    {
        private readonly IPlanService _planService;

        // Inyectamos el servicio de planes automáticamente
        public PlanLista(IPlanService planService)
        {
            InitializeComponent();
            _planService = planService;
        }

        private async void PlanListaForm_Load(object sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }

        private async System.Threading.Tasks.Task CargarPlanesAsync()
        {
            try
            {
                // Pedimos la lista de planes a la capa de servicios
                var planes = await _planService.ObtenerTodosAsync();

                // Volcamos los datos directamente en la grilla
                dgvPlanes.DataSource = planes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acá abriremos el formulario de creación de plan.", "Info");
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            // Pedimos el formulario de detalle al contenedor
            var planDetalleForm = Program.ServiceProvider.GetRequiredService<PlanDetalle>();

            // Si se guarda correctamente, refrescamos la grilla
            if (planDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarPlanesAsync();
            }
        }

        private void PlanListaForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}