namespace WindowsFormsApp
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            gestionToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reporteOcupacionToolStripMenuItem = new ToolStripMenuItem();
            reporteMantenimientosToolStripMenuItem = new ToolStripMenuItem();
            sociosToolStripMenuItem = new ToolStripMenuItem();
            planesToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            profesoresToolStripMenuItem = new ToolStripMenuItem();
            cuotasToolStripMenuItem = new ToolStripMenuItem();
            maquinasToolStripMenuItem = new ToolStripMenuItem();
            materialesToolStripMenuItem = new ToolStripMenuItem();
            actividadesToolStripMenuItem = new ToolStripMenuItem();
            clasesToolStripMenuItem = new ToolStripMenuItem();
            inscripcionesToolStripMenuItem = new ToolStripMenuItem();
            administradoresToolStripMenuItem = new ToolStripMenuItem();
            mantenimientosToolStripMenuItem = new ToolStripMenuItem();
            historicoSueldosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sistemaToolStripMenuItem, gestionToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem });
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(60, 20);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(142, 22);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // gestionToolStripMenuItem
            // 
            gestionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sociosToolStripMenuItem, planesToolStripMenuItem, turnosToolStripMenuItem, profesoresToolStripMenuItem, cuotasToolStripMenuItem, maquinasToolStripMenuItem, materialesToolStripMenuItem, actividadesToolStripMenuItem, clasesToolStripMenuItem, inscripcionesToolStripMenuItem, administradoresToolStripMenuItem, mantenimientosToolStripMenuItem, historicoSueldosToolStripMenuItem });
            gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            gestionToolStripMenuItem.Size = new Size(59, 20);
            gestionToolStripMenuItem.Text = "Gestion";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reporteOcupacionToolStripMenuItem, reporteMantenimientosToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteOcupacionToolStripMenuItem
            // 
            reporteOcupacionToolStripMenuItem.Name = "reporteOcupacionToolStripMenuItem";
            reporteOcupacionToolStripMenuItem.Size = new Size(230, 22);
            reporteOcupacionToolStripMenuItem.Text = "Ocupacion de clases";
            reporteOcupacionToolStripMenuItem.Click += reporteOcupacionToolStripMenuItem_Click;
            // 
            // reporteMantenimientosToolStripMenuItem
            // 
            reporteMantenimientosToolStripMenuItem.Name = "reporteMantenimientosToolStripMenuItem";
            reporteMantenimientosToolStripMenuItem.Size = new Size(230, 22);
            reporteMantenimientosToolStripMenuItem.Text = "Mantenimiento de maquinas";
            reporteMantenimientosToolStripMenuItem.Click += reporteMantenimientosToolStripMenuItem_Click;
            // 
            // sociosToolStripMenuItem
            // 
            sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            sociosToolStripMenuItem.Size = new Size(180, 22);
            sociosToolStripMenuItem.Text = "Socios";
            sociosToolStripMenuItem.Click += sociosToolStripMenuItem_Click;
            // 
            // planesToolStripMenuItem
            // 
            planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            planesToolStripMenuItem.Size = new Size(180, 22);
            planesToolStripMenuItem.Text = "Planes";
            planesToolStripMenuItem.Click += planesToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(180, 22);
            turnosToolStripMenuItem.Text = "Turnos";
            turnosToolStripMenuItem.Click += turnosToolStripMenuItem_Click;
            // 
            // profesoresToolStripMenuItem
            // 
            profesoresToolStripMenuItem.Name = "profesoresToolStripMenuItem";
            profesoresToolStripMenuItem.Size = new Size(180, 22);
            profesoresToolStripMenuItem.Text = "Profesores";
            profesoresToolStripMenuItem.Click += profesoresToolStripMenuItem_Click;
            // 
            // cuotasToolStripMenuItem
            // 
            cuotasToolStripMenuItem.Name = "cuotasToolStripMenuItem";
            cuotasToolStripMenuItem.Size = new Size(180, 22);
            cuotasToolStripMenuItem.Text = "Cuotas";
            cuotasToolStripMenuItem.Click += cuotasToolStripMenuItem_Click;
            // 
            // maquinasToolStripMenuItem
            // 
            maquinasToolStripMenuItem.Name = "maquinasToolStripMenuItem";
            maquinasToolStripMenuItem.Size = new Size(180, 22);
            maquinasToolStripMenuItem.Text = "Maquinas";
            maquinasToolStripMenuItem.Click += maquinasToolStripMenuItem_Click;
            // 
            // materialesToolStripMenuItem
            // 
            materialesToolStripMenuItem.Name = "materialesToolStripMenuItem";
            materialesToolStripMenuItem.Size = new Size(180, 22);
            materialesToolStripMenuItem.Text = "Materiales";
            materialesToolStripMenuItem.Click += materialesToolStripMenuItem_Click;
            // 
            // actividadesToolStripMenuItem
            // 
            actividadesToolStripMenuItem.Name = "actividadesToolStripMenuItem";
            actividadesToolStripMenuItem.Size = new Size(180, 22);
            actividadesToolStripMenuItem.Text = "Actividades";
            actividadesToolStripMenuItem.Click += actividadesToolStripMenuItem_Click;
            // 
            // clasesToolStripMenuItem
            // 
            clasesToolStripMenuItem.Name = "clasesToolStripMenuItem";
            clasesToolStripMenuItem.Size = new Size(180, 22);
            clasesToolStripMenuItem.Text = "Clases";
            clasesToolStripMenuItem.Click += clasesToolStripMenuItem_Click;
            // 
            // inscripcionesToolStripMenuItem
            // 
            inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            inscripcionesToolStripMenuItem.Size = new Size(180, 22);
            inscripcionesToolStripMenuItem.Text = "Inscripciones";
            inscripcionesToolStripMenuItem.Click += inscripcionesToolStripMenuItem_Click;
            // 
            // administradoresToolStripMenuItem
            // 
            administradoresToolStripMenuItem.Name = "administradoresToolStripMenuItem";
            administradoresToolStripMenuItem.Size = new Size(180, 22);
            administradoresToolStripMenuItem.Text = "Administradores";
            administradoresToolStripMenuItem.Click += administradoresToolStripMenuItem_Click;
            // 
            // mantenimientosToolStripMenuItem
            // 
            mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            mantenimientosToolStripMenuItem.Size = new Size(180, 22);
            mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            mantenimientosToolStripMenuItem.Click += mantenimientosToolStripMenuItem_Click;
            // 
            // historicoSueldosToolStripMenuItem
            // 
            historicoSueldosToolStripMenuItem.Name = "historicoSueldosToolStripMenuItem";
            historicoSueldosToolStripMenuItem.Size = new Size(180, 22);
            historicoSueldosToolStripMenuItem.Text = "Historico de sueldos";
            historicoSueldosToolStripMenuItem.Click += historicoSueldosToolStripMenuItem_Click;
            // 
            // Home
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Home";
            WindowState = FormWindowState.Maximized;
            Load += Home_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem reporteOcupacionToolStripMenuItem;
        private ToolStripMenuItem reporteMantenimientosToolStripMenuItem;
        private ToolStripMenuItem sociosToolStripMenuItem;
        private ToolStripMenuItem planesToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem profesoresToolStripMenuItem;
        private ToolStripMenuItem cuotasToolStripMenuItem;
        private ToolStripMenuItem maquinasToolStripMenuItem;
        private ToolStripMenuItem materialesToolStripMenuItem;
        private ToolStripMenuItem actividadesToolStripMenuItem;
        private ToolStripMenuItem clasesToolStripMenuItem;
        private ToolStripMenuItem inscripcionesToolStripMenuItem;
        private ToolStripMenuItem administradoresToolStripMenuItem;
        private ToolStripMenuItem mantenimientosToolStripMenuItem;
        private ToolStripMenuItem historicoSueldosToolStripMenuItem;
    }
}

        #endregion