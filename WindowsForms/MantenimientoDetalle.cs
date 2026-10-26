using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MantenimientoDetalle : Form
    {
        private readonly MantenimientoMostrarDTO? _mantenimiento;

        public MantenimientoDetalle(MantenimientoMostrarDTO? mantenimiento = null)
        {
            InitializeComponent();
            _mantenimiento = mantenimiento;
        }

        private async void MantenimientoDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                var maquinas = await MaquinaApiClient.GetAllAsync();

                cmbMaquina.DisplayMember = "Nombre";
                cmbMaquina.ValueMember = "IdMaquina";
                cmbMaquina.DataSource = maquinas.ToList();
                cmbMaquina.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las máquinas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (_mantenimiento == null)
            {
                dtpInicio.Value = DateTime.Today;
                dtpFinEsperada.Value = DateTime.Today.AddDays(7);
                dtpFinReal.Checked = false;
                return;
            }

            cmbMaquina.SelectedValue = _mantenimiento.IdMaquina;
            txtDescripcion.Text = _mantenimiento.Descripcion;
            dtpInicio.Value = _mantenimiento.FechaInicio;
            dtpFinEsperada.Value = _mantenimiento.FechaFinEsperada;

            if (_mantenimiento.FechaFinReal.HasValue)
            {
                dtpFinReal.Value = _mantenimiento.FechaFinReal.Value;
                dtpFinReal.Checked = true;
            }
            else
            {
                dtpFinReal.Checked = false;
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (cmbMaquina.SelectedValue is not int idMaquina ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Seleccioná la máquina e ingresá la descripción.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var dto = new MantenimientoCreaActualizaDTO
            {
                IdMaquina = idMaquina,
                Descripcion = txtDescripcion.Text.Trim(),
                FechaInicio = dtpInicio.Value.Date,
                FechaFinEsperada = dtpFinEsperada.Value.Date,
                FechaFinReal = dtpFinReal.Checked ? dtpFinReal.Value.Date : null
            };

            try
            {
                if (_mantenimiento == null)
                {
                    await MantenimientoApiClient.AddAsync(dto);
                }
                else
                {
                    await MantenimientoApiClient.UpdateAsync(_mantenimiento.IdMantenimiento, dto);
                }

                MessageBox.Show(
                    "Mantenimiento guardado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el mantenimiento: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
