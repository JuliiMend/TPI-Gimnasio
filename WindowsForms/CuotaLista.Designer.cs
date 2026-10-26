namespace WindowsFormsApp
{
    partial class CuotaLista
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
            dgv_cuotas = new DataGridView();
            btn_agregar = new Button();
            btn_actualizar = new Button();
            btn_eliminar = new Button();
            lblFiltroSocio = new Label();
            cmbFiltroSocio = new ComboBox();
            lblFiltroMes = new Label();
            cmbFiltroMes = new ComboBox();
            lblFiltroAnio = new Label();
            cmbFiltroAnio = new ComboBox();
            btnLimpiarFiltros = new Button();
            paginador = new Paginador();
            ((System.ComponentModel.ISupportInitialize)dgv_cuotas).BeginInit();
            SuspendLayout();
            // 
            // dgv_cuotas
            // 
            dgv_cuotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cuotas.Location = new Point(12, 95);
            dgv_cuotas.Name = "dgv_cuotas";
            dgv_cuotas.Size = new Size(732, 332);
            dgv_cuotas.TabIndex = 0;
            // 
            // btn_agregar
            // 
            btn_agregar.Location = new Point(12, 25);
            btn_agregar.Name = "btn_agregar";
            btn_agregar.Size = new Size(75, 23);
            btn_agregar.TabIndex = 1;
            btn_agregar.Text = "Agregar";
            btn_agregar.UseVisualStyleBackColor = true;
            btn_agregar.Click += btn_agregar_Click;
            // 
            // btn_actualizar
            // 
            btn_actualizar.Location = new Point(93, 25);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(75, 23);
            btn_actualizar.TabIndex = 2;
            btn_actualizar.Text = "Actualizar";
            btn_actualizar.UseVisualStyleBackColor = true;
            btn_actualizar.Click += btn_actualizar_Click;
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new Point(174, 25);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(75, 23);
            btn_eliminar.TabIndex = 3;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.UseVisualStyleBackColor = true;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // lblFiltroSocio
            // 
            lblFiltroSocio.AutoSize = true;
            lblFiltroSocio.Location = new Point(12, 64);
            lblFiltroSocio.Name = "lblFiltroSocio";
            lblFiltroSocio.Size = new Size(38, 15);
            lblFiltroSocio.TabIndex = 4;
            lblFiltroSocio.Text = "Socio:";
            // 
            // cmbFiltroSocio
            // 
            cmbFiltroSocio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroSocio.Location = new Point(56, 60);
            cmbFiltroSocio.Name = "cmbFiltroSocio";
            cmbFiltroSocio.Size = new Size(230, 23);
            cmbFiltroSocio.TabIndex = 5;
            cmbFiltroSocio.SelectionChangeCommitted += filtro_SelectionChangeCommitted;
            // 
            // lblFiltroMes
            // 
            lblFiltroMes.AutoSize = true;
            lblFiltroMes.Location = new Point(300, 64);
            lblFiltroMes.Name = "lblFiltroMes";
            lblFiltroMes.Size = new Size(32, 15);
            lblFiltroMes.TabIndex = 6;
            lblFiltroMes.Text = "Mes:";
            // 
            // cmbFiltroMes
            // 
            cmbFiltroMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroMes.Location = new Point(338, 60);
            cmbFiltroMes.Name = "cmbFiltroMes";
            cmbFiltroMes.Size = new Size(110, 23);
            cmbFiltroMes.TabIndex = 7;
            cmbFiltroMes.SelectionChangeCommitted += filtro_SelectionChangeCommitted;
            // 
            // lblFiltroAnio
            // 
            lblFiltroAnio.AutoSize = true;
            lblFiltroAnio.Location = new Point(462, 64);
            lblFiltroAnio.Name = "lblFiltroAnio";
            lblFiltroAnio.Size = new Size(32, 15);
            lblFiltroAnio.TabIndex = 8;
            lblFiltroAnio.Text = "Año:";
            // 
            // cmbFiltroAnio
            // 
            cmbFiltroAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroAnio.Location = new Point(500, 60);
            cmbFiltroAnio.Name = "cmbFiltroAnio";
            cmbFiltroAnio.Size = new Size(80, 23);
            cmbFiltroAnio.TabIndex = 9;
            cmbFiltroAnio.SelectionChangeCommitted += filtro_SelectionChangeCommitted;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(594, 59);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(100, 25);
            btnLimpiarFiltros.TabIndex = 10;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // paginador
            // 
            paginador.Location = new Point(12, 433);
            paginador.Name = "paginador";
            paginador.Size = new Size(422, 28);
            paginador.TabIndex = 11;
            paginador.PaginaCambiada += paginador_PaginaCambiada;
            // 
            // CuotaLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 470);
            Controls.Add(paginador);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(cmbFiltroAnio);
            Controls.Add(lblFiltroAnio);
            Controls.Add(cmbFiltroMes);
            Controls.Add(lblFiltroMes);
            Controls.Add(cmbFiltroSocio);
            Controls.Add(lblFiltroSocio);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_actualizar);
            Controls.Add(btn_agregar);
            Controls.Add(dgv_cuotas);
            Name = "CuotaLista";
            Text = "CuotaLista";
            Load += CuotaLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_cuotas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_cuotas;
        private Button btn_agregar;
        private Button btn_actualizar;
        private Button btn_eliminar;
        private Label lblFiltroSocio;
        private ComboBox cmbFiltroSocio;
        private Label lblFiltroMes;
        private ComboBox cmbFiltroMes;
        private Label lblFiltroAnio;
        private ComboBox cmbFiltroAnio;
        private Button btnLimpiarFiltros;
        private Paginador paginador;
    }
}