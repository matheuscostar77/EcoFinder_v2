namespace EcoFinder.Forms
{
    partial class FrmChamadosAtivos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfirmar1 = new System.Windows.Forms.Button();
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.lblMaterial1 = new System.Windows.Forms.Label();
            this.lblEndereco1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMaterial2 = new System.Windows.Forms.Label();
            this.lblEndereco2 = new System.Windows.Forms.Label();
            this.btnConfirmar2 = new System.Windows.Forms.Button();
            this.btnCancelar2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEndereco1);
            this.groupBox1.Controls.Add(this.lblMaterial1);
            this.groupBox1.Controls.Add(this.btnCancelar1);
            this.groupBox1.Controls.Add(this.btnConfirmar1);
            this.groupBox1.Location = new System.Drawing.Point(170, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConfirmar1
            // 
            this.btnConfirmar1.Location = new System.Drawing.Point(344, 85);
            this.btnConfirmar1.Name = "btnConfirmar1";
            this.btnConfirmar1.Size = new System.Drawing.Size(91, 30);
            this.btnConfirmar1.TabIndex = 0;
            this.btnConfirmar1.Text = "Confirmar";
            this.btnConfirmar1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.Location = new System.Drawing.Point(441, 85);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(91, 30);
            this.btnCancelar1.TabIndex = 1;
            this.btnCancelar1.Text = "Cancelar";
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // lblMaterial1
            // 
            this.lblMaterial1.AutoSize = true;
            this.lblMaterial1.Location = new System.Drawing.Point(7, 17);
            this.lblMaterial1.Name = "lblMaterial1";
            this.lblMaterial1.Size = new System.Drawing.Size(65, 20);
            this.lblMaterial1.TabIndex = 2;
            this.lblMaterial1.Text = "Material";
            // 
            // lblEndereco1
            // 
            this.lblEndereco1.AutoSize = true;
            this.lblEndereco1.Location = new System.Drawing.Point(49, 41);
            this.lblEndereco1.Name = "lblEndereco1";
            this.lblEndereco1.Size = new System.Drawing.Size(78, 20);
            this.lblEndereco1.TabIndex = 3;
            this.lblEndereco1.Text = "Endereço";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar2);
            this.groupBox2.Controls.Add(this.btnConfirmar2);
            this.groupBox2.Controls.Add(this.lblEndereco2);
            this.groupBox2.Controls.Add(this.lblMaterial2);
            this.groupBox2.Location = new System.Drawing.Point(170, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblMaterial2
            // 
            this.lblMaterial2.AutoSize = true;
            this.lblMaterial2.Location = new System.Drawing.Point(11, 17);
            this.lblMaterial2.Name = "lblMaterial2";
            this.lblMaterial2.Size = new System.Drawing.Size(65, 20);
            this.lblMaterial2.TabIndex = 0;
            this.lblMaterial2.Text = "Material";
            // 
            // lblEndereco2
            // 
            this.lblEndereco2.AutoSize = true;
            this.lblEndereco2.Location = new System.Drawing.Point(53, 41);
            this.lblEndereco2.Name = "lblEndereco2";
            this.lblEndereco2.Size = new System.Drawing.Size(78, 20);
            this.lblEndereco2.TabIndex = 1;
            this.lblEndereco2.Text = "Endereço";
            // 
            // btnConfirmar2
            // 
            this.btnConfirmar2.Location = new System.Drawing.Point(344, 85);
            this.btnConfirmar2.Name = "btnConfirmar2";
            this.btnConfirmar2.Size = new System.Drawing.Size(91, 30);
            this.btnConfirmar2.TabIndex = 2;
            this.btnConfirmar2.Text = "Confirmar";
            this.btnConfirmar2.UseVisualStyleBackColor = true;
            // 
            // btnCancelar2
            // 
            this.btnCancelar2.Location = new System.Drawing.Point(441, 85);
            this.btnCancelar2.Name = "btnCancelar2";
            this.btnCancelar2.Size = new System.Drawing.Size(91, 30);
            this.btnCancelar2.TabIndex = 3;
            this.btnCancelar2.Text = "Cancelar";
            this.btnCancelar2.UseVisualStyleBackColor = true;
            // 
            // FrmChamadosAtivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChamadosAtivos";
            this.Text = "FrmChamadosAtivos";
            this.Load += new System.EventHandler(this.FrmChamadosAtivos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar1;
        private System.Windows.Forms.Button btnConfirmar1;
        private System.Windows.Forms.Label lblEndereco1;
        private System.Windows.Forms.Label lblMaterial1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar2;
        private System.Windows.Forms.Button btnConfirmar2;
        private System.Windows.Forms.Label lblEndereco2;
        private System.Windows.Forms.Label lblMaterial2;
    }
}