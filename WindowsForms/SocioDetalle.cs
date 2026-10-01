using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class SocioDetalle : Form
    {
        private int? _idSocio;

        public SocioDetalle()
        {
            InitializeComponent();

            this.Load -= SocioDetalle_Load;
            this.Load += SocioDetalle_Load;

            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private async Task CargarPlanesComboAsync()
        {
            if (cmbPlanes.DataSource == null)
            {
                var planes = await PlanApiClient.GetAllAsync();

                cmbPlanes.DisplayMember = "Nombre";
                cmbPlanes.ValueMember = "IdPlan";
                cmbPlanes.DataSource = planes;
            }
        }

        private async void SocioDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                if (_idSocio == null)
                {
                    await CargarPlanesComboAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CargarSocioAsync(int id)
        {
            try
            {
                await CargarPlanesComboAsync();

                var socio = await SocioApiClient.GetAsync(id);

                if (socio == null)
                {
                    MessageBox.Show("No se encontró el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _idSocio = id;

                txtDni.Text = socio.Dni;
                txtNombre.Text = socio.Nombre;
                txtApellido.Text = socio.Apellido;
                txtEmail.Text = socio.Email;
                txtTelefono.Text = socio.Telefono;
                if (socio.FechaNac.Year > 1900) dtpFechaNac.Value = socio.FechaNac;
                else dtpFechaNac.Value = DateTime.Today;
                if (socio.FechaAlta.Year > 1900) dtpFechaAlta.Value = socio.FechaAlta;
                else dtpFechaAlta.Value = DateTime.Today;

                if (socio.FechaBaja.HasValue)
                {
                    dtpFechaBaja.Checked = true;
                    dtpFechaBaja.Value = socio.FechaBaja.Value;
                }
                else
                {
                    dtpFechaBaja.Checked = false;
                }

                cmbPlanes.SelectedValue = socio.IdPlan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (cmbPlanes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un plan para el socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var socioDto = new SocioCreaActualizaDTO
                {
                    Dni = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    FechaNac = dtpFechaNac.Value,
                    FechaAlta = dtpFechaAlta.Value,
                    FechaBaja = dtpFechaBaja.Checked ? dtpFechaBaja.Value : (DateTime?)null,
                    IdPlan = (int)cmbPlanes.SelectedValue,
                    Username = string.Empty,
                    Password = string.Empty
                };

                if (_idSocio == null)
                {
                    await SocioApiClient.AddAsync(socioDto);
                    MessageBox.Show("Socio creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await SocioApiClient.UpdateAsync(socioDto);
                    MessageBox.Show("Socio modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e) { }
        private void lblFechaNac_Click(object sender, EventArgs e) { }
        private void btnCancelar_Click_1(object sender, EventArgs e) { }
    }
}