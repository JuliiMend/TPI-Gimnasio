namespace WindowsFormsApp
{
    partial class UsuarioDetalle
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblAyudaPassword = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL USUARIO";
            //
            // lblUsername
            //
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUsername.Location = new Point(18, 63);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 21);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Usuario:";
            //
            // txtUsername
            //
            txtUsername.Location = new Point(130, 65);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 23);
            txtUsername.TabIndex = 2;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.Location = new Point(18, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 21);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(130, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 4;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassword.Location = new Point(18, 147);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 21);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña:";
            //
            // txtPassword
            //
            txtPassword.Location = new Point(130, 149);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            //
            // lblAyudaPassword
            //
            lblAyudaPassword.AutoSize = true;
            lblAyudaPassword.ForeColor = SystemColors.GrayText;
            lblAyudaPassword.Location = new Point(130, 175);
            lblAyudaPassword.Name = "lblAyudaPassword";
            lblAyudaPassword.Size = new Size(210, 15);
            lblAyudaPassword.TabIndex = 7;
            lblAyudaPassword.Text = "Dejala vacía para mantener la actual.";
            lblAyudaPassword.Visible = false;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(247, 205);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // UsuarioDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(btnGuardar);
            Controls.Add(lblAyudaPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitulo);
            Name = "UsuarioDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblAyudaPassword;
        private Button btnGuardar;
    }
}
