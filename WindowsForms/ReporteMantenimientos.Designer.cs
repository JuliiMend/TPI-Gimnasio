namespace WindowsFormsApp
{
    partial class ReporteMantenimientos
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
            lblTitulo = new Label();
            lblMaquina = new Label();
            cmbFiltroMaquina = new ComboBox();
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            dgvResumen = new DataGridView();
            lblDetalle = new Label();
            dgvDetalle = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(350, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de mantenimiento de máquinas";
            //
            // lblMaquina
            //
            lblMaquina.AutoSize = true;
            lblMaquina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaquina.Location = new Point(12, 48);
            lblMaquina.Name = "lblMaquina";
            lblMaquina.Size = new Size(68, 19);
            lblMaquina.TabIndex = 1;
            lblMaquina.Text = "Máquina:";
            //
            // cmbFiltroMaquina
            //
            cmbFiltroMaquina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroMaquina.Location = new Point(90, 46);
            cmbFiltroMaquina.Name = "cmbFiltroMaquina";
            cmbFiltroMaquina.Size = new Size(250, 23);
            cmbFiltroMaquina.TabIndex = 2;
            cmbFiltroMaquina.SelectionChangeCommitted += cmbFiltroMaquina_SelectionChangeCommitted;
            //
            // formsPlot
            //
            formsPlot.DisplayScale = 1F;
            formsPlot.Location = new Point(12, 80);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(470, 280);
            formsPlot.TabIndex = 3;
            //
            // dgvResumen
            //
            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.Location = new Point(500, 80);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.ReadOnly = true;
            dgvResumen.RowHeadersVisible = false;
            dgvResumen.Size = new Size(372, 180);
            dgvResumen.TabIndex = 4;
            //
            // lblDetalle
            //
            lblDetalle.AutoSize = true;
            lblDetalle.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lblDetalle.Location = new Point(12, 370);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(65, 20);
            lblDetalle.TabIndex = 5;
            lblDetalle.Text = "Detalle";
            //
            // dgvDetalle
            //
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 395);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(860, 155);
            dgvDetalle.TabIndex = 6;
            //
            // ReporteMantenimientos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvDetalle);
            Controls.Add(lblDetalle);
            Controls.Add(dgvResumen);
            Controls.Add(formsPlot);
            Controls.Add(cmbFiltroMaquina);
            Controls.Add(lblMaquina);
            Controls.Add(lblTitulo);
            Name = "ReporteMantenimientos";
            Text = "Reporte de mantenimiento de máquinas";
            Load += ReporteMantenimientos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMaquina;
        private ComboBox cmbFiltroMaquina;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private DataGridView dgvResumen;
        private Label lblDetalle;
        private DataGridView dgvDetalle;
    }
}
