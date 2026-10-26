using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ProfesorDetalle : Form
    {
        private int? _idProfesor;

        public ProfesorDetalle()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        public async Task CargarProfesorAsync(int id)
        {
            try
            {
                var profesor = await ProfesorApiClient.GetAsync(id);

                if (profesor == null)
                {
                    MessageBox.Show(
                        "No se encontró el profesor.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idProfesor = id;

                txtDni.Text = profesor.Dni;
                txtNombre.Text = profesor.Nombre;
                txtApellido.Text = profesor.Apellido;
                txtEmail.Text = profesor.Email;
                txtTelefono.Text = profesor.Telefono;
                dtpFechaNac.Value = profesor.FechaNac >= dtpFechaNac.MinDate ? profesor.FechaNac : DateTime.Today;
                txtCargo.Text = profesor.Cargo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el profesor: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var validacion = new ValidacionFormulario()
                .Persona(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEmail.Text, dtpFechaNac.Value, 18)
                .Requerido(txtCargo.Text, "el cargo");

            if (!validacion.EsValido())
            {
                return;
            }

            var profesorDto = new ProfesorCreaActualizaDTO
            {
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                FechaNac = dtpFechaNac.Value.Date,
                Cargo = txtCargo.Text.Trim(),
                // Al crear, el servidor usa el DNI como usuario y contraseña inicial
                Username = _idProfesor == null ? txtDni.Text.Trim() : string.Empty,
                Password = string.Empty
            };

            try
            {
                if (_idProfesor == null)
                {
                    await ProfesorApiClient.AddAsync(profesorDto);

                    MessageBox.Show(
                        "Profesor creado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await ProfesorApiClient.UpdateAsync(_idProfesor.Value, profesorDto);

                    MessageBox.Show(
                        "Profesor modificado correctamente.",
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
                    $"Error al guardar el profesor: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ProfesorDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}