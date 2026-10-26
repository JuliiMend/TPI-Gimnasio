using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ClaseDetalle : Form
    {
        private int? _idClase;

        private ClaseMostrarDTO? _claseAEditar;

        public ClaseDetalle()
        {
            InitializeComponent();
        }

        private async Task CargarCombosAsync()
        {
            var actividades = await ActividadApiClient.GetAllAsync();
            var profesores = await ProfesorApiClient.GetAllAsync();
            var turnos = await TurnoApiClient.GetAllAsync();

            cmbActividad.DisplayMember = "Tipo";
            cmbActividad.ValueMember = "IdActividad";
            cmbActividad.DataSource = actividades.ToList();

            cmbProfesor.DisplayMember = "Texto";
            cmbProfesor.ValueMember = "Id";
            cmbProfesor.DataSource = profesores
                .Select(p => new { Id = p.IdPersona, Texto = $"{p.Nombre} {p.Apellido}" })
                .ToList();

            cmbTurno.DisplayMember = "Texto";
            cmbTurno.ValueMember = "Id";
            cmbTurno.DataSource = turnos
                .Select(t => new { Id = t.IdTurno, Texto = $"{t.DiaSemana} {t.HoraDesde:hh\\:mm} - {t.HoraHasta:hh\\:mm}" })
                .ToList();

            cmbActividad.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;
            cmbTurno.SelectedIndex = -1;
        }

        private async void ClaseDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                await CargarCombosAsync();

                if (_claseAEditar != null)
                {
                    cmbActividad.SelectedValue = _claseAEditar.IdActividad;
                    cmbProfesor.SelectedValue = _claseAEditar.IdProfesor;
                    cmbTurno.SelectedValue = _claseAEditar.IdTurno;
                    numCupo.Value = Math.Min(Math.Max(_claseAEditar.Cupo, numCupo.Minimum), numCupo.Maximum);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar actividades, profesores o turnos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public async Task CargarClaseAsync(int id)
        {
            try
            {
                var clase = await ClaseApiClient.GetAsync(id);

                if (clase == null)
                {
                    MessageBox.Show(
                        "No se encontró la clase.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                _idClase = id;
                _claseAEditar = clase;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar la clase: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (cmbActividad.SelectedValue is not int idActividad ||
                cmbProfesor.SelectedValue is not int idProfesor ||
                cmbTurno.SelectedValue is not int idTurno)
            {
                MessageBox.Show(
                    "Seleccioná la actividad, el profesor y el turno.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var claseDto = new ClaseCreaActualizaDTO
            {
                IdActividad = idActividad,
                IdProfesor = idProfesor,
                IdTurno = idTurno,
                Cupo = (int)numCupo.Value
            };

            try
            {
                if (_idClase == null)
                {
                    await ClaseApiClient.AddAsync(claseDto);

                    MessageBox.Show(
                        "Clase creada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await ClaseApiClient.UpdateAsync(_idClase.Value, claseDto);

                    MessageBox.Show(
                        "Clase modificada correctamente.",
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
                    $"Error al guardar la clase: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
