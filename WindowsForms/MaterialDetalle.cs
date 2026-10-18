using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MaterialDetalle : Form
    {
        private int? _idMaterial;

        public MaterialDetalle()
        {
            InitializeComponent();
        }

        public async Task CargarMaterialAsync(int id)
        {
            var material = await MaterialApiClient.GetAsync(id);

            if (material == null)
            {
                MessageBox.Show(
                    "No se encontró el material.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _idMaterial = id;

            txtDescripcion.Text = material.Descripcion;
            numStock.Value = material.Stock;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var materialDto = new MaterialCreaActualizaDTO
            {
                Descripcion = txtDescripcion.Text,
                Stock = (int)numStock.Value
            };

            if (_idMaterial == null)
            {
                await MaterialApiClient.AddAsync(materialDto);

                MessageBox.Show(
                    "Material creado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                await MaterialApiClient.UpdateAsync(_idMaterial.Value, materialDto);

                MessageBox.Show(
                    "Material modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
