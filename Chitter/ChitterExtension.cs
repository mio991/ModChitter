using System;

using ICities;
using ColossalFramework;

//using TweetSharp;

namespace Chitter
{
    public class ChitterExtension : ChirperExtensionBase
    {
        private ChirpPanel m_Chirpy;

        const string c_ConsumerKey = "8Kntx6wmiNs2IsZSkvoVodCpS";
        const string c_ConsumerSecret = "a2NaZ3JkNTo7BNbEN8RssRzEBudAw1C2TujZgFNVbO8NmYnqsC";
        //private TwitterService m_Service;

        public override void OnCreated(IChirper c)
        {
            Init();
            base.OnCreated(c);
        }

        void Init()
        {
            try
            {
                DebugLogger.Log(MessageType.Message, "Start ChitterExtension");
                m_Chirpy = Singleton<ChirpPanel>.instance;
                
            }
            catch (Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        public void AddMessage(this IChirper chirper, IChirperMessage message, bool show)
        {
            m_Chirpy.AddMessage(message, show);
        }        
    }
}
