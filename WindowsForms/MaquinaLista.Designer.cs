namespace WindowsFormsApp
{
    partial class MaquinaLista
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
            dgvMaquinas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            lblOpciones = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMaquinas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Máquinas";
            // 
            // dgvMaquinas
            // 
            dgvMaquinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaquinas.AutoGenerateColumns = false;
            dgvMaquinas.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion, colTipo, colEstado });
            dgvMaquinas.Location = new Point(12, 46);
            dgvMaquinas.Name = "dgvMaquinas";
            dgvMaquinas.Size = new Size(650, 150);
            dgvMaquinas.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "IdMaquina";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
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
            // MaquinaLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvMaquinas);
            Controls.Add(lblTitulo);
            Name = "MaquinaLista";
            Text = "MaquinaLista";
            Load += MaquinaLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaquinas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMaquinas;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colEstado;
        private Label lblOpciones;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
    }
}
