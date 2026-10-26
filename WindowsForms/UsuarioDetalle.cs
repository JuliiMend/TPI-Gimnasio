using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class UsuarioDetalle : Form
    {
        private int? _idUsuario;

        public UsuarioDetalle()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        public async Task CargarUsuarioAsync(int id)
        {
            try
            {
                var usuario = await UsuarioApiClient.GetAsync(id);

                if (usuario == null)
                {
                    MessageBox.Show(
                        "No se encontró el usuario.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idUsuario = id;

                txtUsername.Text = usuario.Username;
                txtEmail.Text = usuario.Email;
                lblAyudaPassword.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el usuario: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Al editar, la contraseña vacía significa que no se cambia
            bool validarPassword = _idUsuario == null || !string.IsNullOrEmpty(txtPassword.Text);

            var validacion = new ValidacionFormulario()
                .Regla(ReglasValidacion.UsernameValido(txtUsername.Text), ReglasValidacion.MensajeUsername)
                .Regla(ReglasValidacion.EmailValido(txtEmail.Text), ReglasValidacion.MensajeEmail)
                .Regla(!validarPassword || ReglasValidacion.ErrorPassword(txtPassword.Text) == null,
                       ReglasValidacion.ErrorPassword(txtPassword.Text) ?? string.Empty);

            if (!validacion.EsValido())
            {
                return;
            }

            var usuarioDto = new UsuarioCreaActualizaDTO
            {
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text
            };

            try
            {
                if (_idUsuario == null)
                {
                    await UsuarioApiClient.AddAsync(usuarioDto);

                    MessageBox.Show(
                        "Usuario creado correctamente (rol Admin).",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await UsuarioApiClient.UpdateAsync(_idUsuario.Value, usuarioDto);

                    MessageBox.Show(
                        "Usuario modificado correctamente.",
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
                    $"Error al guardar el usuario: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
