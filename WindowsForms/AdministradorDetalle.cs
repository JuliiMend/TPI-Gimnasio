using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class AdministradorDetalle : Form
    {
        private int? _idAdministrador;

        public AdministradorDetalle()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        public async Task CargarAdministradorAsync(int id)
        {
            try
            {
                var administrador = await AdministradorApiClient.GetAsync(id);

                if (administrador == null)
                {
                    MessageBox.Show(
                        "No se encontró el administrador.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idAdministrador = id;

                txtDni.Text = administrador.Dni;
                txtNombre.Text = administrador.Nombre;
                txtApellido.Text = administrador.Apellido;
                txtEmail.Text = administrador.Email;
                txtTelefono.Text = administrador.Telefono;
                dtpFechaNac.Value = administrador.FechaNac >= dtpFechaNac.MinDate ? administrador.FechaNac : DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el administrador: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var validacion = new ValidacionFormulario()
                .Persona(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text, dtpFechaNac.Value, 18);

            if (!validacion.EsValido())
            {
                return;
            }

            var administradorDto = new AdministradorCreaActualizaDTO
            {
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                FechaNac = dtpFechaNac.Value.Date,
                // Al crear, el servidor usa el DNI como usuario y contraseña inicial
                Username = _idAdministrador == null ? txtDni.Text.Trim() : string.Empty,
                Password = string.Empty
            };

            try
            {
                if (_idAdministrador == null)
                {
                    await AdministradorApiClient.AddAsync(administradorDto);

                    MessageBox.Show(
                        "Administrador creado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await AdministradorApiClient.UpdateAsync(_idAdministrador.Value, administradorDto);

                    MessageBox.Show(
                        "Administrador modificado correctamente.",
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
                    $"Error al guardar el administrador: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AdministradorDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}
