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
            this.lstNotificacao.Location = new System.Drawing.Point(21, 30);
            this.lstNotificacao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstNotificacao.Name = "lstNotificacao";
            this.lstNotificacao.Size = new System.Drawing.Size(501, 224);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.lstNotificacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmNotificacao";
            this.Text = "FrmNotificacao";
            this.Load += new System.EventHandler(this.FrmNotificacao_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ListView lstNotificacao;
    }
}