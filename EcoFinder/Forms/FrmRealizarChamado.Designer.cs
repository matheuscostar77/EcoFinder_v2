namespace EcoFinder
{
    partial class frmRealizarChamado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRealizarChamado));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbMateriall = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.Label();
            this.lblEnderecoCham = new System.Windows.Forms.Label();
            this.btnRealizarChamado = new System.Windows.Forms.Button();
            this.lblEnderecoFormat = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 596);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmbMateriall
            // 
            this.cmbMateriall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateriall.FormattingEnabled = true;
            this.cmbMateriall.Items.AddRange(new object[] {
            "METAL",
            "VIDRO",
            "PAPEL",
            "PLÁSTICO"});
            this.cmbMateriall.Location = new System.Drawing.Point(459, 236);
            this.cmbMateriall.Name = "cmbMateriall";
            this.cmbMateriall.Size = new System.Drawing.Size(175, 28);
            this.cmbMateriall.TabIndex = 1;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoSize = true;
            this.cmbMaterial.Location = new System.Drawing.Point(455, 213);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(65, 20);
            this.cmbMaterial.TabIndex = 2;
            this.cmbMaterial.Text = "Material";
            // 
            // lblEnderecoCham
            // 
            this.lblEnderecoCham.AutoSize = true;
            this.lblEnderecoCham.Location = new System.Drawing.Point(301, 9);
            this.lblEnderecoCham.Name = "lblEnderecoCham";
            this.lblEnderecoCham.Size = new System.Drawing.Size(78, 20);
            this.lblEnderecoCham.TabIndex = 4;
            this.lblEnderecoCham.Text = "Endereço";
            // 
            // btnRealizarChamado
            // 
            this.btnRealizarChamado.Location = new System.Drawing.Point(430, 291);
            this.btnRealizarChamado.Name = "btnRealizarChamado";
            this.btnRealizarChamado.Size = new System.Drawing.Size(243, 49);
            this.btnRealizarChamado.TabIndex = 5;
            this.btnRealizarChamado.Text = "Realizar chamado";
            this.btnRealizarChamado.UseVisualStyleBackColor = true;
            this.btnRealizarChamado.Click += new System.EventHandler(this.btnRealizarChamado_Click);
            // 
            // lblEnderecoFormat
            // 
            this.lblEnderecoFormat.AutoSize = true;
            this.lblEnderecoFormat.Location = new System.Drawing.Point(301, 38);
            this.lblEnderecoFormat.Name = "lblEnderecoFormat";
            this.lblEnderecoFormat.Size = new System.Drawing.Size(51, 20);
            this.lblEnderecoFormat.TabIndex = 6;
            this.lblEnderecoFormat.Text = "label1";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(665, 543);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(112, 40);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmRealizarChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblEnderecoFormat);
            this.Controls.Add(this.btnRealizarChamado);
            this.Controls.Add(this.lblEnderecoCham);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbMateriall);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRealizarChamado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.Load += new System.EventHandler(this.frmRealizarChamado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbMateriall;
        private System.Windows.Forms.Label cmbMaterial;
        private System.Windows.Forms.Label lblEnderecoCham;
        private System.Windows.Forms.Button btnRealizarChamado;
        private System.Windows.Forms.Label lblEnderecoFormat;
        private System.Windows.Forms.Button btnVoltar;
    }
}