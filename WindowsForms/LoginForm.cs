using Application.Services;
using DTOs;
using Microsoft.Extensions.DependencyInjection;
using WindowsFormsApp;

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

            var request = new LoginRequest
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            var respuesta = await _authService.LoginAsync(request);

            if (respuesta.Exito)
            {
                this.Hide();


                var homeForm = Program.ServiceProvider.GetRequiredService<Home>();
                homeForm.FormClosed += (s, args) => this.Close();
                homeForm.Show();
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
