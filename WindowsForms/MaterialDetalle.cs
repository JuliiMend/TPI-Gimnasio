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
            try
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
                // Clamp: si el stock supera el máximo del control, asignarlo directo lanza una excepción
                numStock.Value = Math.Min(Math.Max(material.Stock, numStock.Minimum), numStock.Maximum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el material: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Ingresá la descripción.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var materialDto = new MaterialCreaActualizaDTO
            {
                Descripcion = txtDescripcion.Text.Trim(),
                Stock = (int)numStock.Value
            };

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el material: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
