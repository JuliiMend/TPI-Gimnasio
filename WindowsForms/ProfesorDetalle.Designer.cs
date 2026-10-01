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
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(218, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL PROFESOR";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDni.Location = new Point(18, 63);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(44, 21);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(116, 65);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(18, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 21);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApellido.Location = new Point(18, 152);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 21);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(116, 107);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(116, 154);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.Location = new Point(18, 198);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 21);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTelefono.Location = new Point(16, 244);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(81, 21);
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Telefono:";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFechaNac.Location = new Point(16, 290);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(92, 21);
            lblFechaNac.TabIndex = 9;
            lblFechaNac.Text = "Fecha Nac:";
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCargo.Location = new Point(18, 339);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(59, 21);
            lblCargo.TabIndex = 10;
            lblCargo.Text = "Cargo:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(116, 200);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(116, 247);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 12;
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(116, 337);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(100, 23);
            txtCargo.TabIndex = 14;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(116, 290);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(200, 23);
            dtpFechaNac.TabIndex = 15;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightBlue;
            btnLogin.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(213, 387);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 32);
            btnLogin.TabIndex = 16;
            btnLogin.Text = "Guardar";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // ProfesorDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
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
        private Button btnLogin;
    }
}