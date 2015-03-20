using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chitter
{
    public partial class MainForm : Form
    {
        private TwitterWorker m_Worker;

        public MainForm()
        {
            InitializeComponent();

            var task = Task.Run<TwitterWorker>(() => { m_Worker = new TwitterWorker(); return m_Worker; });
        }

        private void OnClickClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void niDoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = this.WindowState != FormWindowState.Minimized;
        }

        private void OnShowTweetLog(object sender, EventArgs e)
        {

        }
    }
}
