namespace WindowsFormsApp
{
    partial class ProfesorLista
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
            dgvProfesores = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colCargo = new DataGridViewTextBoxColumn();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(319, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(144, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE PROFESORES";
            // 
            // dgvProfesores
            // 
            dgvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesores.Columns.AddRange(new DataGridViewColumn[] { colId, colDni, colNombre, colApellido, colEmail, colCargo });
            dgvProfesores.Location = new Point(88, 78);
            dgvProfesores.Name = "dgvProfesores";
            dgvProfesores.Size = new Size(641, 150);
            dgvProfesores.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "IdPersona";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colDni
            // 
            colDni.DataPropertyName = "Dni";
            colDni.HeaderText = "DNI";
            colDni.Name = "colDni";
            colDni.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colCargo
            // 
            colCargo.DataPropertyName = "Cargo";
            colCargo.HeaderText = "Cargo";
            colCargo.Name = "colCargo";
            colCargo.ReadOnly = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(177, 264);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(388, 264);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(593, 264);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // ProfesorLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvProfesores);
            Controls.Add(lblTitulo);
            Name = "ProfesorLista";
            Text = "ProfesorLista";
            Load += ProfesorLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvProfesores;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colCargo;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
    }
}