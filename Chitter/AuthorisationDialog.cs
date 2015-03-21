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
    public partial class AuthorisationDialog : Form
    {
        public AuthorisationDialog()
        {
            InitializeComponent();
        }

        public string AuthoritationCode
        {
            get
            {
                return txtBCode.Text;
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
