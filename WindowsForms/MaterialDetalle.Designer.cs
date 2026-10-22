namespace WindowsFormsApp
{
    partial class MaterialDetalle
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
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblStock = new Label();
            numStock = new NumericUpDown();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(205, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL MATERIAL";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescripcion.Location = new Point(15, 60);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(120, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(147, 62);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStock.Location = new Point(15, 101);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(65, 21);
            lblStock.TabIndex = 3;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.Location = new Point(147, 101);
            numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 23);
            numStock.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(147, 149);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // MaterialDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 240);
            Controls.Add(btnGuardar);
            Controls.Add(numStock);
            Controls.Add(lblStock);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Name = "MaterialDetalle";
            Text = "MaterialDetalle";
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblStock;
        private NumericUpDown numStock;
        private Button btnGuardar;
    }
}
