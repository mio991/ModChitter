using System;
using System.Collections;
using System.Threading;

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

        public override void OnCreated(IChirper c)
        {
            Init();
            base.OnCreated(c);
        }

        void Init()
        {
            try
            {
                DebugLogger.Log(MessageType.Message, "Start Chirper Outbound");
                m_Chirpy = Singleton<ChirpPanel>.instance;

                DebugLogger.Log(MessageType.Message, "Start Pipe Server");
                m_ServerStream = new NamedPipeServerStream("chirper", PipeDirection.In);

                m_StreamReader = new Thread(StreamReader);
                m_StreamReader.Start();

                var chitterExecutable = Environment.ExpandEnvironmentVariables(@"%SteamPath%\SteamApps\workshop\content\%SteamGameId%\412019683\Tools\Chitter.exe");

                DebugLogger.Message("Try Start Chitter Application at:\n\t\"" + chitterExecutable + "\"");
                Process.Start(chitterExecutable);
            }
            catch (Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        public override void OnReleased()
        {
            m_StreamReader.Abort();
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
            finally
            {
                m_MessageReader.Close();
                m_ServerStream.Close();
            }
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
