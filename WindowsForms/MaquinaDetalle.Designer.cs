namespace WindowsFormsApp
{
    partial class MaquinaDetalle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblTipo = new Label();
            txtTipo = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DE LA MÁQUINA";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(15, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(90, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(147, 62);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescripcion.Location = new Point(15, 101);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(120, 21);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(147, 101);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 4;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTipo.Location = new Point(15, 149);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(60, 21);
            lblTipo.TabIndex = 5;
            lblTipo.Text = "Tipo:";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(147, 149);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(200, 23);
            txtTipo.TabIndex = 6;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstado.Location = new Point(15, 197);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(80, 21);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Operativa", "En mantenimiento", "Fuera de servicio" });
            cmbEstado.Location = new Point(147, 197);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(244, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // MaquinaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 320);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(txtTipo);
            Controls.Add(lblTipo);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Name = "MaquinaDetalle";
            Text = "MaquinaDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblTipo;
        private TextBox txtTipo;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnGuardar;
    }
}
