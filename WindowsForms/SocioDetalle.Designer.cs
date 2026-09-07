namespace WindowsFormsApp
{
    partial class SocioDetalle
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
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNac = new DateTimePicker();
            dtpFechaAlta = new DateTimePicker();
            cmbPlanes = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dtpFechaBaja = new DateTimePicker();
            lblDni = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblFechaNac = new Label();
            lblFechaAlta = new Label();
            lblFechaBaja = new Label();
            lblPlan = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(355, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(87, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Datos del socio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(342, 129);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(342, 95);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 4;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(342, 63);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(342, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(342, 195);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 10;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(342, 243);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(200, 23);
            dtpFechaNac.TabIndex = 12;
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Location = new Point(342, 287);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(200, 23);
            dtpFechaAlta.TabIndex = 14;
            // 
            // cmbPlanes
            // 
            cmbPlanes.FormattingEnabled = true;
            cmbPlanes.Location = new Point(342, 363);
            cmbPlanes.Name = "cmbPlanes";
            cmbPlanes.Size = new Size(121, 23);
            cmbPlanes.TabIndex = 18;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(241, 402);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(388, 402);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Location = new Point(342, 330);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.ShowCheckBox = true;
            dtpFechaBaja.Size = new Size(200, 23);
            dtpFechaBaja.TabIndex = 16;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(210, 66);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(210, 95);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(210, 132);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(57, 15);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "Apellido: ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(210, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(210, 203);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(210, 249);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(106, 15);
            lblFechaNac.TabIndex = 11;
            lblFechaNac.Text = "Fecha Nacimiento:";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(210, 293);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(65, 15);
            lblFechaAlta.TabIndex = 13;
            lblFechaAlta.Text = "Fecha Alta:";
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(210, 338);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(66, 15);
            lblFechaBaja.TabIndex = 15;
            lblFechaBaja.Text = "Fecha Baja:";
            // 
            // lblPlan
            // 
            lblPlan.AutoSize = true;
            lblPlan.Location = new Point(210, 366);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(33, 15);
            lblPlan.TabIndex = 17;
            lblPlan.Text = "Plan:";
            // 
            // SocioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPlan);
            Controls.Add(lblFechaBaja);
            Controls.Add(lblFechaAlta);
            Controls.Add(lblFechaNac);
            Controls.Add(lblTelefono);
            Controls.Add(lblEmail);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblDni);
            Controls.Add(dtpFechaBaja);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbPlanes);
            Controls.Add(dtpFechaAlta);
            Controls.Add(dtpFechaNac);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Name = "SocioDetalle";
            Text = "SocioDetalle";
            Load += SocioDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNac;
        private DateTimePicker dtpFechaAlta;
        private ComboBox cmbPlanes;
        private Button btnGuardar;
        private Button btnCancelar;
        private DateTimePicker dtpFechaBaja;
        private Label lblDni;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblFechaNac;
        private Label lblFechaAlta;
        private Label lblFechaBaja;
        private Label lblPlan;
    }
}