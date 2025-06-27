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
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblEnderecoCham = new System.Windows.Forms.Label();
            this.btnRealizarChamado = new System.Windows.Forms.Button();
            this.lblEnderecoFormat = new System.Windows.Forms.Label();
            this.nmdKG = new System.Windows.Forms.NumericUpDown();
            this.lblKG = new System.Windows.Forms.Label();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.cmbTamanho = new System.Windows.Forms.ComboBox();
            this.qtd_Unitaria = new System.Windows.Forms.Label();
            this.unidades = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmdKG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidades)).BeginInit();
            this.SuspendLayout();
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
            this.cmbMaterial.Location = new System.Drawing.Point(450, 142);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(175, 28);
            this.cmbMaterial.TabIndex = 1;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(446, 118);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(65, 20);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material";
            // 
            // lblEnderecoCham
            // 
            this.lblEnderecoCham.AutoSize = true;
            this.lblEnderecoCham.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEnderecoCham.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoCham.Location = new System.Drawing.Point(302, 9);
            this.lblEnderecoCham.Name = "lblEnderecoCham";
            this.lblEnderecoCham.Size = new System.Drawing.Size(111, 26);
            this.lblEnderecoCham.TabIndex = 4;
            this.lblEnderecoCham.Text = "Endereço:";
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
            this.lblEnderecoFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoFormat.Location = new System.Drawing.Point(302, 38);
            this.lblEnderecoFormat.Name = "lblEnderecoFormat";
            this.lblEnderecoFormat.Size = new System.Drawing.Size(102, 26);
            this.lblEnderecoFormat.TabIndex = 6;
            this.lblEnderecoFormat.Text = "endereco";
            // 
            // nmdKG
            // 
            this.nmdKG.DecimalPlaces = 1;
            this.nmdKG.Location = new System.Drawing.Point(450, 212);
            this.nmdKG.Name = "nmdKG";
            this.nmdKG.Size = new System.Drawing.Size(176, 26);
            this.nmdKG.TabIndex = 8;
            this.nmdKG.ValueChanged += new System.EventHandler(this.nmdKG_ValueChanged);
            // 
            // lblKG
            // 
            this.lblKG.AutoSize = true;
            this.lblKG.Location = new System.Drawing.Point(446, 189);
            this.lblKG.Name = "lblKG";
            this.lblKG.Size = new System.Drawing.Size(78, 20);
            this.lblKG.TabIndex = 10;
            this.lblKG.Text = "Peso (Kg)";
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Location = new System.Drawing.Point(446, 329);
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
            this.cmbTamanho.Location = new System.Drawing.Point(450, 352);
            this.cmbTamanho.Name = "cmbTamanho";
            this.cmbTamanho.Size = new System.Drawing.Size(121, 28);
            this.cmbTamanho.TabIndex = 12;
            this.cmbTamanho.SelectedIndexChanged += new System.EventHandler(this.cmbTamanho_SelectedIndexChanged);
            // 
            // qtd_Unitaria
            // 
            this.qtd_Unitaria.AutoSize = true;
            this.qtd_Unitaria.Location = new System.Drawing.Point(447, 263);
            this.qtd_Unitaria.Name = "qtd_Unitaria";
            this.qtd_Unitaria.Size = new System.Drawing.Size(151, 20);
            this.qtd_Unitaria.TabIndex = 13;
            this.qtd_Unitaria.Text = "Quantidade Unitária";
            // 
            // unidades
            // 
            this.unidades.Location = new System.Drawing.Point(450, 289);
            this.unidades.Name = "unidades";
            this.unidades.Size = new System.Drawing.Size(176, 26);
            this.unidades.TabIndex = 14;
            this.unidades.ValueChanged += new System.EventHandler(this.unidades_ValueChanged);
            // 
            // frmRealizarChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.unidades);
            this.Controls.Add(this.qtd_Unitaria);
            this.Controls.Add(this.cmbTamanho);
            this.Controls.Add(this.lblTamanho);
            this.Controls.Add(this.lblKG);
            this.Controls.Add(this.nmdKG);
            this.Controls.Add(this.lblEnderecoFormat);
            this.Controls.Add(this.btnRealizarChamado);
            this.Controls.Add(this.lblEnderecoCham);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.cmbMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRealizarChamado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.Load += new System.EventHandler(this.frmRealizarChamado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmdKG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblEnderecoCham;
        private System.Windows.Forms.Button btnRealizarChamado;
        private System.Windows.Forms.Label lblEnderecoFormat;
        private System.Windows.Forms.NumericUpDown nmdKG;
        private System.Windows.Forms.Label lblKG;
        private System.Windows.Forms.Label lblTamanho;
        private System.Windows.Forms.ComboBox cmbTamanho;
        private System.Windows.Forms.Label qtd_Unitaria;
        private System.Windows.Forms.NumericUpDown unidades;
    }
}