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
        public MainForm()
        {
            InitializeComponent();
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
    }
}
