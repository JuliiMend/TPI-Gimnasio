namespace WindowsFormsApp
{
    partial class TurnoLista
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
            dgvTurnos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDia = new DataGridViewTextBoxColumn();
            colHoraDesde = new DataGridViewTextBoxColumn();
            colHoraHasta = new DataGridViewTextBoxColumn();
            lblOpciones = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(163, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Turnos";
            // 
            // dgvTurnos
            // 
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Columns.AddRange(new DataGridViewColumn[] { colId, colDia, colHoraDesde, colHoraHasta });
            dgvTurnos.Location = new Point(12, 46);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.Size = new Size(443, 150);
            dgvTurnos.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "IdTurno";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colDia
            // 
            colDia.DataPropertyName = "DiaSemana";
            colDia.HeaderText = "Dia";
            colDia.Name = "colDia";
            colDia.ReadOnly = true;
            // 
            // colHoraDesde
            // 
            colHoraDesde.DataPropertyName = "HoraDesde";
            colHoraDesde.HeaderText = "Hora Desde";
            colHoraDesde.Name = "colHoraDesde";
            colHoraDesde.ReadOnly = true;
            // 
            // colHoraHasta
            // 
            colHoraHasta.DataPropertyName = "HoraHasta";
            colHoraHasta.HeaderText = "Hora hasta";
            colHoraHasta.Name = "colHoraHasta";
            colHoraHasta.ReadOnly = true;
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
            // TurnoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(lblOpciones);
            Controls.Add(dgvTurnos);
            Controls.Add(lblTitulo);
            Name = "TurnoLista";
            Text = "TurnoLista";
            Load += TurnoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvTurnos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDia;
        private DataGridViewTextBoxColumn colHoraDesde;
        private DataGridViewTextBoxColumn colHoraHasta;
        private Label lblOpciones;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
    }
}