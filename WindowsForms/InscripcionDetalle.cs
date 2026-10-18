using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class InscripcionDetalle : Form
    {
        // Clase preseleccionada (la del filtro de la lista), si hay
        private readonly int? _idClaseInicial;

        public InscripcionDetalle(int? idClaseInicial = null)
        {
            InitializeComponent();
            _idClaseInicial = idClaseInicial;
        }

        private async void InscripcionDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                var socios = await SocioApiClient.GetAllAsync();
                var clases = await ClaseApiClient.GetAllAsync();

                // Los socios dados de baja no pueden inscribirse
                cmbSocio.DisplayMember = "Texto";
                cmbSocio.ValueMember = "Id";
                cmbSocio.DataSource = socios
                    .Where(s => s.FechaBaja == null || s.FechaBaja.Value.Date > DateTime.Today)
                    .Select(s => new { Id = s.IdPersona, Texto = $"{s.Nombre} {s.Apellido} (DNI {s.Dni})" })
                    .ToList();

                cmbClase.DisplayMember = "Texto";
                cmbClase.ValueMember = "Id";
                cmbClase.DataSource = clases
                    .Select(c => new
                    {
                        Id = c.IdClase,
                        Texto = $"{c.Actividad} - {c.Turno} ({c.Inscriptos}/{c.Cupo}){(c.Inscriptos >= c.Cupo ? " - SIN CUPO" : "")}"
                    })
                    .ToList();

                cmbSocio.SelectedIndex = -1;
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
            if (cmbSocio.SelectedValue is not int idSocio ||
                cmbClase.SelectedValue is not int idClase)
            {
                MessageBox.Show(
                    "Seleccioná el socio y la clase.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
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
                // Ej: la clase se quedó sin cupo o el socio ya estaba inscripto
                MessageBox.Show(
                    $"No se pudo inscribir: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
