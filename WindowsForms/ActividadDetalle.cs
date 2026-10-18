using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ActividadDetalle : Form
    {
        private int? _idActividad;

        public ActividadDetalle()
        {
            InitializeComponent();
        }

        public async Task CargarActividadAsync(int id)
        {
            try
            {
                var actividad = await ActividadApiClient.GetAsync(id);

                if (actividad == null)
                {
                    MessageBox.Show(
                        "No se encontró la actividad.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idActividad = id;

                txtTipo.Text = actividad.Tipo;
                txtDescripcion.Text = actividad.Descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar la actividad: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Completá el tipo y la descripción.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var actividadDto = new ActividadCreaActualizaDTO
            {
                Tipo = txtTipo.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            try
            {
                if (_idActividad == null)
                {
                    await ActividadApiClient.AddAsync(actividadDto);

                    MessageBox.Show(
                        "Actividad creada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await ActividadApiClient.UpdateAsync(_idActividad.Value, actividadDto);

                    MessageBox.Show(
                        "Actividad modificada correctamente.",
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
                    $"Error al guardar la actividad: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
