using API.Clients;
using ScottPlot;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ReporteOcupacionClases : Form
    {
        private class FilaOcupacion
        {
            [DisplayName("Clase")] public string Clase { get; init; } = string.Empty;
            [DisplayName("Profesor")] public string Profesor { get; init; } = string.Empty;
            [DisplayName("Turno")] public string Turno { get; init; } = string.Empty;
            [DisplayName("Inscriptos")] public int Inscriptos { get; init; }
            [DisplayName("Cupo")] public int Cupo { get; init; }
            [DisplayName("Disponibles")] public int Disponibles => Math.Max(0, Cupo - Inscriptos);
            [DisplayName("Ocupación %")] public string Ocupacion => $"{Porcentaje:0}%";
            [Browsable(false)] public double Porcentaje => Cupo > 0 ? 100.0 * Inscriptos / Cupo : 0;
        }

        public ReporteOcupacionClases()
        {
            InitializeComponent();
        }

        private async void ReporteOcupacionClases_Load(object sender, EventArgs e)
        {
            try
            {
                var clases = await ClaseApiClient.GetAllAsync();

                var filas = clases
                    .Select(c => new FilaOcupacion
                    {
                        Clase = c.Actividad,
                        Profesor = c.Profesor,
                        Turno = c.Turno,
                        Inscriptos = c.Inscriptos,
                        Cupo = c.Cupo
                    })
                    .OrderByDescending(f => f.Porcentaje)
                    .ToList();

                dgvOcupacion.DataSource = filas;

                foreach (DataGridViewRow fila in dgvOcupacion.Rows)
                {
                    if (fila.DataBoundItem is FilaOcupacion f && f.Disponibles == 0)
                    {
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                }

                lblResumen.Text = filas.Count == 0
                    ? "No hay clases cargadas."
                    : $"Clases: {filas.Count}   |   Inscriptos: {filas.Sum(f => f.Inscriptos)}   |   " +
                      $"Ocupación promedio: {filas.Average(f => f.Porcentaje):0}%   |   Clases llenas: {filas.Count(f => f.Disponibles == 0)}";

                DibujarGrafico(filas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el reporte: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DibujarGrafico(System.Collections.Generic.List<FilaOcupacion> filas)
        {
            var plot = formsPlot.Plot;
            plot.Clear();

            var inscriptos = plot.Add.Bars(filas.Select((f, i) => new Bar
            {
                Position = i * 3,
                Value = f.Inscriptos,
                FillColor = ScottPlot.Color.FromHex("#0d6efd")
            }).ToList());
            inscriptos.LegendText = "Inscriptos";

            var cupo = plot.Add.Bars(filas.Select((f, i) => new Bar
            {
                Position = i * 3 + 1,
                Value = f.Cupo,
                FillColor = ScottPlot.Color.FromHex("#adb5bd")
            }).ToList());
            cupo.LegendText = "Cupo";

            plot.Axes.Bottom.SetTicks(
                filas.Select((f, i) => i * 3 + 0.5).ToArray(),
                filas.Select(f => $"{f.Clase}\n{f.Turno}").ToArray());

            plot.Title("Inscriptos vs. cupo por clase");
            plot.YLabel("Personas");
            plot.Axes.Margins(bottom: 0);
            plot.ShowLegend(Alignment.UpperLeft);

            formsPlot.Refresh();
        }
    }
}
