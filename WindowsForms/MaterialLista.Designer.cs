namespace WindowsFormsApp
{
    partial class MaterialLista
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
            dgvMateriales = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            lblOpciones = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(185, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Materiales";
            // 
            // dgvMateriales
            // 
            dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriales.AutoGenerateColumns = false;
            dgvMateriales.Columns.AddRange(new DataGridViewColumn[] { colId, colDescripcion, colStock });
            dgvMateriales.Location = new Point(12, 46);
            dgvMateriales.Name = "dgvMateriales";
            dgvMateriales.Size = new Size(443, 150);
            dgvMateriales.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "IdMaterial";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // lblOpciones
            // 
            lblOpciones.AutoSize = true;
            lblOpciones.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblOpciones.Location = new Point(12, 208);
            lblOpciones.Name = "lblOpciones";
            lblOpciones.Size = new Size(91, 22);
            lblOpciones.TabIndex = 5;
            lblOpciones.Text = "Opciones:";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightBlue;
            btnNuevo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(12, 240);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(154, 35);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.MediumSeaGreen;
            btnModificar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(12, 281);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 35);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(12, 322);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(154, 35);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // MaterialLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvMateriales);
            Controls.Add(lblTitulo);
            Name = "MaterialLista";
            Text = "MaterialLista";
            Load += MaterialLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMateriales;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colStock;
        private Label lblOpciones;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
    }
}
