using API.Clients;
using DTOs;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PlanDetalle : Form
    {
        public int? PlanId { get; set; }

        public PlanDetalle()
        {
            InitializeComponent();

            this.Load -= PlanDetalle_Load;
            this.Load += PlanDetalle_Load;

            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;
        }

        private async void PlanDetalle_Load(object? sender, EventArgs e)
        {
            Text = PlanId.HasValue
                ? "Modificar plan"
                : "Registrar nuevo plan";

            try
            {
                var actividades = await ActividadApiClient.GetAllAsync();

                clbActividades.DisplayMember = "Tipo";
                clbActividades.Items.Clear();
                clbActividades.Items.AddRange(actividades.Cast<object>().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las actividades: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (!PlanId.HasValue)
            {
                return;
            }

            try
            {
                var plan = await PlanApiClient.GetAsync(PlanId.Value);

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

                for (int i = 0; i < clbActividades.Items.Count; i++)
                {
                    var actividad = (ActividadMostrarDTO)clbActividades.Items[i];
                    clbActividades.SetItemChecked(i, plan.IdsActividades.Contains(actividad.IdActividad));
                }
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

        private async void btnGuardar_Click(object? sender, EventArgs e)
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
                Precio = precio,
                Descripcion = Descripcion.Text.Trim(),
                IdsActividades = clbActividades.CheckedItems
                    .Cast<ActividadMostrarDTO>()
                    .Select(a => a.IdActividad)
                    .ToList()
            };

            try
            {
                if (PlanId.HasValue)
                {
                    await PlanApiClient.UpdateAsync(PlanId.Value, planDto);

                    MessageBox.Show(
                        "Plan actualizado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await PlanApiClient.AddAsync(planDto);

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

        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblDni_Click(object sender, EventArgs e) { }
    }
}