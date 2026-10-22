using API.Clients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MaterialLista : Form
    {
        public MaterialLista()
        {
            InitializeComponent();
        }

        private async void MaterialLista_Load(object sender, EventArgs e)
        {
            await CargarMaterialesAsync();
        }

        private async Task CargarMaterialesAsync()
        {
            try
            {
                var materiales = await MaterialApiClient.GetAllAsync();

                dgvMateriales.DataSource = null;
                dgvMateriales.DataSource = materiales;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los materiales: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var materialDetalleForm = new MaterialDetalle();

            if (materialDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarMaterialesAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un material para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var materialId = (int)dgvMateriales.CurrentRow.Cells["colId"].Value;

            var materialDetalleForm = new MaterialDetalle();

            await materialDetalleForm.CargarMaterialAsync(materialId);

            if (materialDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarMaterialesAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná un material para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var materialId = (int)dgvMateriales.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este material?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await MaterialApiClient.DeleteAsync(materialId);

                    MessageBox.Show(
                        "Material eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarMaterialesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar el material: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
