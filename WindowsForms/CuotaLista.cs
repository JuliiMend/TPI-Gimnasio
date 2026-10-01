using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CuotaLista : Form
    {
        public CuotaLista()
        {
            InitializeComponent();
        }

        private async void CuotaLista_Load(object sender, EventArgs e)
        {
            await this.LoadCuotas();
        }

        private async Task LoadCuotas()
        {
            try
            {
                btn_agregar.Enabled = false;
                btn_actualizar.Enabled = false;
                btn_eliminar.Enabled = false;

                this.dgv_cuotas.DataSource = null;

                IEnumerable<CuotaMostrarDTO> cuotas = await CuotaApiClient.GetAllAsync();
                this.dgv_cuotas.DataSource = cuotas;

                btn_agregar.Enabled = true;
                if (this.dgv_cuotas.Rows.Count > 0)
                {
                    this.dgv_cuotas.Rows[0].Selected = true;
                    btn_actualizar.Enabled = true;
                    btn_eliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_agregar_Click(object sender, EventArgs e)
        {
            CuotaCreaActualizaDTO cuotaNueva = new CuotaCreaActualizaDTO();
            cuotaNueva.Detalles = new List<DetalleCuotaCreaActualizaDTO>();

            CuotaDetalle cuotaDetalle = new CuotaDetalle(cuotaNueva);
            cuotaDetalle.ShowDialog();

            await this.LoadCuotas();
        }

        private async void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_cuotas.SelectedRows.Count == 0) return;

                CuotaMostrarDTO seleccionada = (CuotaMostrarDTO)dgv_cuotas.SelectedRows[0].DataBoundItem;

                CuotaCreaActualizaDTO cuota = await CuotaApiClient.GetAsync(seleccionada.CuotaId);

                CuotaDetalle cuotaDetalle = new CuotaDetalle(cuota);
                cuotaDetalle.ShowDialog();

                await this.LoadCuotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuota para actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_cuotas.SelectedRows.Count == 0) return;

            CuotaMostrarDTO seleccionada = (CuotaMostrarDTO)dgv_cuotas.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la cuota #{seleccionada.CuotaId}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await CuotaApiClient.DeleteAsync(seleccionada.CuotaId);
                    await this.LoadCuotas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cuota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}