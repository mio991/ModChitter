using System;

using ICities;
using ColossalFramework;

using TweetSharp;

namespace Chitter
{
    public class ChitterExtension : ChirperExtensionBase
    {
        private ChirpPanel m_Chirpy;

        private TwitterService m_Service;

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

                m_Service = new TwitterService(ChitterSettings.Default.AppKey, ChitterSettings.Default.AppSecret);

                if(ChitterSettings.Default.UserToken.IsNullOrWhiteSpace())
                {

                }
                
            }
            catch (Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        public void AddMessage(IChirperMessage message, bool show)
        {
            m_Chirpy.AddMessage(message, show);
        }        
    }
}
