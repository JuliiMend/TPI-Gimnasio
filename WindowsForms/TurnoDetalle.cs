using Application.Services;
using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TurnoDetalle : Form
    {
        private readonly ITurnoService _turnoService;
        private int? _idTurno;

        public TurnoDetalle(ITurnoService turnoService)
        {
            InitializeComponent();
            _turnoService = turnoService;
        }

        public async Task CargarTurnoAsync(int id)
        {
            var turno = await _turnoService.ObtenerPorIdAsync(id);

            if (turno == null)
            {
                MessageBox.Show(
                    "No se encontró el turno.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _idTurno = turno.IdTurno;

            cmbDia.Text = turno.DiaSemana;
            dtpHoraDesde.Value = DateTime.Today.Add(turno.HoraDesde);
            dtpHoraHasta.Value = DateTime.Today.Add(turno.HoraHasta);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var turnoDto = new TurnoCreaActualizaDTO
            {
                DiaSemana = cmbDia.Text,
                HoraDesde = dtpHoraDesde.Value.TimeOfDay,
                HoraHasta = dtpHoraHasta.Value.TimeOfDay
            };

            if (_idTurno == null)
            {
                await _turnoService.AgregarAsync(turnoDto);

                MessageBox.Show(
                    "Turno creado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                await _turnoService.ActualizarAsync(_idTurno.Value, turnoDto);

                MessageBox.Show(
                    "Turno modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}