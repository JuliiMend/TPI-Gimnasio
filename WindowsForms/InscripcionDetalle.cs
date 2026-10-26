using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class InscripcionDetalle : Form
    {
        private readonly int? _idClaseInicial;

        public InscripcionDetalle(int? idClaseInicial = null)
        {
            InitializeComponent();
            _idClaseInicial = idClaseInicial;
        }

        private bool _esSocio;

        private async void InscripcionDetalle_Load(object? sender, EventArgs e)
        {
            _esSocio = await AuthServiceProvider.Instance.HasPermissionAsync(Roles.Socio);

            if (_esSocio)
            {
                lblSocio.Visible = cmbSocio.Visible = false;
                lblTitulo.Text = "INSCRIBIRME A UNA CLASE";
            }

            try
            {
                if (!_esSocio)
                {
                    var socios = await SocioApiClient.GetAllAsync();

                    cmbSocio.DisplayMember = "Texto";
                    cmbSocio.ValueMember = "Id";
                    cmbSocio.DataSource = socios
                        .Where(s => s.FechaBaja == null || s.FechaBaja.Value.Date > DateTime.Today)
                        .Select(s => new { Id = s.IdPersona, Texto = $"{s.Nombre} {s.Apellido} (DNI {s.Dni})" })
                        .ToList();
                    cmbSocio.SelectedIndex = -1;
                }

                var clases = await ClaseApiClient.GetAllAsync();

                cmbClase.DisplayMember = "Texto";
                cmbClase.ValueMember = "Id";
                cmbClase.DataSource = clases
                    .Select(c => new
                    {
                        Id = c.IdClase,
                        Texto = $"{c.Actividad} - {c.Turno} ({c.Inscriptos}/{c.Cupo}){(c.Inscriptos >= c.Cupo ? " - SIN CUPO" : "")}"
                    })
                    .ToList();

                cmbClase.SelectedIndex = -1;

                if (_idClaseInicial.HasValue)
                {
                    cmbClase.SelectedValue = _idClaseInicial.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar socios o clases: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnInscribir_Click(object? sender, EventArgs e)
        {
            int idSocio = 0;

            if ((!_esSocio && cmbSocio.SelectedValue is not int) ||
                cmbClase.SelectedValue is not int idClase)
            {
                MessageBox.Show(
                    _esSocio ? "Seleccioná la clase." : "Seleccioná el socio y la clase.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!_esSocio)
            {
                idSocio = (int)cmbSocio.SelectedValue!;
            }

            try
            {
                await InscripcionApiClient.AddAsync(new InscripcionCreaDTO
                {
                    IdSocio = idSocio,
                    IdClase = idClase
                });

                MessageBox.Show(
                    "Socio inscripto correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo inscribir: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
