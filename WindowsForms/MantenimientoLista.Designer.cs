namespace WindowsFormsApp
{
    partial class MantenimientoLista
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
            lblMaquina = new Label();
            cmbFiltroMaquina = new ComboBox();
            lblEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            dgvMantenimientos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colMaquina = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colInicio = new DataGridViewTextBoxColumn();
            colFinEsperada = new DataGridViewTextBoxColumn();
            colFinReal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colDiasDemora = new DataGridViewTextBoxColumn();
            lblOpciones = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            paginador = new Paginador();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de mantenimiento de máquinas";
            //
            // lblMaquina
            //
            lblMaquina.AutoSize = true;
            lblMaquina.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaquina.Location = new Point(12, 48);
            lblMaquina.Name = "lblMaquina";
            lblMaquina.Size = new Size(68, 19);
            lblMaquina.TabIndex = 1;
            lblMaquina.Text = "Máquina:";
            //
            // cmbFiltroMaquina
            //
            cmbFiltroMaquina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroMaquina.Location = new Point(90, 46);
            cmbFiltroMaquina.Name = "cmbFiltroMaquina";
            cmbFiltroMaquina.Size = new Size(220, 23);
            cmbFiltroMaquina.TabIndex = 2;
            cmbFiltroMaquina.SelectionChangeCommitted += filtro_SelectionChangeCommitted;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstado.Location = new Point(330, 48);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(55, 19);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Estado:";
            //
            // cmbFiltroEstado
            //
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Location = new Point(395, 46);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(180, 23);
            cmbFiltroEstado.TabIndex = 4;
            cmbFiltroEstado.SelectionChangeCommitted += filtro_SelectionChangeCommitted;
            //
            // dgvMantenimientos
            //
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.AutoGenerateColumns = false;
            dgvMantenimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Columns.AddRange(new DataGridViewColumn[] { colId, colMaquina, colDescripcion, colInicio, colFinEsperada, colFinReal, colEstado, colDiasDemora });
            dgvMantenimientos.Location = new Point(12, 80);
            dgvMantenimientos.MultiSelect = false;
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.Size = new Size(860, 200);
            dgvMantenimientos.TabIndex = 5;
            //
            // colId
            //
            colId.DataPropertyName = "IdMantenimiento";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            //
            // colMaquina
            //
            colMaquina.DataPropertyName = "Maquina";
            colMaquina.HeaderText = "Máquina";
            colMaquina.Name = "colMaquina";
            colMaquina.ReadOnly = true;
            //
            // colDescripcion
            //
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            //
            // colInicio
            //
            colInicio.DataPropertyName = "FechaInicio";
            colInicio.DefaultCellStyle.Format = "dd/MM/yyyy";
            colInicio.HeaderText = "Inicio";
            colInicio.Name = "colInicio";
            colInicio.ReadOnly = true;
            //
            // colFinEsperada
            //
            colFinEsperada.DataPropertyName = "FechaFinEsperada";
            colFinEsperada.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFinEsperada.HeaderText = "Fin esperado";
            colFinEsperada.Name = "colFinEsperada";
            colFinEsperada.ReadOnly = true;
            //
            // colFinReal
            //
            colFinReal.DataPropertyName = "FechaFinReal";
            colFinReal.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFinReal.DefaultCellStyle.NullValue = "-";
            colFinReal.HeaderText = "Fin real";
            colFinReal.Name = "colFinReal";
            colFinReal.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colDiasDemora
            //
            colDiasDemora.DataPropertyName = "DiasDemora";
            colDiasDemora.HeaderText = "Días de demora";
            colDiasDemora.Name = "colDiasDemora";
            colDiasDemora.ReadOnly = true;
            //
            // lblOpciones
            //
            lblOpciones.AutoSize = true;
            lblOpciones.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblOpciones.Location = new Point(12, 328);
            lblOpciones.Name = "lblOpciones";
            lblOpciones.Size = new Size(91, 22);
            lblOpciones.TabIndex = 6;
            lblOpciones.Text = "Opciones:";
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.LightBlue;
            btnNuevo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(12, 360);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(154, 35);
            btnNuevo.TabIndex = 7;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.MediumSeaGreen;
            btnModificar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(12, 401);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 35);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // btnEliminar
            //
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(12, 442);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(154, 35);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // paginador
            // 
            paginador.Location = new Point(12, 286);
            paginador.Name = "paginador";
            paginador.Size = new Size(422, 28);
            paginador.TabIndex = 20;
            paginador.PaginaCambiada += paginador_PaginaCambiada;
            //
            // MantenimientoLista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 497);
            Controls.Add(paginador);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvMantenimientos);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblEstado);
            Controls.Add(cmbFiltroMaquina);
            Controls.Add(lblMaquina);
            Controls.Add(lblTitulo);
            Name = "MantenimientoLista";
            Text = "Mantenimiento de máquinas";
            Load += MantenimientoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMaquina;
        private ComboBox cmbFiltroMaquina;
        private Label lblEstado;
        private ComboBox cmbFiltroEstado;
        private DataGridView dgvMantenimientos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colMaquina;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colInicio;
        private DataGridViewTextBoxColumn colFinEsperada;
        private DataGridViewTextBoxColumn colFinReal;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colDiasDemora;
        private Label lblOpciones;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private Paginador paginador;
    }
}
