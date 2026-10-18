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
            // Al editar, la contraseña vacía significa "no cambiarla"
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                (_idUsuario == null && string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show(
                    _idUsuario == null
                        ? "Completá usuario, email y contraseña."
                        : "Completá usuario y email.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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
