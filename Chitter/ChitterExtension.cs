using System;

using System.IO.Pipes;
using System.IO;

using ICities;
using ColossalFramework;

namespace ChirperOutbound
{
    public class ChirperOutboundExtension : ChirperExtensionBase
    {
        private ChirpPanel m_Chirpy;
        private NamedPipeServerStream m_ServerStream;
        private StreamReader m_MessageReader;

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

                DebugLogger.Log(MessageType.Message, "Begin Wait for Connections");
                m_ServerStream.BeginWaitForConnection(ServerStreamConected, null);
            }
            catch (Exception ex) 
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        private void ServerStreamConected(IAsyncResult result)
        {
            DebugLogger.Log(MessageType.Message, "Connection established");
            m_MessageReader = new StreamReader(m_ServerStream);

            while (m_ServerStream.IsConnected)
            {
                var message = m_MessageReader.ReadLine();

                ProcessMessage(message);
            }
        }

        private void ProcessMessage(string message)
        {
            DebugLogger.Log(MessageType.Message, "Process Message: " + message);
            var s = message.Split(':');

            if (s.Length < 2)
                throw new ArgumentException("Message has the Wrong Format");

            AddMessage(new ChirperMessage(0, s[0], s[1]));
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
