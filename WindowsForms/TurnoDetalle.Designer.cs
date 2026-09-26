namespace WindowsFormsApp
{
    partial class TurnoDetalle
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
            lblDia = new Label();
            cmbDia = new ComboBox();
            lblHoraDesde = new Label();
            dtpHoraDesde = new DateTimePicker();
            lblHoraHasta = new Label();
            dtpHoraHasta = new DateTimePicker();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(348, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(109, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL TURNO";
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Location = new Point(291, 97);
            lblDia.Name = "lblDia";
            lblDia.Size = new Size(87, 15);
            lblDia.TabIndex = 1;
            lblDia.Text = "Dia de semana:";
            // 
            // cmbDia
            // 
            cmbDia.FormattingEnabled = true;
            cmbDia.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
            cmbDia.Location = new Point(419, 89);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(121, 23);
            cmbDia.TabIndex = 2;
            // 
            // lblHoraDesde
            // 
            lblHoraDesde.AutoSize = true;
            lblHoraDesde.Location = new Point(291, 138);
            lblHoraDesde.Name = "lblHoraDesde";
            lblHoraDesde.Size = new Size(71, 15);
            lblHoraDesde.TabIndex = 3;
            lblHoraDesde.Text = "Hora Desde:";
            // 
            // dtpHoraDesde
            // 
            dtpHoraDesde.Format = DateTimePickerFormat.Time;
            dtpHoraDesde.Location = new Point(392, 138);
            dtpHoraDesde.Name = "dtpHoraDesde";
            dtpHoraDesde.ShowUpDown = true;
            dtpHoraDesde.Size = new Size(200, 23);
            dtpHoraDesde.TabIndex = 4;
            // 
            // lblHoraHasta
            // 
            lblHoraHasta.AutoSize = true;
            lblHoraHasta.Location = new Point(291, 200);
            lblHoraHasta.Name = "lblHoraHasta";
            lblHoraHasta.Size = new Size(69, 15);
            lblHoraHasta.TabIndex = 5;
            lblHoraHasta.Text = "Hora Hasta:";
            // 
            // dtpHoraHasta
            // 
            dtpHoraHasta.Format = DateTimePickerFormat.Time;
            dtpHoraHasta.Location = new Point(392, 194);
            dtpHoraHasta.Name = "dtpHoraHasta";
            dtpHoraHasta.ShowUpDown = true;
            dtpHoraHasta.Size = new Size(200, 23);
            dtpHoraHasta.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(452, 273);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // TurnoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dtpHoraHasta);
            Controls.Add(lblHoraHasta);
            Controls.Add(dtpHoraDesde);
            Controls.Add(lblHoraDesde);
            Controls.Add(cmbDia);
            Controls.Add(lblDia);
            Controls.Add(lblTitulo);
            Name = "TurnoDetalle";
            Text = "TurnoDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDia;
        private ComboBox cmbDia;
        private Label lblHoraDesde;
        private DateTimePicker dtpHoraDesde;
        private Label lblHoraHasta;
        private DateTimePicker dtpHoraHasta;
        private Button btnGuardar;
    }
}