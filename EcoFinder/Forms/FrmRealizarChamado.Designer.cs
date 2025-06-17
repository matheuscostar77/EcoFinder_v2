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
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblEnderecoCham = new System.Windows.Forms.Label();
            this.btnRealizarChamado = new System.Windows.Forms.Button();
            this.lblEnderecoFormat = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.nmdKG = new System.Windows.Forms.NumericUpDown();
            this.lblKG = new System.Windows.Forms.Label();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.cmbTamanho = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmdKG)).BeginInit();
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
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "METAL",
            "VIDRO",
            "PAPEL",
            "PLÁSTICO"});
            this.cmbMaterial.Location = new System.Drawing.Point(450, 183);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(175, 28);
            this.cmbMaterial.TabIndex = 1;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(446, 160);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(65, 20);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material";
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
            this.btnRealizarChamado.Location = new System.Drawing.Point(434, 406);
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
            // nmdKG
            // 
            this.nmdKG.DecimalPlaces = 1;
            this.nmdKG.Location = new System.Drawing.Point(450, 254);
            this.nmdKG.Name = "nmdKG";
            this.nmdKG.Size = new System.Drawing.Size(175, 26);
            this.nmdKG.TabIndex = 8;
            this.nmdKG.ValueChanged += new System.EventHandler(this.nmdKG_ValueChanged);
            // 
            // lblKG
            // 
            this.lblKG.AutoSize = true;
            this.lblKG.Location = new System.Drawing.Point(446, 231);
            this.lblKG.Name = "lblKG";
            this.lblKG.Size = new System.Drawing.Size(78, 20);
            this.lblKG.TabIndex = 10;
            this.lblKG.Text = "Peso (Kg)";
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Location = new System.Drawing.Point(446, 310);
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(76, 20);
            this.lblTamanho.TabIndex = 11;
            this.lblTamanho.Text = "Tamanho";
            // 
            // cmbTamanho
            // 
            this.cmbTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTamanho.FormattingEnabled = true;
            this.cmbTamanho.Items.AddRange(new object[] {
            "Pequeno",
            "Médio",
            "Grande"});
            this.cmbTamanho.Location = new System.Drawing.Point(450, 333);
            this.cmbTamanho.Name = "cmbTamanho";
            this.cmbTamanho.Size = new System.Drawing.Size(121, 28);
            this.cmbTamanho.TabIndex = 12;
            this.cmbTamanho.SelectedIndexChanged += new System.EventHandler(this.cmbTamanho_SelectedIndexChanged);
            // 
            // frmRealizarChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.cmbTamanho);
            this.Controls.Add(this.lblTamanho);
            this.Controls.Add(this.lblKG);
            this.Controls.Add(this.nmdKG);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblEnderecoFormat);
            this.Controls.Add(this.btnRealizarChamado);
            this.Controls.Add(this.lblEnderecoCham);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRealizarChamado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.Load += new System.EventHandler(this.frmRealizarChamado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmdKG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblEnderecoCham;
        private System.Windows.Forms.Button btnRealizarChamado;
        private System.Windows.Forms.Label lblEnderecoFormat;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.NumericUpDown nmdKG;
        private System.Windows.Forms.Label lblKG;
        private System.Windows.Forms.Label lblTamanho;
        private System.Windows.Forms.ComboBox cmbTamanho;
    }
}