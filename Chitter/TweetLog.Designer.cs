﻿namespace Chitter
{
    partial class TweetLog
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
            this.txtBLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBLog
            // 
            this.txtBLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBLog.Location = new System.Drawing.Point(0, 0);
            this.txtBLog.Multiline = true;
            this.txtBLog.Name = "txtBLog";
            this.txtBLog.Size = new System.Drawing.Size(284, 261);
            this.txtBLog.TabIndex = 0;
            // 
            // TweetLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtBLog);
            this.Name = "TweetLog";
            this.Text = "Chitter - Tweet Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBLog;
    }
}