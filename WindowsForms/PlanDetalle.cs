using Application.Services;
using DTOs;
using System;
using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowsFormsApp
{
    public partial class PlanDetalle : Form
    {
        private readonly IPlanService _planService;

        public int? PlanId { get; set; }

        public PlanDetalle(IPlanService planService)
        {
            InitializeComponent();
            _planService = planService;
        }

        private async void PlanDetalle_Load(object sender, EventArgs e)
        {
            Text = PlanId.HasValue
                ? "Modificar plan"
                : "Registrar nuevo plan";

            if (!PlanId.HasValue)
            {
                return;
            }

            try
            {
                var plan = await _planService.ObtenerPorIdAsync(PlanId.Value);

                if (plan == null)
                {
                    MessageBox.Show(
                        "No se encontró el plan solicitado.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Close();
                    return;
                }

                Nombre.Text = plan.Nombre;
                Tipo.Text = plan.Tipo;
                Precio.Text = plan.Precio.ToString(CultureInfo.CurrentCulture);
                Descripcion.Text = plan.Descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los datos del plan: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre.Text))
            {
                MessageBox.Show(
                    "El nombre del plan no puede estar vacío.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(Tipo.Text))
            {
                MessageBox.Show(
                    "El tipo de plan no puede estar vacío.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!decimal.TryParse(
                    Precio.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out var precio))
            {
                MessageBox.Show(
                    "Ingrese un precio numérico válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (precio < 0)
            {
                MessageBox.Show(
                    "El precio no puede ser negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var planDto = new PlanCreaActualizaDTO
            {
                Nombre = Nombre.Text.Trim(),
                Tipo = Tipo.Text.Trim(),
                Precio = precio
            };

            try
            {
                if (PlanId.HasValue)
                {
                    await _planService.ActualizarAsync(PlanId.Value, planDto);

                    MessageBox.Show(
                        "Plan actualizado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await _planService.CrearAsync(planDto);

                    MessageBox.Show(
                        "Plan registrado correctamente.",
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
                    $"Error al guardar el plan: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}