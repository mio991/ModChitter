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
                var stream = new NamedPipeClientStream(Properties.Settings.Default.PipeName);
                stream.Connect();
                m_TwitterWorker = new TwitterWorker(stream);
                m_TwitterWorker.MessageRecieved += m_TwitterWorker_MessageRecieved;
        }

        void m_TwitterWorker_MessageRecieved(object sender, TweetSharp.TwitterStatus status)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, TweetSharp.TwitterStatus>(m_TwitterWorker_MessageRecieved), sender, status);
                return;
            }

            rtxtBLog.AppendText(status.Author.ScreenName + ":\t" + status.Text + "\n");
        }
    }
}
