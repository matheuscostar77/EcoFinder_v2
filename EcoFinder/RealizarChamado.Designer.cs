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
            this.cmbEnderecoCham = new System.Windows.Forms.ComboBox();
            this.lblEnderecoCham = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.cmbMateriall.FormattingEnabled = true;
            this.cmbMateriall.Items.AddRange(new object[] {
            "METAL",
            "VIDRO",
            "PAPEL",
            "PLÁSTICO"});
            this.cmbMateriall.Location = new System.Drawing.Point(577, 288);
            this.cmbMateriall.Name = "cmbMateriall";
            this.cmbMateriall.Size = new System.Drawing.Size(175, 28);
            this.cmbMateriall.TabIndex = 1;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoSize = true;
            this.cmbMaterial.Location = new System.Drawing.Point(573, 265);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(65, 20);
            this.cmbMaterial.TabIndex = 2;
            this.cmbMaterial.Text = "Material";
            // 
            // cmbEnderecoCham
            // 
            this.cmbEnderecoCham.FormattingEnabled = true;
            this.cmbEnderecoCham.Location = new System.Drawing.Point(577, 218);
            this.cmbEnderecoCham.Name = "cmbEnderecoCham";
            this.cmbEnderecoCham.Size = new System.Drawing.Size(175, 28);
            this.cmbEnderecoCham.TabIndex = 3;
            // 
            // lblEnderecoCham
            // 
            this.lblEnderecoCham.AutoSize = true;
            this.lblEnderecoCham.Location = new System.Drawing.Point(577, 192);
            this.lblEnderecoCham.Name = "lblEnderecoCham";
            this.lblEnderecoCham.Size = new System.Drawing.Size(78, 20);
            this.lblEnderecoCham.TabIndex = 4;
            this.lblEnderecoCham.Text = "Endereço";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "Realizar chamado";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmRealizarChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEnderecoCham);
            this.Controls.Add(this.cmbEnderecoCham);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbMateriall);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRealizarChamado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbMateriall;
        private System.Windows.Forms.Label cmbMaterial;
        private System.Windows.Forms.ComboBox cmbEnderecoCham;
        private System.Windows.Forms.Label lblEnderecoCham;
        private System.Windows.Forms.Button button1;
    }
}