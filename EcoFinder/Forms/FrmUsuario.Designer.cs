namespace EcoFinder
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.lblUsuarioComum = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterarEndereco = new System.Windows.Forms.Button();
            this.btnRealizarChamado = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuarioComum
            // 
            this.lblUsuarioComum.AutoSize = true;
            this.lblUsuarioComum.Location = new System.Drawing.Point(472, 102);
            this.lblUsuarioComum.Name = "lblUsuarioComum";
            this.lblUsuarioComum.Size = new System.Drawing.Size(233, 20);
            this.lblUsuarioComum.TabIndex = 0;
            this.lblUsuarioComum.Text = "Olá usuário, oque deseja fazer?";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(476, 141);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(243, 49);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Cadastrar endereço";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnAlterarEndereco
            // 
            this.btnAlterarEndereco.Location = new System.Drawing.Point(476, 206);
            this.btnAlterarEndereco.Name = "btnAlterarEndereco";
            this.btnAlterarEndereco.Size = new System.Drawing.Size(243, 49);
            this.btnAlterarEndereco.TabIndex = 2;
            this.btnAlterarEndereco.Text = "Alterar endereço";
            this.btnAlterarEndereco.UseVisualStyleBackColor = true;
            // 
            // btnRealizarChamado
            // 
            this.btnRealizarChamado.Location = new System.Drawing.Point(476, 278);
            this.btnRealizarChamado.Name = "btnRealizarChamado";
            this.btnRealizarChamado.Size = new System.Drawing.Size(243, 49);
            this.btnRealizarChamado.TabIndex = 3;
            this.btnRealizarChamado.Text = "Realizar chamado";
            this.btnRealizarChamado.UseVisualStyleBackColor = true;
            this.btnRealizarChamado.Click += new System.EventHandler(this.btnRealizarChamado_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 596);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(476, 362);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(243, 49);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRealizarChamado);
            this.Controls.Add(this.btnAlterarEndereco);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblUsuarioComum);
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUsuario_FormClosed);
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioComum;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnAlterarEndereco;
        private System.Windows.Forms.Button btnRealizarChamado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
    }
}