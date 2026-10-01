namespace WindowsFormsApp
{
    partial class ItemCuotaDetalle
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
            label1 = new Label();
            lbl_monto = new Label();
            txt_monto = new TextBox();
            lbl_concepto = new Label();
            txt_concepto = new TextBox();
            btn_aceptar = new Button();
            btn_cancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 18;
            label1.Text = "Agregar Detalle:";
            // 
            // lbl_monto
            // 
            lbl_monto.AutoSize = true;
            lbl_monto.Location = new Point(65, 139);
            lbl_monto.Name = "lbl_monto";
            lbl_monto.Size = new Size(46, 15);
            lbl_monto.TabIndex = 17;
            lbl_monto.Text = "Monto:";
            // 
            // txt_monto
            // 
            txt_monto.Location = new Point(150, 139);
            txt_monto.Name = "txt_monto";
            txt_monto.Size = new Size(100, 23);
            txt_monto.TabIndex = 16;
            // 
            // lbl_concepto
            // 
            lbl_concepto.AutoSize = true;
            lbl_concepto.Location = new Point(65, 110);
            lbl_concepto.Name = "lbl_concepto";
            lbl_concepto.Size = new Size(62, 15);
            lbl_concepto.TabIndex = 15;
            lbl_concepto.Text = "Concepto:";
            // 
            // txt_concepto
            // 
            txt_concepto.Location = new Point(150, 110);
            txt_concepto.Name = "txt_concepto";
            txt_concepto.Size = new Size(100, 23);
            txt_concepto.TabIndex = 14;
            // 
            // btn_aceptar
            // 
            btn_aceptar.Location = new Point(65, 196);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(75, 23);
            btn_aceptar.TabIndex = 19;
            btn_aceptar.Text = "Aceptar";
            btn_aceptar.UseVisualStyleBackColor = true;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Location = new Point(175, 196);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(75, 23);
            btn_cancelar.TabIndex = 20;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // ItemCuotaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_aceptar);
            Controls.Add(label1);
            Controls.Add(lbl_monto);
            Controls.Add(txt_monto);
            Controls.Add(lbl_concepto);
            Controls.Add(txt_concepto);
            Name = "ItemCuotaDetalle";
            Text = "ItemCuotaDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbl_monto;
        private TextBox txt_monto;
        private Label lbl_concepto;
        private TextBox txt_concepto;
        private Button btn_aceptar;
        private Button btn_cancelar;
    }
}