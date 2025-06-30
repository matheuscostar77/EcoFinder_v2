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
            this.lblUsuarioComum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsuarioComum
            // 
            this.lblUsuarioComum.AutoSize = true;
            this.lblUsuarioComum.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioComum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioComum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsuarioComum.Location = new System.Drawing.Point(142, 108);
            this.lblUsuarioComum.Name = "lblUsuarioComum";
            this.lblUsuarioComum.Size = new System.Drawing.Size(352, 29);
            this.lblUsuarioComum.TabIndex = 0;
            this.lblUsuarioComum.Text = "Olá usuário, oque deseja fazer?";
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EcoFinder.Properties.Resources.usuario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1186, 692);
            this.Controls.Add(this.lblUsuarioComum);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcoFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUsuario_FormClosed);
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioComum;
    }
}