using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MaquinaDetalle : Form
    {
        private int? _idMaquina;

        public MaquinaDetalle()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        public async Task CargarMaquinaAsync(int id)
        {
            try
            {
                var maquina = await MaquinaApiClient.GetAsync(id);

                if (maquina == null)
                {
                    MessageBox.Show(
                        "No se encontró la máquina.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idMaquina = id;

                txtNombre.Text = maquina.Nombre;
                txtDescripcion.Text = maquina.Descripcion;
                txtTipo.Text = maquina.Tipo;
                cmbEstado.Text = maquina.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar la máquina: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show(
                    "Completá todos los campos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var maquinaDto = new MaquinaCreaActualizaDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Tipo = txtTipo.Text.Trim(),
                Estado = cmbEstado.Text
            };

            try
            {
                if (_idMaquina == null)
                {
                    await MaquinaApiClient.AddAsync(maquinaDto);

                    MessageBox.Show(
                        "Máquina creada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await MaquinaApiClient.UpdateAsync(_idMaquina.Value, maquinaDto);

                    MessageBox.Show(
                        "Máquina modificada correctamente.",
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
                    $"Error al guardar la máquina: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
