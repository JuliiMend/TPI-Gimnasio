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
    }
}
