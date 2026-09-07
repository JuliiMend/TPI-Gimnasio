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
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(338, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(103, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Turnos";
            // 
            // dgvTurnos
            // 
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Columns.AddRange(new DataGridViewColumn[] { colId, colDia, colHoraDesde, colHoraHasta });
            dgvTurnos.Location = new Point(166, 62);
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
            // btnNuevo
            // 
            btnNuevo.Location = new Point(138, 218);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(338, 218);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(582, 218);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
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
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDia;
        private DataGridViewTextBoxColumn colHoraDesde;
        private DataGridViewTextBoxColumn colHoraHasta;
    }
}