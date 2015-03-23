using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chitter
{
    public partial class TweetControl : UserControl
    {
        public TweetControl()
        {
            InitializeComponent();
        }

        public string Author
        {
            set
            {
                lblAuthor.Text = value;
            }
            get
            {
                return lblAuthor.Text;
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
            }
            get
            {
                return lblMessage.Text;
            }
        }
    }
}
