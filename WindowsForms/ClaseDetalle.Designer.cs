namespace WindowsFormsApp
{
    partial class ClaseDetalle
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
            lblActividad = new Label();
            cmbActividad = new ComboBox();
            lblProfesor = new Label();
            cmbProfesor = new ComboBox();
            lblTurno = new Label();
            cmbTurno = new ComboBox();
            lblCupo = new Label();
            numCupo = new NumericUpDown();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)numCupo).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(196, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DE LA CLASE";
            //
            // lblActividad
            //
            lblActividad.AutoSize = true;
            lblActividad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblActividad.Location = new Point(18, 63);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(87, 21);
            lblActividad.TabIndex = 1;
            lblActividad.Text = "Actividad:";
            //
            // cmbActividad
            //
            cmbActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActividad.Location = new Point(130, 65);
            cmbActividad.Name = "cmbActividad";
            cmbActividad.Size = new Size(240, 23);
            cmbActividad.TabIndex = 2;
            //
            // lblProfesor
            //
            lblProfesor.AutoSize = true;
            lblProfesor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfesor.Location = new Point(18, 105);
            lblProfesor.Name = "lblProfesor";
            lblProfesor.Size = new Size(80, 21);
            lblProfesor.TabIndex = 3;
            lblProfesor.Text = "Profesor:";
            //
            // cmbProfesor
            //
            cmbProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfesor.Location = new Point(130, 107);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(240, 23);
            cmbProfesor.TabIndex = 4;
            //
            // lblTurno
            //
            lblTurno.AutoSize = true;
            lblTurno.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTurno.Location = new Point(18, 147);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(59, 21);
            lblTurno.TabIndex = 5;
            lblTurno.Text = "Turno:";
            //
            // cmbTurno
            //
            cmbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTurno.Location = new Point(130, 149);
            cmbTurno.Name = "cmbTurno";
            cmbTurno.Size = new Size(240, 23);
            cmbTurno.TabIndex = 6;
            //
            // lblCupo
            //
            lblCupo.AutoSize = true;
            lblCupo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCupo.Location = new Point(18, 189);
            lblCupo.Name = "lblCupo";
            lblCupo.Size = new Size(54, 21);
            lblCupo.TabIndex = 7;
            lblCupo.Text = "Cupo:";
            //
            // numCupo
            //
            numCupo.Location = new Point(130, 191);
            numCupo.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCupo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCupo.Name = "numCupo";
            numCupo.Size = new Size(100, 23);
            numCupo.TabIndex = 8;
            numCupo.Value = new decimal(new int[] { 20, 0, 0, 0 });
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(267, 235);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // ClaseDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 291);
            Controls.Add(btnGuardar);
            Controls.Add(numCupo);
            Controls.Add(lblCupo);
            Controls.Add(cmbTurno);
            Controls.Add(lblTurno);
            Controls.Add(cmbProfesor);
            Controls.Add(lblProfesor);
            Controls.Add(cmbActividad);
            Controls.Add(lblActividad);
            Controls.Add(lblTitulo);
            Name = "ClaseDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clase";
            Load += ClaseDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)numCupo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblActividad;
        private ComboBox cmbActividad;
        private Label lblProfesor;
        private ComboBox cmbProfesor;
        private Label lblTurno;
        private ComboBox cmbTurno;
        private Label lblCupo;
        private NumericUpDown numCupo;
        private Button btnGuardar;
    }
}
