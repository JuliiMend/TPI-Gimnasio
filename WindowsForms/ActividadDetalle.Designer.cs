namespace WindowsFormsApp
{
    partial class ActividadDetalle
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
            lblTipo = new Label();
            txtTipo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DE LA ACTIVIDAD";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTipo.Location = new Point(18, 63);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(46, 21);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "Tipo:";
            //
            // txtTipo
            //
            txtTipo.Location = new Point(130, 65);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(220, 23);
            txtTipo.TabIndex = 2;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescripcion.Location = new Point(18, 105);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(104, 21);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(130, 107);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(220, 23);
            txtDescripcion.TabIndex = 4;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(247, 150);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // ActividadDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 211);
            Controls.Add(btnGuardar);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtTipo);
            Controls.Add(lblTipo);
            Controls.Add(lblTitulo);
            Name = "ActividadDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Actividad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblTipo;
        private TextBox txtTipo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
    }
}
