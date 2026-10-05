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
            cmbDia = new ComboBox();
            lblHoraDesde = new Label();
            dtpHoraDesde = new DateTimePicker();
            dtpHoraHasta = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(185, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL TURNO";
            // 
            // cmbDia
            // 
            cmbDia.FormattingEnabled = true;
            cmbDia.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
            cmbDia.Location = new Point(147, 62);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(121, 23);
            cmbDia.TabIndex = 2;
            // 
            // lblHoraDesde
            // 
            lblHoraDesde.AutoSize = true;
            lblHoraDesde.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHoraDesde.Location = new Point(15, 101);
            lblHoraDesde.Name = "lblHoraDesde";
            lblHoraDesde.Size = new Size(102, 21);
            lblHoraDesde.TabIndex = 3;
            lblHoraDesde.Text = "Hora Desde:";
            // 
            // dtpHoraDesde
            // 
            dtpHoraDesde.Format = DateTimePickerFormat.Time;
            dtpHoraDesde.Location = new Point(147, 101);
            dtpHoraDesde.Name = "dtpHoraDesde";
            dtpHoraDesde.ShowUpDown = true;
            dtpHoraDesde.Size = new Size(200, 23);
            dtpHoraDesde.TabIndex = 4;
            // 
            // dtpHoraHasta
            // 
            dtpHoraHasta.Format = DateTimePickerFormat.Time;
            dtpHoraHasta.Location = new Point(147, 149);
            dtpHoraHasta.Name = "dtpHoraHasta";
            dtpHoraHasta.ShowUpDown = true;
            dtpHoraHasta.Size = new Size(200, 23);
            dtpHoraHasta.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(15, 149);
            label2.Name = "label2";
            label2.Size = new Size(98, 21);
            label2.TabIndex = 9;
            label2.Text = "Hora Hasta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(15, 60);
            label1.Name = "label1";
            label1.Size = new Size(126, 21);
            label1.TabIndex = 10;
            label1.Text = "Dia de semana:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightBlue;
            btnLogin.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(244, 195);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 32);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Guardar";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // TurnoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dtpHoraHasta);
            Controls.Add(dtpHoraDesde);
            Controls.Add(lblHoraDesde);
            Controls.Add(cmbDia);
            Controls.Add(lblTitulo);
            Name = "TurnoDetalle";
            Text = "TurnoDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ComboBox cmbDia;
        private Label lblHoraDesde;
        private DateTimePicker dtpHoraDesde;
        private DateTimePicker dtpHoraHasta;
        private Label label2;
        private Label label1;
        private Button btnLogin;
    }
}