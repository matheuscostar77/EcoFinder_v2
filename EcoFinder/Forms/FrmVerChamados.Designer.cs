﻿namespace EcoFinder.Forms
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
            this.lblDistancia3 = new System.Windows.Forms.Label();
            this.lblDistancia2 = new System.Windows.Forms.Label();
            this.lblDistancia1 = new System.Windows.Forms.Label();
            this.btnChamado3 = new System.Windows.Forms.Button();
            this.btnChamado2 = new System.Windows.Forms.Button();
            this.btnChamado1 = new System.Windows.Forms.Button();
            this.cmbClassificar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDistancia3
            // 
            this.lblDistancia3.AutoSize = true;
            this.lblDistancia3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDistancia3.Location = new System.Drawing.Point(479, 319);
            this.lblDistancia3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistancia3.Name = "lblDistancia3";
            this.lblDistancia3.Size = new System.Drawing.Size(33, 13);
            this.lblDistancia3.TabIndex = 9;
            this.lblDistancia3.Text = "000m";
            // 
            // lblDistancia2
            // 
            this.lblDistancia2.AutoSize = true;
            this.lblDistancia2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDistancia2.Location = new System.Drawing.Point(479, 233);
            this.lblDistancia2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistancia2.Name = "lblDistancia2";
            this.lblDistancia2.Size = new System.Drawing.Size(33, 13);
            this.lblDistancia2.TabIndex = 2;
            this.lblDistancia2.Text = "000m";
            // 
            // lblDistancia1
            // 
            this.lblDistancia1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDistancia1.Location = new System.Drawing.Point(479, 151);
            this.lblDistancia1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistancia1.Name = "lblDistancia1";
            this.lblDistancia1.Size = new System.Drawing.Size(47, 12);
            this.lblDistancia1.TabIndex = 11;
            this.lblDistancia1.Text = "000m";
            // 
            // btnChamado3
            // 
            this.btnChamado3.Image = ((System.Drawing.Image)(resources.GetObject("btnChamado3.Image")));
            this.btnChamado3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado3.Location = new System.Drawing.Point(210, 276);
            this.btnChamado3.Margin = new System.Windows.Forms.Padding(2);
            this.btnChamado3.Name = "btnChamado3";
            this.btnChamado3.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.btnChamado3.Size = new System.Drawing.Size(318, 63);
            this.btnChamado3.TabIndex = 2;
            this.btnChamado3.Text = "Material";
            this.btnChamado3.UseVisualStyleBackColor = true;
            this.btnChamado3.Click += new System.EventHandler(this.btnChamado3_Click);
            // 
            // btnChamado2
            // 
            this.btnChamado2.BackColor = System.Drawing.Color.Transparent;
            this.btnChamado2.Image = ((System.Drawing.Image)(resources.GetObject("btnChamado2.Image")));
            this.btnChamado2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado2.Location = new System.Drawing.Point(210, 191);
            this.btnChamado2.Margin = new System.Windows.Forms.Padding(2);
            this.btnChamado2.Name = "btnChamado2";
            this.btnChamado2.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.btnChamado2.Size = new System.Drawing.Size(318, 63);
            this.btnChamado2.TabIndex = 1;
            this.btnChamado2.Text = "Material";
            this.btnChamado2.UseVisualStyleBackColor = false;
            this.btnChamado2.Click += new System.EventHandler(this.btnChamado2_Click);
            // 
            // btnChamado1
            // 
            this.btnChamado1.Image = ((System.Drawing.Image)(resources.GetObject("btnChamado1.Image")));
            this.btnChamado1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamado1.Location = new System.Drawing.Point(210, 106);
            this.btnChamado1.Margin = new System.Windows.Forms.Padding(2);
            this.btnChamado1.Name = "btnChamado1";
            this.btnChamado1.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.btnChamado1.Size = new System.Drawing.Size(318, 63);
            this.btnChamado1.TabIndex = 0;
            this.btnChamado1.Text = "Material";
            this.btnChamado1.UseVisualStyleBackColor = true;
            this.btnChamado1.Click += new System.EventHandler(this.btnChamado1_Click);
            // 
            // cmbClassificar
            // 
            this.cmbClassificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassificar.FormattingEnabled = true;
            this.cmbClassificar.Items.AddRange(new object[] {
            "Distância",
            "Metal",
            "Papel",
            "Plástico",
            "Vidro",
            "Eletrônico"});
            this.cmbClassificar.Location = new System.Drawing.Point(435, 71);
            this.cmbClassificar.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClassificar.Name = "cmbClassificar";
            this.cmbClassificar.Size = new System.Drawing.Size(82, 21);
            this.cmbClassificar.TabIndex = 13;
            this.cmbClassificar.SelectedIndexChanged += new System.EventHandler(this.cmbClassificar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Classificar por:";
            // 
            // FrmVerChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(791, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClassificar);
            this.Controls.Add(this.lblDistancia1);
            this.Controls.Add(this.lblDistancia2);
            this.Controls.Add(this.lblDistancia3);
            this.Controls.Add(this.btnChamado3);
            this.Controls.Add(this.btnChamado2);
            this.Controls.Add(this.btnChamado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmVerChamados";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 133, 0);
            this.Text = "FrmVerChamados";
            this.Load += new System.EventHandler(this.FrmVerChamados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChamado1;
        private System.Windows.Forms.Button btnChamado2;
        private System.Windows.Forms.Button btnChamado3;
        private System.Windows.Forms.Label lblDistancia3;
        private System.Windows.Forms.Label lblDistancia2;
        private System.Windows.Forms.Label lblDistancia1;
        private System.Windows.Forms.ComboBox cmbClassificar;
        private System.Windows.Forms.Label label1;
    }
}