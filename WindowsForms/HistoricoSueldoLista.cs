using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class HistoricoSueldoLista : Form
    {
        public HistoricoSueldoLista()
        {
            InitializeComponent();
            colValor.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
        }

        private async void HistoricoSueldoLista_Load(object sender, EventArgs e)
        {
            if (!await AuthServiceProvider.Instance.HasPermissionAsync(Roles.Admin))
            {
                Text = lblTitulo.Text = "Mi histórico de sueldos";
                btnRegistrar.Visible = lblProfesor.Visible = cmbFiltroProfesor.Visible = false;

                await CargarSueldosAsync();
                return;
            }

            try
            {
                var profesores = await ProfesorApiClient.GetAllAsync();

                var opciones = new List<object> { new { Id = 0, Texto = "Todos los profesores" } };
                opciones.AddRange(profesores.Select(p => new { Id = p.IdPersona, Texto = $"{p.Nombre} {p.Apellido}" }));

                cmbFiltroProfesor.DisplayMember = "Texto";
                cmbFiltroProfesor.ValueMember = "Id";
                cmbFiltroProfesor.DataSource = opciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los profesores: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            await CargarSueldosAsync();
        }

        private int? IdProfesorFiltro()
        {
            return cmbFiltroProfesor.SelectedValue is int id && id > 0 ? id : null;
        }

        private async Task CargarSueldosAsync()
        {
            try
            {
                var sueldos = await HistoricoSueldoApiClient.GetAllAsync(IdProfesorFiltro());

                dgvSueldos.DataSource = null;
                dgvSueldos.DataSource = sueldos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el histórico de sueldos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void cmbFiltroProfesor_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            await CargarSueldosAsync();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            var detalleForm = new HistoricoSueldoDetalle(IdProfesorFiltro());

            if (detalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarSueldosAsync();
            }
        }
    }
}
