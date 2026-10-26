using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CuotaLista : Form
    {
        private static readonly string[] NombresMeses =
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        public CuotaLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void CuotaLista_Load(object sender, EventArgs e)
        {
            CargarFiltrosDeFecha();

            if (!await AuthServiceProvider.Instance.HasPermissionAsync(Roles.Admin))
            {
                Text = "Mis cuotas";
                btn_agregar.Visible = btn_actualizar.Visible = btn_eliminar.Visible = false;
                lblFiltroSocio.Visible = cmbFiltroSocio.Visible = false;
            }
            else
            {
                await CargarFiltroSocioAsync();
            }

            await this.LoadCuotas();
        }

        // En los combos de filtro, Id = 0 significa "Todos"
        private void CargarFiltrosDeFecha()
        {
            var meses = new List<object> { new { Id = 0, Texto = "Todos" } };
            meses.AddRange(NombresMeses.Select((nombre, i) => new { Id = i + 1, Texto = nombre }));

            cmbFiltroMes.DisplayMember = "Texto";
            cmbFiltroMes.ValueMember = "Id";
            cmbFiltroMes.DataSource = meses;

            int anioActual = DateTime.Today.Year;
            var anios = new List<object> { new { Id = 0, Texto = "Todos" } };
            anios.AddRange(Enumerable.Range(anioActual - 5, 7).Reverse().Select(a => new { Id = a, Texto = a.ToString() }));

            cmbFiltroAnio.DisplayMember = "Texto";
            cmbFiltroAnio.ValueMember = "Id";
            cmbFiltroAnio.DataSource = anios;
        }

        private async Task CargarFiltroSocioAsync()
        {
            try
            {
                var socios = await SocioApiClient.GetAllAsync();

                var opciones = new List<object> { new { Id = 0, Texto = "Todos los socios" } };
                opciones.AddRange(socios
                    .OrderBy(s => s.Apellido)
                    .ThenBy(s => s.Nombre)
                    .Select(s => new { Id = s.IdPersona, Texto = $"{s.Apellido}, {s.Nombre} ({s.Dni})" }));

                cmbFiltroSocio.DisplayMember = "Texto";
                cmbFiltroSocio.ValueMember = "Id";
                cmbFiltroSocio.DataSource = opciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los socios: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static int? ValorFiltro(ComboBox combo)
        {
            return combo.SelectedValue is int id && id > 0 ? id : null;
        }

        private async void filtro_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            paginador.Reiniciar();
            await this.LoadCuotas();
        }

        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cmbFiltroSocio.SelectedIndex = cmbFiltroSocio.Items.Count > 0 ? 0 : -1;
            cmbFiltroMes.SelectedIndex = 0;
            cmbFiltroAnio.SelectedIndex = 0;

            paginador.Reiniciar();
            await this.LoadCuotas();
        }

        private async void paginador_PaginaCambiada(object? sender, EventArgs e)
        {
            await this.LoadCuotas();
        }

        private async Task LoadCuotas()
        {
            try
            {
                btn_agregar.Enabled = false;
                btn_actualizar.Enabled = false;
                btn_eliminar.Enabled = false;

                this.dgv_cuotas.DataSource = null;

                // Para un socio la API ignora idSocio y devuelve solo sus cuotas
                PaginaDTO<CuotaMostrarDTO> pagina =
                    await CuotaApiClient.GetPaginadoAsync(
                        paginador.NumeroPagina,
                        paginador.TamanioPagina,
                        ValorFiltro(cmbFiltroSocio),
                        ValorFiltro(cmbFiltroMes),
                        ValorFiltro(cmbFiltroAnio));

                this.dgv_cuotas.DataSource = pagina.Items;
                paginador.Actualizar(pagina);

                btn_agregar.Enabled = true;

                if (this.dgv_cuotas.Rows.Count > 0)
                {
                    this.dgv_cuotas.Rows[0].Selected = true;
                    btn_actualizar.Enabled = true;
                    btn_eliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar cuotas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btn_agregar_Click(object sender, EventArgs e)
        {
            CuotaCreaActualizaDTO cuotaNueva =
                new CuotaCreaActualizaDTO();

            cuotaNueva.Detalles =
                new List<DetalleCuotaCreaActualizaDTO>();

            CuotaDetalle cuotaDetalle =
                new CuotaDetalle(cuotaNueva);

            cuotaDetalle.ShowDialog();

            await this.LoadCuotas();
        }

        private async void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_cuotas.SelectedRows.Count == 0)
                {
                    return;
                }

                CuotaMostrarDTO seleccionada =
                    (CuotaMostrarDTO)dgv_cuotas
                        .SelectedRows[0]
                        .DataBoundItem;

                var cuotaMostrar =
                    await CuotaApiClient.GetAsync(
                        seleccionada.CuotaId);

                if (cuotaMostrar == null)
                {
                    return;
                }

                var cuota = new CuotaCreaActualizaDTO
                {
                    CuotaId = cuotaMostrar.CuotaId,
                    SocioId = cuotaMostrar.SocioId,
                    MesAnio = cuotaMostrar.MesAnio,
                    FechaPago = cuotaMostrar.FechaPago,

                    Detalles = cuotaMostrar.Detalles?
                        .Select(d => new DetalleCuotaCreaActualizaDTO
                        {
                            DetalleCuotaId = d.DetalleCuotaId,
                            Concepto = d.Concepto,
                            Subtotal = d.Subtotal,
                            Monto = d.Monto
                        })
                        .ToList()
                        ?? new List<DetalleCuotaCreaActualizaDTO>()
                };

                CuotaDetalle cuotaDetalle =
                    new CuotaDetalle(cuota);

                cuotaDetalle.ShowDialog();

                await this.LoadCuotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar cuota para actualizar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_cuotas.SelectedRows.Count == 0)
            {
                return;
            }

            CuotaMostrarDTO seleccionada =
                (CuotaMostrarDTO)dgv_cuotas
                    .SelectedRows[0]
                    .DataBoundItem;

            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar la cuota #{seleccionada.CuotaId}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await CuotaApiClient.DeleteAsync(
                        seleccionada.CuotaId);

                    await this.LoadCuotas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar cuota: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}