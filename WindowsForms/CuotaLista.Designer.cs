namespace WindowsFormsApp
{
    partial class CuotaLista
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
            dgv_cuotas = new DataGridView();
            btn_agregar = new Button();
            btn_actualizar = new Button();
            btn_eliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_cuotas).BeginInit();
            SuspendLayout();
            // 
            // dgv_cuotas
            // 
            dgv_cuotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cuotas.Location = new Point(12, 66);
            dgv_cuotas.Name = "dgv_cuotas";
            dgv_cuotas.Size = new Size(732, 361);
            dgv_cuotas.TabIndex = 0;
            // 
            // btn_agregar
            // 
            btn_agregar.Location = new Point(12, 25);
            btn_agregar.Name = "btn_agregar";
            btn_agregar.Size = new Size(75, 23);
            btn_agregar.TabIndex = 1;
            btn_agregar.Text = "Agregar";
            btn_agregar.UseVisualStyleBackColor = true;
            // 
            // btn_actualizar
            // 
            btn_actualizar.Location = new Point(93, 25);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(75, 23);
            btn_actualizar.TabIndex = 2;
            btn_actualizar.Text = "Actualizar";
            btn_actualizar.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new Point(174, 25);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(75, 23);
            btn_eliminar.TabIndex = 3;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // CuotaLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_actualizar);
            Controls.Add(btn_agregar);
            Controls.Add(dgv_cuotas);
            Name = "CuotaLista";
            Text = "CuotaLista";
            Load += CuotaLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_cuotas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_cuotas;
        private Button btn_agregar;
        private Button btn_actualizar;
        private Button btn_eliminar;
    }
}