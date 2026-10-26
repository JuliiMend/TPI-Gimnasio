namespace WindowsFormsApp
{
    partial class HistoricoSueldoDetalle
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
            lblProfesor = new Label();
            cmbProfesor = new ComboBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblValor = new Label();
            numValor = new NumericUpDown();
            btnRegistrar = new Button();
            ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(170, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVO SUELDO";
            //
            // lblProfesor
            //
            lblProfesor.AutoSize = true;
            lblProfesor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfesor.Location = new Point(18, 63);
            lblProfesor.Name = "lblProfesor";
            lblProfesor.Size = new Size(80, 21);
            lblProfesor.TabIndex = 1;
            lblProfesor.Text = "Profesor:";
            //
            // cmbProfesor
            //
            cmbProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfesor.Location = new Point(140, 65);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(250, 23);
            cmbProfesor.TabIndex = 2;
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDesde.Location = new Point(18, 105);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(116, 21);
            lblDesde.TabIndex = 3;
            lblDesde.Text = "Vigente desde:";
            //
            // dtpDesde
            //
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(140, 107);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(140, 23);
            dtpDesde.TabIndex = 4;
            //
            // lblValor
            //
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblValor.Location = new Point(18, 147);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(52, 21);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor:";
            //
            // numValor
            //
            numValor.DecimalPlaces = 2;
            numValor.Location = new Point(140, 149);
            numValor.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numValor.Name = "numValor";
            numValor.Size = new Size(140, 23);
            numValor.TabIndex = 6;
            numValor.ThousandsSeparator = true;
            //
            // btnRegistrar
            //
            btnRegistrar.BackColor = Color.LightBlue;
            btnRegistrar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(287, 195);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(103, 32);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // HistoricoSueldoDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 251);
            Controls.Add(btnRegistrar);
            Controls.Add(numValor);
            Controls.Add(lblValor);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Controls.Add(cmbProfesor);
            Controls.Add(lblProfesor);
            Controls.Add(lblTitulo);
            Name = "HistoricoSueldoDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar sueldo";
            Load += HistoricoSueldoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProfesor;
        private ComboBox cmbProfesor;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblValor;
        private NumericUpDown numValor;
        private Button btnRegistrar;
    }
}
