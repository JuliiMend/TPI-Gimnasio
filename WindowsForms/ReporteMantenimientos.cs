using API.Clients;
using DTOs;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ReporteMantenimientos : Form
    {
        // Mismos estados que calcula MantenimientoService, con el mismo color que en el reporte web
        private static readonly (string Nombre, string Color)[] Estados =
        {
            ("En curso", "#0d6efd"),
            ("Demorado", "#dc3545"),
            ("Finalizado", "#198754"),
            ("Finalizado con demora", "#fd7e14")
        };

        // Filas de las grillas: los DisplayName son los encabezados de las columnas
        private class FilaResumen
        {
            [DisplayName("Estado")] public string Estado { get; init; } = string.Empty;
            [DisplayName("Cantidad")] public int Cantidad { get; init; }
            [DisplayName("Días de demora")] public int DiasDemora { get; init; }
        }

        private class FilaDetalle
        {
            [DisplayName("Máquina")] public string Maquina { get; init; } = string.Empty;
            [DisplayName("Descripción")] public string Descripcion { get; init; } = string.Empty;
            [DisplayName("Inicio")] public string Inicio { get; init; } = string.Empty;
            [DisplayName("Fin esperado")] public string FinEsperado { get; init; } = string.Empty;
            [DisplayName("Fin real")] public string FinReal { get; init; } = string.Empty;
            [DisplayName("Estado")] public string Estado { get; init; } = string.Empty;
            [DisplayName("Días de demora")] public int DiasDemora { get; init; }
        }

        public ReporteMantenimientos()
        {
            InitializeComponent();
        }

        private async void ReporteMantenimientos_Load(object sender, EventArgs e)
        {
            try
            {
                var maquinas = await MaquinaApiClient.GetAllAsync();

                var opciones = new List<object> { new { Id = 0, Texto = "Todas las máquinas" } };
                opciones.AddRange(maquinas.Select(m => new { Id = m.IdMaquina, Texto = m.Nombre }));

                cmbFiltroMaquina.DisplayMember = "Texto";
                cmbFiltroMaquina.ValueMember = "Id";
                cmbFiltroMaquina.DataSource = opciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las máquinas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            await GenerarReporteAsync();
        }

        private async void cmbFiltroMaquina_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            await GenerarReporteAsync();
        }

        private async Task GenerarReporteAsync()
        {
            try
            {
                int? idMaquina = cmbFiltroMaquina.SelectedValue is int id && id > 0 ? id : null;

                var mantenimientos = (await MantenimientoApiClient.GetAllAsync(idMaquina)).ToList();

                var resumen = Estados
                    .Select(est => new FilaResumen
                    {
                        Estado = est.Nombre,
                        Cantidad = mantenimientos.Count(m => m.Estado == est.Nombre),
                        DiasDemora = mantenimientos.Where(m => m.Estado == est.Nombre).Sum(m => m.DiasDemora)
                    })
                    .ToList();

                resumen.Add(new FilaResumen
                {
                    Estado = "Total",
                    Cantidad = mantenimientos.Count,
                    DiasDemora = mantenimientos.Sum(m => m.DiasDemora)
                });

                dgvResumen.DataSource = resumen;

                dgvDetalle.DataSource = mantenimientos
                    .Select(m => new FilaDetalle
                    {
                        Maquina = m.Maquina,
                        Descripcion = m.Descripcion,
                        Inicio = m.FechaInicio.ToString("dd/MM/yyyy"),
                        FinEsperado = m.FechaFinEsperada.ToString("dd/MM/yyyy"),
                        FinReal = m.FechaFinReal?.ToString("dd/MM/yyyy") ?? "-",
                        Estado = m.Estado,
                        DiasDemora = m.DiasDemora
                    })
                    .ToList();

                DibujarGrafico(mantenimientos);
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

        // Torta con la cantidad de mantenimientos por estado (solo los estados que tienen alguno)
        private void DibujarGrafico(List<MantenimientoMostrarDTO> mantenimientos)
        {
            var plot = formsPlot.Plot;
            plot.Clear();

            var porciones = Estados
                .Select(est => new { est.Nombre, est.Color, Cantidad = mantenimientos.Count(m => m.Estado == est.Nombre) })
                .Where(est => est.Cantidad > 0)
                .Select(est => new PieSlice
                {
                    Value = est.Cantidad,
                    FillColor = ScottPlot.Color.FromHex(est.Color),
                    LegendText = est.Nombre,
                    Label = est.Cantidad.ToString(),
                    LabelFontSize = 14,
                    LabelFontColor = Colors.White,
                    LabelBold = true
                })
                .ToList();

            if (porciones.Count > 0)
            {
                var torta = plot.Add.Pie(porciones);
                torta.SliceLabelDistance = 0.6;
            }

            plot.Title(porciones.Count > 0 ? "Mantenimientos por estado" : "Sin mantenimientos");

            // Sin ejes ni grilla (Frameless también ocultaría el título)
            plot.Axes.Left.IsVisible = false;
            plot.Axes.Right.IsVisible = false;
            plot.Axes.Bottom.IsVisible = false;
            plot.Axes.Top.IsVisible = false;
            plot.Axes.Frame(false);
            plot.HideGrid();
            plot.Axes.SquareUnits();
            plot.ShowLegend(Edge.Right);

            formsPlot.Refresh();
        }
    }
}
