using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class InscripcionLista : Form
    {
        public InscripcionLista()
        {
            InitializeComponent();
            Icon = Program.AppIcon;
        }

        private async void InscripcionLista_Load(object sender, EventArgs e)
        {
            var authService = AuthServiceProvider.Instance;

            if (await authService.HasPermissionAsync(Roles.Profesor))
            {
                Text = lblTitulo.Text = "Inscriptos a mis clases";
                btnNuevo.Visible = btnCancelarInscripcion.Visible = lblOpciones.Visible = false;
            }
            else if (await authService.HasPermissionAsync(Roles.Socio))
            {
                Text = lblTitulo.Text = "Mis inscripciones";
                btnNuevo.Text = "Inscribirme a una clase";
            }

            try
            {
                var clases = await ClaseApiClient.GetAllAsync();

                var opciones = new List<object> { new { Id = 0, Texto = "Todas las clases" } };
                opciones.AddRange(clases.Select(c => new { Id = c.IdClase, Texto = $"{c.Actividad} - {c.Turno}" }));

                cmbFiltroClase.DisplayMember = "Texto";
                cmbFiltroClase.ValueMember = "Id";
                cmbFiltroClase.DataSource = opciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las clases: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            await CargarInscripcionesAsync();
        }

        private int? IdClaseFiltro()
        {
            return cmbFiltroClase.SelectedValue is int id && id > 0 ? id : null;
        }

        private async Task CargarInscripcionesAsync()
        {
            try
            {
                var inscripciones = await InscripcionApiClient.GetAllAsync(IdClaseFiltro());

                dgvInscripciones.DataSource = null;
                dgvInscripciones.DataSource = inscripciones.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las inscripciones: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void cmbFiltroClase_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            await CargarInscripcionesAsync();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var inscripcionDetalleForm = new InscripcionDetalle(IdClaseFiltro());

            if (inscripcionDetalleForm.ShowDialog() == DialogResult.OK)
            {
                await CargarInscripcionesAsync();
            }
        }

        private async void btnCancelarInscripcion_Click(object sender, EventArgs e)
        {
            if (dgvInscripciones.CurrentRow?.DataBoundItem is not InscripcionMostrarDTO inscripcion)
            {
                MessageBox.Show(
                    "Seleccioná una inscripción para cancelar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Cancelar la inscripción de {inscripcion.Socio} a {inscripcion.Clase}?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await InscripcionApiClient.DeleteAsync(inscripcion.IdInscripcion);

                    MessageBox.Show(
                        "Inscripción cancelada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CargarInscripcionesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al cancelar la inscripción: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
