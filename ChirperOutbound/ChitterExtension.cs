using System;
using System.Collections;
using System.Threading;
using System.Linq;

using System.IO.Pipes;
using System.IO;

using ICities;
using ColossalFramework;

using System.Diagnostics;
using System.Reflection;

namespace ChirperOutbound
{
    public class ChirperOutboundExtension : ChirperExtensionBase
    {
        private ChirpPanel m_Chirpy;
        private NamedPipeServerStream m_ServerStream;
        private StreamReader m_MessageReader;
        private Thread m_StreamReader;

        private string m_TempDir;
        private Process m_Chitter;

        public override void OnCreated(IChirper c)
        {
            Init();
            base.OnCreated(c);
        }

        void Init()
        {
            try
            {
                DebugLogger.Message("Start Deploying Assemblys");
                
                m_TempDir = Environment.ExpandEnvironmentVariables(@"%TEMP%\ModChitter\");

                if (Directory.Exists(m_TempDir))
                    Directory.Delete(m_TempDir, true);

                Directory.CreateDirectory(m_TempDir);

                File.WriteAllBytes(m_TempDir + "Chitter.exe", Properties.Resources.Chitter);
                File.WriteAllBytes(m_TempDir + "Hammock.ClientProfile.dll", Properties.Resources.Hammock_ClientProfile);
                File.WriteAllBytes(m_TempDir + "Newtonsoft.Json.dll", Properties.Resources.Newtonsoft_Json);
                File.WriteAllBytes(m_TempDir + "TweetSharp.dll", Properties.Resources.TweetSharp);

                DebugLogger.Log(MessageType.Message, "Start Chirper Outbound");
                m_Chirpy = Singleton<ChirpPanel>.instance;

                DebugLogger.Log(MessageType.Message, "Start Pipe Server");
                m_ServerStream = new NamedPipeServerStream("chirper", PipeDirection.In);

                m_StreamReader = new Thread(StreamReader);
                m_StreamReader.Start();

                DebugLogger.Message("Try Start Chitter Application at:\n\t\"" + m_TempDir + "Chitter.exe" + "\"");
                m_Chitter = Process.Start(m_TempDir + "Chitter.exe");
            }
            catch (Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        public override void OnReleased()
        {
            m_StreamReader.Abort();

            if (!m_Chitter.HasExited)
                m_Chitter.Kill();

            Directory.Delete(m_TempDir, true);
            base.OnReleased();
        }

        private void StreamReader()
        {
            try
            {
                while (true)
                {
                    DebugLogger.Log(MessageType.Message, "Begin Wait for Connections");
                    m_ServerStream.WaitForConnection();

                    DebugLogger.Log(MessageType.Message, "Connection established");
                    m_MessageReader = new StreamReader(m_ServerStream);

                    while (m_ServerStream.IsConnected)
                    {
                        ProcessMessage(m_MessageReader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Error(ex.Message);
            }

                m_MessageReader.Close();
                m_ServerStream.Close();
        }

        private void ProcessMessage(string message)
        {
            DebugLogger.Log(MessageType.Message, "Process Message: " + message);

            if (!message.Contains(":"))
                throw new ArgumentException("Message has the Wrong Format");

            var s = message.Split(':');

            if (s.Length < 2)
                throw new ArgumentException("Message has the Wrong Format");

            AddMessage(new ChirperMessage(0, s[0], s[1].Replace(@"\d", ":").Replace("\\n", "\n")));
        }

        public void AddMessage(IChirperMessage message, bool show = true)
        {
            m_Chirpy.AddMessage(message, show);
        }

        private class ChirperMessage : IChirperMessage
        {
            private uint m_SenderID;
            private string m_SenderName, m_Text;

            public ChirperMessage(uint senderID, string senderName, string text)
            {
                m_SenderID = senderID;
                m_SenderName = senderName;
                m_Text = text;
            }

            public uint senderID
            {
                get { return m_SenderID; }
            }

            public string senderName
            {
                get { return m_SenderName; }
            }

            public string text
            {
                get { return m_Text; }
            }
        }
    }
}
