using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsFormsApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Pedimos el formulario al contenedor de dependencias
            var planForm = Program.ServiceProvider.GetRequiredService<PlanLista>();

            // Lo configuramos como hijo de la ventana principal (MDI)
            planForm.MdiParent = this;
            planForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var turnoForm = Program.ServiceProvider.GetRequiredService<TurnoLista>();

            turnoForm.MdiParent = this;
            turnoForm.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var profesorForm = Program.ServiceProvider.GetRequiredService<ProfesorLista>();

            profesorForm.MdiParent = this;
            profesorForm.Show();
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var socioForm = Program.ServiceProvider.GetRequiredService<SocioLista>();

            socioForm.MdiParent = this;
            socioForm.Show();
        }
    }
}
