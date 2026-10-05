namespace WindowsFormsApp
{
    partial class SocioLista
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
            dgvSocios = new DataGridView();
            lblTitulo = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(12, 44);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(443, 150);
            dgvSocios.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(159, 23);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Gestión de Socios";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(12, 323);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(154, 35);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.MediumSeaGreen;
            btnEditar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(12, 282);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(154, 35);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Modificar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightBlue;
            btnNuevo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(12, 241);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(154, 35);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 209);
            label1.Name = "label1";
            label1.Size = new Size(91, 22);
            label1.TabIndex = 9;
            label1.Text = "Opciones:";
            // 
            // SocioLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnNuevo);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            Controls.Add(dgvSocios);
            Name = "SocioLista";
            Text = "SocioLista";
            Load += SocioLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSocios;
        private Label lblTitulo;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private Label label1;
    }
}