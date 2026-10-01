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
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(177, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL SOCIO";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 126);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(150, 89);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 4;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(150, 60);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 23);
            txtDni.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 159);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(150, 197);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 10;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(150, 235);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(200, 23);
            dtpFechaNac.TabIndex = 12;
            dtpFechaNac.ValueChanged += dtpFechaNac_ValueChanged;
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Location = new Point(150, 277);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(200, 23);
            dtpFechaAlta.TabIndex = 14;
            // 
            // cmbPlanes
            // 
            cmbPlanes.FormattingEnabled = true;
            cmbPlanes.Location = new Point(150, 372);
            cmbPlanes.Name = "cmbPlanes";
            cmbPlanes.Size = new Size(121, 23);
            cmbPlanes.TabIndex = 18;
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Location = new Point(150, 322);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.ShowCheckBox = true;
            dtpFechaBaja.Size = new Size(200, 23);
            dtpFechaBaja.TabIndex = 16;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 12F);
            lblDni.Location = new Point(18, 58);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(40, 21);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(18, 87);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F);
            lblApellido.Location = new Point(18, 124);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(74, 21);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "Apellido: ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(18, 157);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(18, 195);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Font = new Font("Segoe UI", 11.5F);
            lblFechaNac.Location = new Point(18, 235);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(84, 21);
            lblFechaNac.TabIndex = 11;
            lblFechaNac.Text = "Fecha Nac:";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Font = new Font("Segoe UI", 12F);
            lblFechaAlta.Location = new Point(18, 285);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(84, 21);
            lblFechaAlta.TabIndex = 13;
            lblFechaAlta.Text = "Fecha Alta:";
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Font = new Font("Segoe UI", 12F);
            lblFechaBaja.Location = new Point(18, 330);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(86, 21);
            lblFechaBaja.TabIndex = 15;
            lblFechaBaja.Text = "Fecha Baja:";
            // 
            // lblPlan
            // 
            lblPlan.AutoSize = true;
            lblPlan.Font = new Font("Segoe UI", 12F);
            lblPlan.Location = new Point(18, 375);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(43, 21);
            lblPlan.TabIndex = 17;
            lblPlan.Text = "Plan:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(269, 410);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(81, 30);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCancelar.Location = new Point(182, 410);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 30);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // SocioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
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
        private Button btnGuardar;
        private Button btnCancelar;
    }
}