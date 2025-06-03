namespace EcoFinder
{
    partial class frmColetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColetor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblColetor = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 387);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblColetor
            // 
            this.lblColetor.AutoSize = true;
            this.lblColetor.Location = new System.Drawing.Point(342, 112);
            this.lblColetor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColetor.Name = "lblColetor";
            this.lblColetor.Size = new System.Drawing.Size(154, 13);
            this.lblColetor.TabIndex = 1;
            this.lblColetor.Text = "Olá coletor, oque deseja fazer?";
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(345, 179);
            this.btnReservar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(162, 32);
            this.btnReservar.TabIndex = 3;
            this.btnReservar.Text = "Reservar um chamado";
            this.btnReservar.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(345, 230);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(162, 32);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmColetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 387);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.lblColetor);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmColetor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmColetor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblColetor;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnSair;
    }
}