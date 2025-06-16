namespace EcoFinder.Forms
{
    partial class FrmVerChamados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerChamados));
            this.btnChamado3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChamado2 = new System.Windows.Forms.Button();
            this.btnChamado1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChamado3
            // 
            this.btnChamado3.Image = global::EcoFinder.Properties.Resources.icons8_recycle_96;
            this.btnChamado3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado3.Location = new System.Drawing.Point(246, 403);
            this.btnChamado3.Name = "btnChamado3";
            this.btnChamado3.Padding = new System.Windows.Forms.Padding(0, 0, 210, 0);
            this.btnChamado3.Size = new System.Drawing.Size(477, 97);
            this.btnChamado3.TabIndex = 2;
            this.btnChamado3.Text = "Teste";
            this.btnChamado3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(649, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(653, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // btnChamado2
            // 
            this.btnChamado2.BackColor = System.Drawing.Color.Transparent;
            this.btnChamado2.Image = global::EcoFinder.Properties.Resources.icons8_recycle_96;
            this.btnChamado2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado2.Location = new System.Drawing.Point(246, 242);
            this.btnChamado2.Name = "btnChamado2";
            this.btnChamado2.Padding = new System.Windows.Forms.Padding(0, 0, 210, 0);
            this.btnChamado2.Size = new System.Drawing.Size(477, 97);
            this.btnChamado2.TabIndex = 1;
            this.btnChamado2.Text = "Teste";
            this.btnChamado2.UseVisualStyleBackColor = false;
            // 
            // btnChamado1
            // 
            this.btnChamado1.Image = ((System.Drawing.Image)(resources.GetObject("btnChamado1.Image")));
            this.btnChamado1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado1.Location = new System.Drawing.Point(246, 76);
            this.btnChamado1.Name = "btnChamado1";
            this.btnChamado1.Padding = new System.Windows.Forms.Padding(0, 0, 210, 0);
            this.btnChamado1.Size = new System.Drawing.Size(477, 97);
            this.btnChamado1.TabIndex = 0;
            this.btnChamado1.Text = "Teste";
            this.btnChamado1.UseVisualStyleBackColor = true;
            // 
            // FrmVerChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1014, 595);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChamado3);
            this.Controls.Add(this.btnChamado2);
            this.Controls.Add(this.btnChamado1);
            this.Name = "FrmVerChamados";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 200, 0);
            this.Text = "FrmVerChamados";
            this.Load += new System.EventHandler(this.FrmVerChamados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChamado1;
        private System.Windows.Forms.Button btnChamado2;
        private System.Windows.Forms.Button btnChamado3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}