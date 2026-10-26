using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class HistoricoSueldoDetalle : Form
    {
        private readonly int? _idProfesorInicial;

        public HistoricoSueldoDetalle(int? idProfesorInicial = null)
        {
            InitializeComponent();
            Icon = Program.AppIcon;
            _idProfesorInicial = idProfesorInicial;
        }

        private async void HistoricoSueldoDetalle_Load(object? sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;

            try
            {
                var profesores = await ProfesorApiClient.GetAllAsync();

                cmbProfesor.DisplayMember = "Texto";
                cmbProfesor.ValueMember = "Id";
                cmbProfesor.DataSource = profesores
                    .Select(p => new { Id = p.IdPersona, Texto = $"{p.Nombre} {p.Apellido}" })
                    .ToList();
                cmbProfesor.SelectedIndex = -1;

                if (_idProfesorInicial.HasValue)
                {
                    cmbProfesor.SelectedValue = _idProfesorInicial.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los profesores: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnRegistrar_Click(object? sender, EventArgs e)
        {
            if (cmbProfesor.SelectedValue is not int idProfesor || numValor.Value <= 0)
            {
                MessageBox.Show(
                    "Seleccioná el profesor e ingresá un valor mayor a 0.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                await HistoricoSueldoApiClient.AddAsync(new HistoricoSueldoCreaDTO
                {
                    IdProfesor = idProfesor,
                    FechaDesde = dtpDesde.Value.Date,
                    Valor = numValor.Value
                });

                MessageBox.Show(
                    "Sueldo registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al registrar el sueldo: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
