namespace EcoFinder.Forms
{
    partial class FrmNotificacao
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
            this.lstNotificacao = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstNotificacao
            // 
            this.lstNotificacao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstNotificacao.HideSelection = false;
            this.lstNotificacao.Location = new System.Drawing.Point(12, 12);
            this.lstNotificacao.Name = "lstNotificacao";
            this.lstNotificacao.Size = new System.Drawing.Size(1162, 668);
            this.lstNotificacao.TabIndex = 0;
            this.lstNotificacao.UseCompatibleStateImageBehavior = false;
            this.lstNotificacao.SelectedIndexChanged += new System.EventHandler(this.lstNotificacao_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Avisos!";
            this.columnHeader1.Width = 700;
            // 
            // FrmNotificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1186, 692);
            this.Controls.Add(this.lstNotificacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNotificacao";
            this.Text = "FrmNotificacao";
            this.Load += new System.EventHandler(this.FrmNotificacao_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListView lstNotificacao;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}