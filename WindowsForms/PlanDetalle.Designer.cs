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
            label1 = new Label();
            lblDni = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // Nombre
            // 
            Nombre.Location = new Point(148, 53);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(134, 23);
            Nombre.TabIndex = 0;
            // 
            // Tipo
            // 
            Tipo.Location = new Point(148, 94);
            Tipo.Name = "Tipo";
            Tipo.Size = new Size(134, 23);
            Tipo.TabIndex = 1;
            // 
            // Precio
            // 
            Precio.Location = new Point(148, 136);
            Precio.Name = "Precio";
            Precio.Size = new Size(134, 23);
            Precio.TabIndex = 3;
            // 
            // Descripcion
            // 
            Descripcion.Location = new Point(148, 178);
            Descripcion.Name = "Descripcion";
            Descripcion.Size = new Size(134, 23);
            Descripcion.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 22);
            label1.TabIndex = 6;
            label1.Text = "DATOS DEL PLAN";
            label1.Click += label1_Click;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDni.Location = new Point(12, 51);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(115, 21);
            lblDni.TabIndex = 7;
            lblDni.Text = "Nombre plan:";
            lblDni.Click += lblDni_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 8;
            label2.Text = "Tipo de plan:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(12, 138);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 9;
            label3.Text = "Precio:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(12, 180);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 10;
            label4.Text = "Descripcion:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(179, 245);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // PlanDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblDni);
            Controls.Add(label1);
            Controls.Add(Descripcion);
            Controls.Add(Precio);
            Controls.Add(Tipo);
            Controls.Add(Nombre);
            Name = "PlanDetalle";
            RightToLeft = RightToLeft.No;
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
        private Label label1;
        private Label lblDni;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGuardar;
    }

}
