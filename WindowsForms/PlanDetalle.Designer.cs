namespace WindowsFormsApp
{
    partial class PlanDetalle
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
            Nombre = new TextBox();
            Tipo = new TextBox();
            Precio = new TextBox();
            Descripcion = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // Nombre
            // 
            Nombre.Location = new Point(12, 40);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(319, 23);
            Nombre.TabIndex = 0;
            Nombre.Text = "Nombre del plan";
            // 
            // Tipo
            // 
            Tipo.Location = new Point(12, 81);
            Tipo.Name = "Tipo";
            Tipo.Size = new Size(319, 23);
            Tipo.TabIndex = 1;
            Tipo.Text = "Tipo de plan";
            // 
            // Precio
            // 
            Precio.Location = new Point(12, 125);
            Precio.Name = "Precio";
            Precio.Size = new Size(319, 23);
            Precio.TabIndex = 3;
            Precio.Text = "Precio x mes";
            // 
            // Descripcion
            // 
            Descripcion.Location = new Point(12, 165);
            Descripcion.Name = "Descripcion";
            Descripcion.Size = new Size(319, 23);
            Descripcion.TabIndex = 4;
            Descripcion.Text = "Descripcion";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(260, 219);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(71, 25);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar :)";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // PlanDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 349);
            Controls.Add(btnGuardar);
            Controls.Add(Descripcion);
            Controls.Add(Precio);
            Controls.Add(Tipo);
            Controls.Add(Nombre);
            Name = "PlanDetalle";
            Text = "PlanDetalle";
            Load += PlanDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Nombre;
        private TextBox Tipo;
        private TextBox Precio;
        private TextBox Descripcion;
        private Button btnGuardar;
    }

}
