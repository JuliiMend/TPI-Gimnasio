using API.Clients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MaquinaLista : Form
    {
        public MaquinaLista()
        {
            InitializeComponent();
        }

        private async void MaquinaLista_Load(object sender, EventArgs e)
        {
            await CargarMaquinasAsync();
        }

        private async Task CargarMaquinasAsync()
        {
            try
            {
                var maquinas = await MaquinaApiClient.GetAllAsync();

                dgvMaquinas.DataSource = null;
                dgvMaquinas.DataSource = maquinas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las máquinas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var maquinaDetalleForm = new MaquinaDetalle();

            if (maquinaDetalleForm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarMaquinasAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMaquinas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una máquina para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var maquinaId = (int)dgvMaquinas.CurrentRow.Cells["colId"].Value;

            var maquinaDetalleForm = new MaquinaDetalle();

            await maquinaDetalleForm.CargarMaquinaAsync(maquinaId);

            if (maquinaDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarMaquinasAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaquinas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccioná una máquina para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var maquinaId = (int)dgvMaquinas.CurrentRow.Cells["colId"].Value;

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar esta máquina?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await MaquinaApiClient.DeleteAsync(maquinaId);

                    MessageBox.Show(
                        "Máquina eliminada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarMaquinasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar la máquina: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
