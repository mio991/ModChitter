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
        private StreamReader m_OutStream;
        private TwitterWorker m_TwitterWorker;
        private Task m_ReaderTask;

        public MainForm()
        {
            InitializeComponent();

            Task.Run(new Action(InitStream));
        }

        private void InitStream()
        {
                var stream = new NamedPipeClientStream(Properties.Settings.Default.PipeName);
                stream.Connect();

                m_OutStream = new StreamReader(stream);

                m_TwitterWorker = new TwitterWorker(stream);

                m_ReaderTask = new Task(new Action(ReadStreamForever));
                m_ReaderTask.Start();
        }

        private void ReadStreamForever()
        {
            while(true)
            {
                Log(m_OutStream.ReadLine());
            }
        }

        public void Log(string message)
        {
            txtBLog.AppendText(message);
        }
    }
}
