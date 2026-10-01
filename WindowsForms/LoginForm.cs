using DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using API.Clients; 

namespace WindowsFormsApp
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Iniciando sesión...";

                bool exito = await _authService.LoginAsync(txtUsername.Text, txtPassword.Text);

                if (exito)
                {
                    this.Hide();
                    var homeForm = Program.ServiceProvider.GetRequiredService<Home>();
                    homeForm.FormClosed += (s, args) => this.Close();
                    homeForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }

        private bool ValidateInput()
        {
            errorProvider1.SetError(txtUsername, string.Empty);
            errorProvider1.SetError(txtPassword, string.Empty);

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "El nombre de usuario es requerido");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "La contraseña es requerida");
                isValid = false;
            }

            return isValid;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}