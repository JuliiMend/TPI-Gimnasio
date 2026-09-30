using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp 
{
    public partial class ItemCuotaDetalle : Form
    {
        private DetalleCuotaCreaActualizaDTO item;

        public DetalleCuotaCreaActualizaDTO Item
        {
            get { return item; }
            set
            {
                item = value;
                this.SetItem();
            }
        }

        public ItemCuotaDetalle()
        {
            InitializeComponent();
        }

        public ItemCuotaDetalle(DetalleCuotaCreaActualizaDTO item) : this()
        {
            this.Item = item;
        }

        private void SetItem()
        {
            if (this.Item != null)
            {
                txt_concepto.Text = this.Item.Concepto;

                if (this.Item.Monto > 0)
                {
                    txt_monto.Text = this.Item.Monto.ToString();
                }
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_concepto.Text) || string.IsNullOrWhiteSpace(txt_monto.Text))
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            this.Item.Concepto = txt_concepto.Text;
            this.Item.Monto = decimal.Parse(txt_monto.Text);
            this.Item.Subtotal = this.Item.Monto;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}