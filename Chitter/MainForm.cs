using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Pipes;
using System.IO;

namespace Chitter
{
    public partial class MainForm : Form
    {
        private TwitterWorker m_TwitterWorker;

        public MainForm()
        {
            InitializeComponent();

            Task.Run(new Action(InitStream));
        }

        private void InitStream()
        {
#if !NOCS
            var stream = new NamedPipeClientStream(Properties.Settings.Default.PipeName);
            stream.Connect();
#else
            var stream = new MemoryStream();
#endif
            try
            {
                m_TwitterWorker = new TwitterWorker(stream);
                m_TwitterWorker.MessageRecieved += m_TwitterWorker_MessageRecieved;
                this.Invoke(new Action(this.LoadServiceInfo));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke(new Action(this.Close));
            }
        }

        void LoadServiceInfo()
        {
            lblUserName.Text = m_TwitterWorker.UserName;
        }

        void m_TwitterWorker_MessageRecieved(object sender, TweetSharp.TwitterStatus status)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, TweetSharp.TwitterStatus>(m_TwitterWorker_MessageRecieved), sender, status);
                return;
            }

            var tweet = new TweetControl();
            tweet.Author = status.Author.ScreenName;
            tweet.Message = status.Text;

            tweet.Dock = DockStyle.Top;

            tlpMain.Controls.Add(tweet, 0, tlpMain.RowCount);

        }
    }
}
