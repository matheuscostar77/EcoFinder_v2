namespace EcoFinder
{
    partial class frmCadEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEndereco));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.lblRua = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.txtNumCasa = new System.Windows.Forms.TextBox();
            this.lblNumeroCasa = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.btnCadEndereco = new System.Windows.Forms.Button();
            this.btnPesquisarCEP = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 595);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(520, 66);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(41, 20);
            this.lblCEP.TabIndex = 1;
            this.lblCEP.Text = "CEP";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(524, 200);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(51, 20);
            this.lblBairro.TabIndex = 2;
            this.lblBairro.Text = "Bairro";
            // 
            // lblRua
            // 
            this.lblRua.AutoSize = true;
            this.lblRua.Location = new System.Drawing.Point(524, 271);
            this.lblRua.Name = "lblRua";
            this.lblRua.Size = new System.Drawing.Size(39, 20);
            this.lblRua.TabIndex = 3;
            this.lblRua.Text = "Rua";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(524, 89);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(127, 26);
            this.txtCEP.TabIndex = 4;
            this.txtCEP.TextChanged += new System.EventHandler(this.txtCEP_TextChanged);
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(524, 223);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = true;
            this.txtBairro.Size = new System.Drawing.Size(235, 26);
            this.txtBairro.TabIndex = 5;
            this.txtBairro.TextChanged += new System.EventHandler(this.txtBairro_TextChanged);
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(528, 292);
            this.txtRua.Name = "txtRua";
            this.txtRua.ReadOnly = true;
            this.txtRua.Size = new System.Drawing.Size(168, 26);
            this.txtRua.TabIndex = 6;
            this.txtRua.TextChanged += new System.EventHandler(this.txtRua_TextChanged);
            // 
            // txtNumCasa
            // 
            this.txtNumCasa.Location = new System.Drawing.Point(700, 292);
            this.txtNumCasa.Name = "txtNumCasa";
            this.txtNumCasa.Size = new System.Drawing.Size(55, 26);
            this.txtNumCasa.TabIndex = 7;
            this.txtNumCasa.TextChanged += new System.EventHandler(this.txtNumCasa_TextChanged);
            // 
            // lblNumeroCasa
            // 
            this.lblNumeroCasa.AutoSize = true;
            this.lblNumeroCasa.Location = new System.Drawing.Point(698, 271);
            this.lblNumeroCasa.Name = "lblNumeroCasa";
            this.lblNumeroCasa.Size = new System.Drawing.Size(65, 20);
            this.lblNumeroCasa.TabIndex = 8;
            this.lblNumeroCasa.Text = "Número";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(520, 134);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(59, 20);
            this.lblCidade.TabIndex = 9;
            this.lblCidade.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(524, 158);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(146, 26);
            this.txtCidade.TabIndex = 10;
            this.txtCidade.TextChanged += new System.EventHandler(this.txtCidade_TextChanged);
            // 
            // btnCadEndereco
            // 
            this.btnCadEndereco.Location = new System.Drawing.Point(524, 372);
            this.btnCadEndereco.Name = "btnCadEndereco";
            this.btnCadEndereco.Size = new System.Drawing.Size(117, 49);
            this.btnCadEndereco.TabIndex = 11;
            this.btnCadEndereco.Text = "Cadastrar endereço";
            this.btnCadEndereco.UseVisualStyleBackColor = true;
            this.btnCadEndereco.Click += new System.EventHandler(this.btnCadEndereco_Click);
            // 
            // btnPesquisarCEP
            // 
            this.btnPesquisarCEP.Location = new System.Drawing.Point(657, 85);
            this.btnPesquisarCEP.Name = "btnPesquisarCEP";
            this.btnPesquisarCEP.Size = new System.Drawing.Size(122, 34);
            this.btnPesquisarCEP.TabIndex = 12;
            this.btnPesquisarCEP.Text = "Pesquisar";
            this.btnPesquisarCEP.UseVisualStyleBackColor = true;
            this.btnPesquisarCEP.Click += new System.EventHandler(this.btnPesquisarCEP_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(670, 372);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(92, 49);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(676, 134);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 20);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(681, 158);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(80, 26);
            this.txtEstado.TabIndex = 15;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(681, 552);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(134, 31);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "Continuar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmCadEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnPesquisarCEP);
            this.Controls.Add(this.btnCadEndereco);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.lblNumeroCasa);
            this.Controls.Add(this.txtNumCasa);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.lblRua);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.lblCEP);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmCadEndereco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Label lblRua;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.TextBox txtNumCasa;
        private System.Windows.Forms.Label lblNumeroCasa;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Button btnCadEndereco;
        private System.Windows.Forms.Button btnPesquisarCEP;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnVoltar;
    }
}