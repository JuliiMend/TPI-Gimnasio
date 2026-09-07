namespace WindowsFormsApp
{
    partial class ProfesorDetalle
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
            lblDni = new Label();
            txtDni = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblFechaNac = new Label();
            lblCargo = new Label();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtCargo = new TextBox();
            dtpFechaNac = new DateTimePicker();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(310, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(125, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL PROFESOR";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(202, 64);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(335, 61);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(202, 120);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(202, 183);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(335, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(335, 183);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(202, 229);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(200, 275);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Telefono:";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(204, 323);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(122, 15);
            lblFechaNac.TabIndex = 9;
            lblFechaNac.Text = "Fecha de Nacimiento:";
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(202, 370);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(42, 15);
            lblCargo.TabIndex = 10;
            lblCargo.Text = "Cargo:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(335, 229);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(335, 272);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 12;
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(335, 362);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(100, 23);
            txtCargo.TabIndex = 14;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(335, 315);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(200, 23);
            dtpFechaNac.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(603, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // ProfesorDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFechaNac);
            Controls.Add(txtCargo);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(lblCargo);
            Controls.Add(lblFechaNac);
            Controls.Add(lblTelefono);
            Controls.Add(lblEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(lblTitulo);
            Name = "ProfesorDetalle";
            Text = "ProfesorDetalle";
            Load += ProfesorDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblNombre;
        private Label lblApellido;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblFechaNac;
        private Label lblCargo;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtCargo;
        private DateTimePicker dtpFechaNac;
        private Button btnGuardar;
    }
}