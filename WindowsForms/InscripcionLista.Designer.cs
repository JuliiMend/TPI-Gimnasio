namespace WindowsFormsApp
{
    partial class InscripcionLista
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
            lblFiltro = new Label();
            cmbFiltroClase = new ComboBox();
            dgvInscripciones = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colSocio = new DataGridViewTextBoxColumn();
            colClase = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            btnCancelarInscripcion = new Button();
            btnNuevo = new Button();
            lblOpciones = new Label();
            paginador = new Paginador();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inscripciones a clases";
            //
            // lblFiltro
            //
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFiltro.Location = new Point(12, 48);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(116, 19);
            lblFiltro.TabIndex = 1;
            lblFiltro.Text = "Filtrar por clase:";
            //
            // cmbFiltroClase
            //
            cmbFiltroClase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroClase.Location = new Point(140, 46);
            cmbFiltroClase.Name = "cmbFiltroClase";
            cmbFiltroClase.Size = new Size(320, 23);
            cmbFiltroClase.TabIndex = 2;
            cmbFiltroClase.SelectionChangeCommitted += cmbFiltroClase_SelectionChangeCommitted;
            //
            // dgvInscripciones
            //
            dgvInscripciones.AllowUserToAddRows = false;
            dgvInscripciones.AutoGenerateColumns = false;
            dgvInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Columns.AddRange(new DataGridViewColumn[] { colId, colSocio, colClase, colFecha });
            dgvInscripciones.Location = new Point(12, 80);
            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscripciones.Size = new Size(760, 180);
            dgvInscripciones.TabIndex = 3;
            //
            // colId
            //
            colId.DataPropertyName = "IdInscripcion";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            //
            // colSocio
            //
            colSocio.DataPropertyName = "Socio";
            colSocio.HeaderText = "Socio";
            colSocio.Name = "colSocio";
            colSocio.ReadOnly = true;
            //
            // colClase
            //
            colClase.DataPropertyName = "Clase";
            colClase.HeaderText = "Clase";
            colClase.Name = "colClase";
            colClase.ReadOnly = true;
            //
            // colFecha
            //
            colFecha.DataPropertyName = "FechaInscripcion";
            colFecha.HeaderText = "Fecha de inscripción";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            //
            // lblOpciones
            //
            lblOpciones.AutoSize = true;
            lblOpciones.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblOpciones.Location = new Point(12, 308);
            lblOpciones.Name = "lblOpciones";
            lblOpciones.Size = new Size(91, 22);
            lblOpciones.TabIndex = 4;
            lblOpciones.Text = "Opciones:";
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.LightBlue;
            btnNuevo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(12, 340);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(200, 35);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nueva inscripción";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnCancelarInscripcion
            //
            btnCancelarInscripcion.BackColor = Color.Crimson;
            btnCancelarInscripcion.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarInscripcion.Location = new Point(12, 381);
            btnCancelarInscripcion.Name = "btnCancelarInscripcion";
            btnCancelarInscripcion.Size = new Size(200, 35);
            btnCancelarInscripcion.TabIndex = 6;
            btnCancelarInscripcion.Text = "Cancelar inscripción";
            btnCancelarInscripcion.UseVisualStyleBackColor = false;
            btnCancelarInscripcion.Click += btnCancelarInscripcion_Click;
            // 
            // paginador
            // 
            paginador.Location = new Point(12, 266);
            paginador.Name = "paginador";
            paginador.Size = new Size(422, 28);
            paginador.TabIndex = 20;
            paginador.PaginaCambiada += paginador_PaginaCambiada;
            //
            // InscripcionLista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(paginador);
            Controls.Add(btnCancelarInscripcion);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvInscripciones);
            Controls.Add(cmbFiltroClase);
            Controls.Add(lblFiltro);
            Controls.Add(lblTitulo);
            Name = "InscripcionLista";
            Text = "Inscripciones a clases";
            Load += InscripcionLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblFiltro;
        private ComboBox cmbFiltroClase;
        private DataGridView dgvInscripciones;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colSocio;
        private DataGridViewTextBoxColumn colClase;
        private DataGridViewTextBoxColumn colFecha;
        private Button btnCancelarInscripcion;
        private Button btnNuevo;
        private Label lblOpciones;
        private Paginador paginador;
    }
}
