using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await AuthServiceProvider.Instance.LogoutAsync();
            this.Close();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var planForm = new PlanLista();
            planForm.MdiParent = this;
            planForm.Show();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            var authService = AuthServiceProvider.Instance;
            var rol = await authService.GetRolAsync();

            Text = $"Gimnasio - {await authService.GetUsernameAsync()} ({rol})";

            if (rol == Roles.Admin)
            {
                return;
            }

            // Los reportes son solo para el Admin
            reportesToolStripMenuItem.Visible = false;

            // Profesor y Socio solo ven sus opciones (misma matriz que valida la API)
            var visibles = rol == Roles.Profesor
                ? new ToolStripMenuItem[] { clasesToolStripMenuItem, inscripcionesToolStripMenuItem, historicoSueldosToolStripMenuItem }
                : new ToolStripMenuItem[] { planesToolStripMenuItem, clasesToolStripMenuItem, inscripcionesToolStripMenuItem, cuotasToolStripMenuItem };

            foreach (ToolStripItem item in gestionToolStripMenuItem.DropDownItems)
            {
                item.Visible = visibles.Contains(item);
            }

            if (rol == Roles.Profesor)
            {
                clasesToolStripMenuItem.Text = "Mis clases";
                inscripcionesToolStripMenuItem.Text = "Inscriptos a mis clases";
                historicoSueldosToolStripMenuItem.Text = "Mi historico de sueldos";
            }
            else
            {
                planesToolStripMenuItem.Text = "Mi plan";
                inscripcionesToolStripMenuItem.Text = "Mis inscripciones";
                cuotasToolStripMenuItem.Text = "Mis cuotas";
            }
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var turnoForm = new TurnoLista();
            turnoForm.MdiParent = this;
            turnoForm.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var profesorForm = new ProfesorLista();
            profesorForm.MdiParent = this;
            profesorForm.Show();
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var socioForm = new SocioLista();
            socioForm.MdiParent = this;
            socioForm.Show();
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cuotaForm = new CuotaLista();
            cuotaForm.MdiParent = this;
            cuotaForm.Show();
        }
        private void maquinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maquinaForm = new MaquinaLista();
            maquinaForm.MdiParent = this;
            maquinaForm.Show();
        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var materialForm = new MaterialLista();
            materialForm.MdiParent = this;
            materialForm.Show();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var actividadForm = new ActividadLista();
            actividadForm.MdiParent = this;
            actividadForm.Show();
        }

        private void clasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var claseForm = new ClaseLista();
            claseForm.MdiParent = this;
            claseForm.Show();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inscripcionForm = new InscripcionLista();
            inscripcionForm.MdiParent = this;
            inscripcionForm.Show();
        }

        private void reporteOcupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reporteForm = new ReporteOcupacionClases();
            reporteForm.MdiParent = this;
            reporteForm.Show();
        }

        private void reporteMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reporteForm = new ReporteMantenimientos();
            reporteForm.MdiParent = this;
            reporteForm.Show();
        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mantenimientoForm = new MantenimientoLista();
            mantenimientoForm.MdiParent = this;
            mantenimientoForm.Show();
        }

        private void historicoSueldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historicoForm = new HistoricoSueldoLista();
            historicoForm.MdiParent = this;
            historicoForm.Show();
        }

        private void administradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var administradorForm = new AdministradorLista();
            administradorForm.MdiParent = this;
            administradorForm.Show();
        }
    }
}