namespace Chitter
{
    partial class MainForm
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
            System.Windows.Forms.TableLayoutPanel tlpInfo;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            tlpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(tlpInfo, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(383, 335);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpInfo
            // 
            tlpInfo.BackColor = System.Drawing.SystemColors.Highlight;
            tlpInfo.ColumnCount = 2;
            tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpInfo.Controls.Add(label1, 0, 0);
            tlpInfo.Controls.Add(this.lblUserName, 1, 0);
            tlpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            tlpInfo.Location = new System.Drawing.Point(3, 3);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.RowCount = 1;
            tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpInfo.Size = new System.Drawing.Size(377, 18);
            tlpInfo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 18);
            label1.TabIndex = 1;
            label1.Text = "Authenticated User:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Location = new System.Drawing.Point(110, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(264, 18);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "None";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 335);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Chitter - Tweet Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpMain.ResumeLayout(false);
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblUserName;



    }
}