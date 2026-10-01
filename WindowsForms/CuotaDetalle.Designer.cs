namespace WindowsFormsApp
{
    partial class CuotaDetalle
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
            lbl_title = new Label();
            cmb_socios = new ComboBox();
            lbl_total = new Label();
            lbl_socio = new Label();
            btn_aceptar = new Button();
            dtp_mesAnio = new DateTimePicker();
            lbl_mesAnio = new Label();
            dtg_detalle = new DataGridView();
            txt_valor = new TextBox();
            btn_modificarItem = new Button();
            btn_eliminarItem = new Button();
            btn_cancelar = new Button();
            bton_agregarItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dtg_detalle).BeginInit();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(24, 19);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(116, 15);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "DATOS DE LA CUOTA";
            // 
            // cmb_socios
            // 
            cmb_socios.FormattingEnabled = true;
            cmb_socios.Location = new Point(83, 52);
            cmb_socios.Name = "cmb_socios";
            cmb_socios.Size = new Size(121, 23);
            cmb_socios.TabIndex = 1;
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Location = new Point(524, 52);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new Size(39, 15);
            lbl_total.TabIndex = 3;
            lbl_total.Text = "Valor: ";
            // 
            // lbl_socio
            // 
            lbl_socio.AutoSize = true;
            lbl_socio.Location = new Point(24, 52);
            lbl_socio.Name = "lbl_socio";
            lbl_socio.Size = new Size(39, 15);
            lbl_socio.TabIndex = 5;
            lbl_socio.Text = "Socio:";
            // 
            // btn_aceptar
            // 
            btn_aceptar.Location = new Point(433, 387);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(74, 30);
            btn_aceptar.TabIndex = 10;
            btn_aceptar.Text = "Aceptar";
            btn_aceptar.UseVisualStyleBackColor = true;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // dtp_mesAnio
            // 
            dtp_mesAnio.CustomFormat = "MM/yyyy";
            dtp_mesAnio.Format = DateTimePickerFormat.Custom;
            dtp_mesAnio.Location = new Point(364, 52);
            dtp_mesAnio.Name = "dtp_mesAnio";
            dtp_mesAnio.Size = new Size(98, 23);
            dtp_mesAnio.TabIndex = 11;
            // 
            // lbl_mesAnio
            // 
            lbl_mesAnio.AutoSize = true;
            lbl_mesAnio.Location = new Point(267, 55);
            lbl_mesAnio.Name = "lbl_mesAnio";
            lbl_mesAnio.Size = new Size(62, 15);
            lbl_mesAnio.TabIndex = 12;
            lbl_mesAnio.Text = "Mes/Año :";
            // 
            // dtg_detalle
            // 
            dtg_detalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_detalle.Location = new Point(44, 115);
            dtg_detalle.Name = "dtg_detalle";
            dtg_detalle.Size = new Size(690, 169);
            dtg_detalle.TabIndex = 16;
            // 
            // txt_valor
            // 
            txt_valor.Location = new Point(581, 47);
            txt_valor.Name = "txt_valor";
            txt_valor.Size = new Size(100, 23);
            txt_valor.TabIndex = 17;
            // 
            // btn_modificarItem
            // 
            btn_modificarItem.Location = new Point(331, 291);
            btn_modificarItem.Name = "btn_modificarItem";
            btn_modificarItem.Size = new Size(93, 32);
            btn_modificarItem.TabIndex = 19;
            btn_modificarItem.Text = "Modificar Item";
            btn_modificarItem.UseVisualStyleBackColor = true;
            btn_modificarItem.Click += btn_modificarItem_Click;
            // 
            // btn_eliminarItem
            // 
            btn_eliminarItem.Location = new Point(498, 295);
            btn_eliminarItem.Name = "btn_eliminarItem";
            btn_eliminarItem.Size = new Size(90, 28);
            btn_eliminarItem.TabIndex = 20;
            btn_eliminarItem.Text = "Eliminar Item";
            btn_eliminarItem.UseVisualStyleBackColor = true;
            btn_eliminarItem.Click += btn_eliminarItem_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Location = new Point(513, 394);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(75, 23);
            btn_cancelar.TabIndex = 21;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // bton_agregarItem
            // 
            bton_agregarItem.Location = new Point(148, 300);
            bton_agregarItem.Name = "bton_agregarItem";
            bton_agregarItem.Size = new Size(96, 34);
            bton_agregarItem.TabIndex = 22;
            bton_agregarItem.Text = "Agregar Item";
            bton_agregarItem.UseVisualStyleBackColor = true;
            bton_agregarItem.Click += btn_agregar_item_Click;
            // 
            // CuotaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bton_agregarItem);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_eliminarItem);
            Controls.Add(btn_modificarItem);
            Controls.Add(txt_valor);
            Controls.Add(dtg_detalle);
            Controls.Add(lbl_mesAnio);
            Controls.Add(dtp_mesAnio);
            Controls.Add(btn_aceptar);
            Controls.Add(lbl_socio);
            Controls.Add(lbl_total);
            Controls.Add(cmb_socios);
            Controls.Add(lbl_title);
            Name = "CuotaDetalle";
            Text = "CuotaDetalle";
            Load += CuotaDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_detalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private ComboBox cmb_socios;
        private Label lbl_total;
        private Label lbl_socio;
        private Button btn_agregar;
        private Button btn_aceptar;
        private DateTimePicker dtp_mesAnio;
        private Label lbl_mesAnio;
        private DataGridView dtg_detalle;
        private TextBox txt_valor;
        private Button button1;
        private Button btn_modificarItem;
        private Button btn_eliminarItem;
        private Button btn_cancelar;
        private Button bton_agregarItem;
    }
}