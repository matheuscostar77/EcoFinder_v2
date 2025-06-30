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
            this.lblFraseTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFraseTitulo
            // 
            this.lblFraseTitulo.AutoSize = true;
            this.lblFraseTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblFraseTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFraseTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFraseTitulo.Location = new System.Drawing.Point(142, 102);
            this.lblFraseTitulo.Name = "lblFraseTitulo";
            this.lblFraseTitulo.Size = new System.Drawing.Size(347, 29);
            this.lblFraseTitulo.TabIndex = 1;
            this.lblFraseTitulo.Text = "Olá coletor, oque deseja fazer?";
            // 
            // frmColetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EcoFinder.Properties.Resources.coletor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1186, 692);
            this.Controls.Add(this.lblFraseTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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