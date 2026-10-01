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
        }

        public async Task CargarProfesorAsync(int id)
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
            dtpFechaNac.Value = profesor.FechaNac;
            txtCargo.Text = profesor.Cargo;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var profesorDto = new ProfesorCreaActualizaDTO
            {
                Dni = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                FechaNac = dtpFechaNac.Value,
                Cargo = txtCargo.Text
            };

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
                await ProfesorApiClient.UpdateAsync(profesorDto);

                MessageBox.Show(
                    "Profesor modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ProfesorDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}