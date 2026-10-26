namespace WindowsFormsApp
{
    partial class InscripcionDetalle
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
            lblSocio = new Label();
            cmbSocio = new ComboBox();
            lblClase = new Label();
            cmbClase = new ComboBox();
            btnInscribir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(190, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVA INSCRIPCIÓN";
            //
            // lblSocio
            //
            lblSocio.AutoSize = true;
            lblSocio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSocio.Location = new Point(18, 63);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(55, 21);
            lblSocio.TabIndex = 1;
            lblSocio.Text = "Socio:";
            //
            // cmbSocio
            //
            cmbSocio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSocio.Location = new Point(100, 65);
            cmbSocio.Name = "cmbSocio";
            cmbSocio.Size = new Size(340, 23);
            cmbSocio.TabIndex = 2;
            //
            // lblClase
            //
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClase.Location = new Point(18, 105);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(54, 21);
            lblClase.TabIndex = 3;
            lblClase.Text = "Clase:";
            //
            // cmbClase
            //
            cmbClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClase.Location = new Point(100, 107);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(340, 23);
            cmbClase.TabIndex = 4;
            //
            // btnInscribir
            //
            btnInscribir.BackColor = Color.LightBlue;
            btnInscribir.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInscribir.Location = new Point(337, 150);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(103, 32);
            btnInscribir.TabIndex = 5;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            //
            // InscripcionDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 211);
            Controls.Add(btnInscribir);
            Controls.Add(cmbClase);
            Controls.Add(lblClase);
            Controls.Add(cmbSocio);
            Controls.Add(lblSocio);
            Controls.Add(lblTitulo);
            Name = "InscripcionDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inscripción";
            Load += InscripcionDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSocio;
        private ComboBox cmbSocio;
        private Label lblClase;
        private ComboBox cmbClase;
        private Button btnInscribir;
    }
}
