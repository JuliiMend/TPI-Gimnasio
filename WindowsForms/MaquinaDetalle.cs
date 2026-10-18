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
        }

        public async Task CargarMaquinaAsync(int id)
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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var maquinaDto = new MaquinaCreaActualizaDTO
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Tipo = txtTipo.Text,
                Estado = cmbEstado.Text
            };

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
    }
}
