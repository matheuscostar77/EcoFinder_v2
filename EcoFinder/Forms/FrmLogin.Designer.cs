namespace EcoFinder
{
    partial class FrmLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.tbxSenha = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblCriarConta = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(162)))), ((int)(((byte)(67)))));
            this.lblEmail.Location = new System.Drawing.Point(753, 188);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 31);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(747, 234);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(240, 26);
            this.tbxEmail.TabIndex = 2;
            this.tbxEmail.TextChanged += new System.EventHandler(this.tbxEmail_TextChanged);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.BackColor = System.Drawing.Color.White;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(162)))), ((int)(((byte)(67)))));
            this.lblSenha.Location = new System.Drawing.Point(754, 289);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(88, 31);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha";
            // 
            // tbxSenha
            // 
            this.tbxSenha.Location = new System.Drawing.Point(750, 335);
            this.tbxSenha.Name = "tbxSenha";
            this.tbxSenha.Size = new System.Drawing.Size(240, 26);
            this.tbxSenha.TabIndex = 4;
            this.tbxSenha.UseSystemPasswordChar = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.Green;
            this.btnEntrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEntrar.Location = new System.Drawing.Point(780, 397);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(183, 42);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click_1);
            // 
            // lblCriarConta
            // 
            this.lblCriarConta.AutoSize = true;
            this.lblCriarConta.BackColor = System.Drawing.Color.White;
            this.lblCriarConta.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriarConta.LinkColor = System.Drawing.Color.DarkGreen;
            this.lblCriarConta.Location = new System.Drawing.Point(754, 462);
            this.lblCriarConta.Name = "lblCriarConta";
            this.lblCriarConta.Size = new System.Drawing.Size(254, 27);
            this.lblCriarConta.TabIndex = 9;
            this.lblCriarConta.TabStop = true;
            this.lblCriarConta.Text = "Não tem conta? Crie aqui";
            this.lblCriarConta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCriarConta_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1162, 632);
            this.Controls.Add(this.lblCriarConta);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.tbxSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.lblEmail);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox tbxSenha;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.LinkLabel lblCriarConta;
    }
}

