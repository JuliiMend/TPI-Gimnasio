using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
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
            var planForm = Program.ServiceProvider.GetRequiredService<PlanListaForm>();

            // Lo configuramos como hijo de la ventana principal (MDI)
            planForm.MdiParent = this;
            planForm.Show();
        }
    }
}
