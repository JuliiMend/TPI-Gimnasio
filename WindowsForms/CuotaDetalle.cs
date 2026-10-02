using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CuotaDetalle : Form
    {
        private CuotaCreaActualizaDTO cuota;
        private List<DetalleCuotaCreaActualizaDTO> itemsLocales;

        public CuotaDetalle(CuotaCreaActualizaDTO cuota)
        {
            InitializeComponent();
            this.cuota = cuota;
        }

        private async void CuotaDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadSocios();
                SetCuota();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al inicializar ventana: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadSocios()
        {
            var socios = await SocioApiClient.GetAllAsync();

            cmb_socios.DisplayMember = "Nombre";
            cmb_socios.ValueMember = "IdPersona";
            cmb_socios.DataSource = socios.ToList();
            cmb_socios.SelectedIndex = -1;
        }

        private void SetCuota()
        {
            if (this.cuota.CuotaId > 0)
            {
                cmb_socios.SelectedValue = this.cuota.SocioId;

                string periodo = this.cuota.MesAnio.ToString();

                if (periodo.Length >= 4)
                {
                    int anio = int.Parse(periodo.Substring(0, 4));
                    int mes = periodo.Length == 6
                        ? int.Parse(periodo.Substring(4, 2))
                        : 1;

                    dtp_mesAnio.Value = new DateTime(anio, mes, 1);
                }

                if (this.cuota.FechaPago != DateTime.MinValue)
                {
                    dtp_fechaPago.Value = this.cuota.FechaPago;
                }

                itemsLocales = this.cuota.Detalles != null
                    ? this.cuota.Detalles.ToList()
                    : new List<DetalleCuotaCreaActualizaDTO>();
            }
            else
            {
                itemsLocales = new List<DetalleCuotaCreaActualizaDTO>();
                dtp_fechaPago.Value = DateTime.Today;
            }

            RefreshItemsGrid();
        }

        private void btn_agregar_item_Click(object sender, EventArgs e)
        {
            DetalleCuotaCreaActualizaDTO nuevoItem =
                new DetalleCuotaCreaActualizaDTO();

            ItemCuotaDetalle itemDetalle =
                new ItemCuotaDetalle(nuevoItem);

            if (itemDetalle.ShowDialog() == DialogResult.OK)
            {
                itemsLocales.Add(itemDetalle.Item);
                RefreshItemsGrid();
            }
        }

        private void btn_modificarItem_Click(object sender, EventArgs e)
        {
            if (dtg_detalle.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccioná un ítem de la lista para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DetalleCuotaCreaActualizaDTO selectedItem =
                (DetalleCuotaCreaActualizaDTO)
                dtg_detalle.SelectedRows[0].DataBoundItem;

            ItemCuotaDetalle itemDetalle =
                new ItemCuotaDetalle(selectedItem);

            if (itemDetalle.ShowDialog() == DialogResult.OK)
            {
                RefreshItemsGrid();
            }
        }

        private void btn_eliminarItem_Click(object sender, EventArgs e)
        {
            if (dtg_detalle.SelectedRows.Count > 0)
            {
                DetalleCuotaCreaActualizaDTO selectedItem =
                    (DetalleCuotaCreaActualizaDTO)
                    dtg_detalle.SelectedRows[0].DataBoundItem;

                itemsLocales.Remove(selectedItem);

                RefreshItemsGrid();
            }
        }

        private void RefreshItemsGrid()
        {
            dtg_detalle.DataSource = null;
            dtg_detalle.DataSource = itemsLocales;

            decimal total = itemsLocales.Sum(i => i.Monto);

            lbl_total.Text = $"Total: ${total:F2}";
        }

        private async void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (cmb_socios.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un socio.");
                return;
            }

            if (itemsLocales.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un detalle a la cuota.");

                return;
            }

            try
            {
                this.cuota.SocioId =
                    (int)cmb_socios.SelectedValue;

                this.cuota.MesAnio =
                    int.Parse(dtp_mesAnio.Value.ToString("yyyyMM"));

                this.cuota.FechaPago =
                    dtp_fechaPago.Value;

                this.cuota.Detalles =
                    itemsLocales;

                btn_aceptar.Enabled = false;

                if (this.cuota.CuotaId > 0)
                {
                    await CuotaApiClient.UpdateAsync(this.cuota);
                }
                else
                {
                    await CuotaApiClient.AddAsync(this.cuota);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar cuota: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btn_aceptar.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}