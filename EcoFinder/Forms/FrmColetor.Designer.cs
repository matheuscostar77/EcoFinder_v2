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
            this.lblFraseTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFraseTitulo
            // 
            this.lblFraseTitulo.AutoSize = true;
            this.lblFraseTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblFraseTitulo.Location = new System.Drawing.Point(115, 65);
            this.lblFraseTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFraseTitulo.Name = "lblFraseTitulo";
            this.lblFraseTitulo.Size = new System.Drawing.Size(154, 13);
            this.lblFraseTitulo.TabIndex = 1;
            this.lblFraseTitulo.Text = "Olá coletor, oque deseja fazer?";
            // 
            // frmColetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 387);
            this.Controls.Add(this.lblFraseTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmColetor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmColetor_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFraseTitulo;
    }
}