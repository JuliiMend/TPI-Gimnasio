namespace WindowsFormsApp
{
    partial class HistoricoSueldoLista
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
            lblProfesor = new Label();
            cmbFiltroProfesor = new ComboBox();
            dgvSueldos = new DataGridView();
            colProfesor = new DataGridViewTextBoxColumn();
            colDesde = new DataGridViewTextBoxColumn();
            colHasta = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            colVigente = new DataGridViewCheckBoxColumn();
            btnRegistrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSueldos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Bold | FontStyle.Underline);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(210, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Histórico de sueldos";
            //
            // lblProfesor
            //
            lblProfesor.AutoSize = true;
            lblProfesor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProfesor.Location = new Point(12, 48);
            lblProfesor.Name = "lblProfesor";
            lblProfesor.Size = new Size(68, 19);
            lblProfesor.TabIndex = 1;
            lblProfesor.Text = "Profesor:";
            //
            // cmbFiltroProfesor
            //
            cmbFiltroProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroProfesor.Location = new Point(90, 46);
            cmbFiltroProfesor.Name = "cmbFiltroProfesor";
            cmbFiltroProfesor.Size = new Size(250, 23);
            cmbFiltroProfesor.TabIndex = 2;
            cmbFiltroProfesor.SelectionChangeCommitted += cmbFiltroProfesor_SelectionChangeCommitted;
            //
            // dgvSueldos
            //
            dgvSueldos.AllowUserToAddRows = false;
            dgvSueldos.AutoGenerateColumns = false;
            dgvSueldos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSueldos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSueldos.Columns.AddRange(new DataGridViewColumn[] { colProfesor, colDesde, colHasta, colValor, colVigente });
            dgvSueldos.Location = new Point(12, 80);
            dgvSueldos.MultiSelect = false;
            dgvSueldos.Name = "dgvSueldos";
            dgvSueldos.ReadOnly = true;
            dgvSueldos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSueldos.Size = new Size(760, 250);
            dgvSueldos.TabIndex = 3;
            //
            // colProfesor
            //
            colProfesor.DataPropertyName = "Profesor";
            colProfesor.HeaderText = "Profesor";
            colProfesor.Name = "colProfesor";
            colProfesor.ReadOnly = true;
            //
            // colDesde
            //
            colDesde.DataPropertyName = "FechaDesde";
            colDesde.DefaultCellStyle.Format = "dd/MM/yyyy";
            colDesde.HeaderText = "Desde";
            colDesde.Name = "colDesde";
            colDesde.ReadOnly = true;
            //
            // colHasta
            //
            colHasta.DataPropertyName = "FechaHasta";
            colHasta.DefaultCellStyle.Format = "dd/MM/yyyy";
            colHasta.DefaultCellStyle.NullValue = "-";
            colHasta.HeaderText = "Hasta";
            colHasta.Name = "colHasta";
            colHasta.ReadOnly = true;
            //
            // colValor
            //
            colValor.DataPropertyName = "Valor";
            colValor.DefaultCellStyle.Format = "C2";
            colValor.HeaderText = "Valor";
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            //
            // colVigente
            //
            colVigente.DataPropertyName = "Vigente";
            colVigente.HeaderText = "Vigente";
            colVigente.Name = "colVigente";
            colVigente.ReadOnly = true;
            //
            // btnRegistrar
            //
            btnRegistrar.BackColor = Color.LightBlue;
            btnRegistrar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(12, 345);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(220, 35);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar nuevo sueldo";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // HistoricoSueldoLista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(btnRegistrar);
            Controls.Add(dgvSueldos);
            Controls.Add(cmbFiltroProfesor);
            Controls.Add(lblProfesor);
            Controls.Add(lblTitulo);
            Name = "HistoricoSueldoLista";
            Text = "Histórico de sueldos";
            Load += HistoricoSueldoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSueldos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProfesor;
        private ComboBox cmbFiltroProfesor;
        private DataGridView dgvSueldos;
        private DataGridViewTextBoxColumn colProfesor;
        private DataGridViewTextBoxColumn colDesde;
        private DataGridViewTextBoxColumn colHasta;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewCheckBoxColumn colVigente;
        private Button btnRegistrar;
    }
}
