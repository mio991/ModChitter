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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTweetLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTwitterName = new System.Windows.Forms.Label();
            this.txtBTwitterName = new System.Windows.Forms.TextBox();
            this.cmsNotification.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.msMain.SuspendLayout();
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
            this.miClose,
            this.toolStripSeparator1});
            this.cmsNotification.Name = "cmsNotification";
            this.cmsNotification.Size = new System.Drawing.Size(104, 32);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(103, 22);
            this.miClose.Text = "Close";
            this.miClose.Click += new System.EventHandler(this.OnClickClose);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.lTwitterName, 0, 0);
            this.tlpMain.Controls.Add(this.txtBTwitterName, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(428, 277);
            this.tlpMain.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(428, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTweetLogToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showTweetLogToolStripMenuItem
            // 
            this.showTweetLogToolStripMenuItem.CheckOnClick = true;
            this.showTweetLogToolStripMenuItem.Name = "showTweetLogToolStripMenuItem";
            this.showTweetLogToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showTweetLogToolStripMenuItem.Text = "Show Tweet Log";
            this.showTweetLogToolStripMenuItem.CheckedChanged += new System.EventHandler(this.OnShowTweetLog);
            // 
            // lTwitterName
            // 
            this.lTwitterName.AutoSize = true;
            this.lTwitterName.Location = new System.Drawing.Point(3, 3);
            this.lTwitterName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lTwitterName.Name = "lTwitterName";
            this.lTwitterName.Size = new System.Drawing.Size(73, 13);
            this.lTwitterName.TabIndex = 0;
            this.lTwitterName.Text = "Twitter Name:";
            // 
            // txtBTwitterName
            // 
            this.txtBTwitterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBTwitterName.Location = new System.Drawing.Point(79, 0);
            this.txtBTwitterName.Margin = new System.Windows.Forms.Padding(0);
            this.txtBTwitterName.Name = "txtBTwitterName";
            this.txtBTwitterName.Size = new System.Drawing.Size(349, 20);
            this.txtBTwitterName.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 301);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Chitter - Twitter to Cities Skylines";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.cmsNotification.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsNotification;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTweetLogToolStripMenuItem;
        private System.Windows.Forms.Label lTwitterName;
        private System.Windows.Forms.TextBox txtBTwitterName;
    }
}

