using API.Clients;
using System;
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

        private void Home_Load(object sender, EventArgs e)
        {
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
    }
}