namespace WindowsFormsApp
{
    partial class ReporteOcupacionClases
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
            lblResumen = new Label();
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            dgvOcupacion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOcupacion).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(290, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de ocupación de clases";
            //
            // lblResumen
            //
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResumen.Location = new Point(12, 42);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(0, 19);
            lblResumen.TabIndex = 1;
            //
            // formsPlot
            //
            formsPlot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot.DisplayScale = 1F;
            formsPlot.Location = new Point(12, 70);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(860, 300);
            formsPlot.TabIndex = 2;
            //
            // dgvOcupacion
            //
            dgvOcupacion.AllowUserToAddRows = false;
            dgvOcupacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOcupacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOcupacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOcupacion.Location = new Point(12, 380);
            dgvOcupacion.Name = "dgvOcupacion";
            dgvOcupacion.ReadOnly = true;
            dgvOcupacion.RowHeadersVisible = false;
            dgvOcupacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOcupacion.Size = new Size(860, 170);
            dgvOcupacion.TabIndex = 3;
            //
            // ReporteOcupacionClases
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvOcupacion);
            Controls.Add(formsPlot);
            Controls.Add(lblResumen);
            Controls.Add(lblTitulo);
            Name = "ReporteOcupacionClases";
            Text = "Reporte de ocupación de clases";
            Load += ReporteOcupacionClases_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOcupacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblResumen;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private DataGridView dgvOcupacion;
    }
}
