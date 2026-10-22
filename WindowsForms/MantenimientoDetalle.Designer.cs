namespace WindowsFormsApp
{
    partial class MantenimientoDetalle
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
            cmbMaquina = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblInicio = new Label();
            dtpInicio = new DateTimePicker();
            lblFinEsperada = new Label();
            dtpFinEsperada = new DateTimePicker();
            lblFinReal = new Label();
            dtpFinReal = new DateTimePicker();
            btnGuardar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 15F, FontStyle.Underline);
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DATOS DEL MANTENIMIENTO";
            //
            // lblMaquina
            //
            lblMaquina.AutoSize = true;
            lblMaquina.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMaquina.Location = new Point(18, 63);
            lblMaquina.Name = "lblMaquina";
            lblMaquina.Size = new Size(80, 21);
            lblMaquina.TabIndex = 1;
            lblMaquina.Text = "Máquina:";
            //
            // cmbMaquina
            //
            cmbMaquina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaquina.Location = new Point(150, 65);
            cmbMaquina.Name = "cmbMaquina";
            cmbMaquina.Size = new Size(250, 23);
            cmbMaquina.TabIndex = 2;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescripcion.Location = new Point(18, 105);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(104, 21);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(150, 107);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(250, 23);
            txtDescripcion.TabIndex = 4;
            //
            // lblInicio
            //
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInicio.Location = new Point(18, 147);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(57, 21);
            lblInicio.TabIndex = 5;
            lblInicio.Text = "Inicio:";
            //
            // dtpInicio
            //
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(150, 149);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(140, 23);
            dtpInicio.TabIndex = 6;
            //
            // lblFinEsperada
            //
            lblFinEsperada.AutoSize = true;
            lblFinEsperada.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinEsperada.Location = new Point(18, 189);
            lblFinEsperada.Name = "lblFinEsperada";
            lblFinEsperada.Size = new Size(116, 21);
            lblFinEsperada.TabIndex = 7;
            lblFinEsperada.Text = "Fin esperado:";
            //
            // dtpFinEsperada
            //
            dtpFinEsperada.Format = DateTimePickerFormat.Short;
            dtpFinEsperada.Location = new Point(150, 191);
            dtpFinEsperada.Name = "dtpFinEsperada";
            dtpFinEsperada.Size = new Size(140, 23);
            dtpFinEsperada.TabIndex = 8;
            //
            // lblFinReal
            //
            lblFinReal.AutoSize = true;
            lblFinReal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinReal.Location = new Point(18, 231);
            lblFinReal.Name = "lblFinReal";
            lblFinReal.Size = new Size(72, 21);
            lblFinReal.TabIndex = 9;
            lblFinReal.Text = "Fin real:";
            //
            // dtpFinReal
            //
            dtpFinReal.Checked = false;
            dtpFinReal.Format = DateTimePickerFormat.Short;
            dtpFinReal.Location = new Point(150, 233);
            dtpFinReal.Name = "dtpFinReal";
            dtpFinReal.ShowCheckBox = true;
            dtpFinReal.Size = new Size(140, 23);
            dtpFinReal.TabIndex = 10;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.LightBlue;
            btnGuardar.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(297, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 32);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // MantenimientoDetalle
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 331);
            Controls.Add(btnGuardar);
            Controls.Add(dtpFinReal);
            Controls.Add(lblFinReal);
            Controls.Add(dtpFinEsperada);
            Controls.Add(lblFinEsperada);
            Controls.Add(dtpInicio);
            Controls.Add(lblInicio);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(cmbMaquina);
            Controls.Add(lblMaquina);
            Controls.Add(lblTitulo);
            Name = "MantenimientoDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mantenimiento";
            Load += MantenimientoDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMaquina;
        private ComboBox cmbMaquina;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblInicio;
        private DateTimePicker dtpInicio;
        private Label lblFinEsperada;
        private DateTimePicker dtpFinEsperada;
        private Label lblFinReal;
        private DateTimePicker dtpFinReal;
        private Button btnGuardar;
    }
}
