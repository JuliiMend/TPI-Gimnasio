namespace WindowsFormsApp
{
    partial class PlanLista
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
                dgvPlanes = new DataGridView();
                btnNuevo = new Button();
                btnActualizar = new Button();
                ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
                SuspendLayout();
                // 
                // dgvPlanes
                // 
                dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgvPlanes.Location = new Point(0, 0);
                dgvPlanes.Name = "dgvPlanes";
                dgvPlanes.Size = new Size(514, 438);
                dgvPlanes.TabIndex = 0;
                dgvPlanes.CellContentClick += dgvPlanes_CellContentClick;
                // 
                // btnNuevo
                // 
                btnNuevo.Location = new Point(530, 12);
                btnNuevo.Name = "btnNuevo";
                btnNuevo.Size = new Size(249, 48);
                btnNuevo.TabIndex = 1;
                btnNuevo.Text = "Registrar nuevo Plan";
                btnNuevo.UseVisualStyleBackColor = true;
                btnNuevo.Click += btnNuevo_Click_1;
                // 
                // btnActualizar
                // 
                btnActualizar.Location = new Point(530, 66);
                btnActualizar.Name = "btnActualizar";
                btnActualizar.Size = new Size(249, 46);
                btnActualizar.TabIndex = 2;
                btnActualizar.Text = "Actualizar un Plan";
                btnActualizar.UseVisualStyleBackColor = true;
                // 
                // PlanListaForm
                // 
                AutoScaleDimensions = new SizeF(7F, 15F);
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new Size(800, 450);
                Controls.Add(btnActualizar);
                Controls.Add(btnNuevo);
                Controls.Add(dgvPlanes);
                Name = "PlanListaForm";
                Text = "PlanListaForm";
                Load += PlanListaForm_Load_1;
                ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
                ResumeLayout(false);
            }

            #endregion

            private DataGridView dgvPlanes;
            private Button btnNuevo;
            private Button btnActualizar;
        }
    }