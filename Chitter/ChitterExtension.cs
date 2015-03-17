using ICities;
using System;

using MiosModAPIExtension.Chirper;
using MiosModAPIExtension.UI;
using MiosModAPIExtension;

//using TweetSharp;

namespace Chitter
{
    public class ChitterExtension : ChirperExtensionBase
    {
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
            if(!UIProvider.ViewIsReady)
                UIProvider.UIIsReady += Init;

            try
            {

                DebugLogger.Log(MessageType.Message, "Start ChitterExtension");
                MessageBox.Show("HOHOHOHO");
                //m_Service = new TwitterService();
                //m_Service.
            }
            catch (Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }



        
    }
}
