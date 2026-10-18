namespace WindowsFormsApp
{
    partial class ClaseLista
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
            dgvClases = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colActividad = new DataGridViewTextBoxColumn();
            colProfesor = new DataGridViewTextBoxColumn();
            colTurno = new DataGridViewTextBoxColumn();
            colCupo = new DataGridViewTextBoxColumn();
            colInscriptos = new DataGridViewTextBoxColumn();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            lblOpciones = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClases).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(195, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de clases";
            // 
            // dgvClases
            // 
            dgvClases.AllowUserToAddRows = false;
            dgvClases.AutoGenerateColumns = false;
            dgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClases.Columns.AddRange(new DataGridViewColumn[] { colId, colActividad, colProfesor, colTurno, colCupo, colInscriptos });
            dgvClases.Location = new Point(12, 45);
            dgvClases.MultiSelect = false;
            dgvClases.Name = "dgvClases";
            dgvClases.ReadOnly = true;
            dgvClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClases.Size = new Size(760, 150);
            dgvClases.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "IdClase";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colActividad
            // 
            colActividad.DataPropertyName = "Actividad";
            colActividad.HeaderText = "Actividad";
            colActividad.Name = "colActividad";
            colActividad.ReadOnly = true;
            // 
            // colProfesor
            // 
            colProfesor.DataPropertyName = "Profesor";
            colProfesor.HeaderText = "Profesor";
            colProfesor.Name = "colProfesor";
            colProfesor.ReadOnly = true;
            // 
            // colTurno
            // 
            colTurno.DataPropertyName = "Turno";
            colTurno.HeaderText = "Turno";
            colTurno.Name = "colTurno";
            colTurno.ReadOnly = true;
            // 
            // colCupo
            // 
            colCupo.DataPropertyName = "Cupo";
            colCupo.HeaderText = "Cupo";
            colCupo.Name = "colCupo";
            colCupo.ReadOnly = true;
            // 
            // colInscriptos
            // 
            colInscriptos.DataPropertyName = "Inscriptos";
            colInscriptos.HeaderText = "Inscriptos";
            colInscriptos.Name = "colInscriptos";
            colInscriptos.ReadOnly = true;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(12, 321);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(154, 35);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.MediumSeaGreen;
            btnModificar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(12, 280);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 35);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightBlue;
            btnNuevo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(12, 239);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(154, 35);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblOpciones
            // 
            lblOpciones.AutoSize = true;
            lblOpciones.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblOpciones.Location = new Point(12, 207);
            lblOpciones.Name = "lblOpciones";
            lblOpciones.Size = new Size(91, 22);
            lblOpciones.TabIndex = 2;
            lblOpciones.Text = "Opciones:";
            // 
            // ClaseLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvClases);
            Controls.Add(lblTitulo);
            Name = "ClaseLista";
            Text = "Gestión de clases";
            Load += ClaseLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvClases;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colActividad;
        private DataGridViewTextBoxColumn colProfesor;
        private DataGridViewTextBoxColumn colTurno;
        private DataGridViewTextBoxColumn colCupo;
        private DataGridViewTextBoxColumn colInscriptos;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private Label lblOpciones;
    }
}
