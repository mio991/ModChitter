namespace Chitter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotification = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNotification.SuspendLayout();
            this.SuspendLayout();
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmsNotification;
            this.niMain.Icon = ((System.Drawing.Icon)(resources.GetObject("niMain.Icon")));
            this.niMain.Text = "Chitter";
            this.niMain.Visible = true;
            this.niMain.DoubleClick += new System.EventHandler(this.niDoubleClick);
            // 
            // cmsNotification
            // 
            this.cmsNotification.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClose});
            this.cmsNotification.Name = "cmsNotification";
            this.cmsNotification.Size = new System.Drawing.Size(104, 26);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(103, 22);
            this.miClose.Text = "Close";
            this.miClose.Click += new System.EventHandler(this.OnClickClose);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 301);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Chitter - Tweet to Cities Skylines";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.cmsNotification.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsNotification;
        private System.Windows.Forms.ToolStripMenuItem miClose;
    }
}

