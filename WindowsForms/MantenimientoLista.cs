using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MantenimientoLista : Form
    {
        private const string TodosLosEstados = "Todos los estados";

        public MantenimientoLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void MantenimientoLista_Load(object sender, EventArgs e)
        {
            cmbFiltroEstado.DataSource = new List<string>
            {
                TodosLosEstados, "En curso", "Demorado", "Finalizado", "Finalizado con demora"
            };

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

            await CargarMantenimientosAsync();
        }

        private async Task CargarMantenimientosAsync()
        {
            try
            {
                int? idMaquina = cmbFiltroMaquina.SelectedValue is int id && id > 0 ? id : null;
                string? estado = cmbFiltroEstado.SelectedItem is string e && e != TodosLosEstados ? e : null;

                var mantenimientos = await MantenimientoApiClient.GetAllAsync(idMaquina, estado);

                dgvMantenimientos.DataSource = null;
                dgvMantenimientos.DataSource = mantenimientos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los mantenimientos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void filtro_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            await CargarMantenimientosAsync();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var mantenimientoDetalleForm = new MantenimientoDetalle();

            if (mantenimientoDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarMantenimientosAsync();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMantenimientos.CurrentRow?.DataBoundItem is not MantenimientoMostrarDTO mantenimiento)
            {
                MessageBox.Show(
                    "Seleccioná un mantenimiento para modificar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var mantenimientoDetalleForm = new MantenimientoDetalle(mantenimiento);

            if (mantenimientoDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarMantenimientosAsync();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMantenimientos.CurrentRow?.DataBoundItem is not MantenimientoMostrarDTO mantenimiento)
            {
                MessageBox.Show(
                    "Seleccioná un mantenimiento para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este mantenimiento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await MantenimientoApiClient.DeleteAsync(mantenimiento.IdMantenimiento);

                    MessageBox.Show(
                        "Mantenimiento eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarMantenimientosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al eliminar el mantenimiento: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
