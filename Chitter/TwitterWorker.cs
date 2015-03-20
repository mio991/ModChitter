using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

using TweetSharp;
using System.Diagnostics;

using Settings = Chitter.Properties.Settings;

namespace Chitter
{
    class TwitterWorker
    {
        private StreamWriter m_Writer;
        private TwitterService m_Service;

        public TwitterWorker()
        {
            var stream = new NamedPipeClientStream("chirper");
            stream.Connect();

            m_Writer = new StreamWriter(stream);

            m_Service = new TwitterService(Settings.Default.ConsumerKey, Settings.Default.ConsumerSecret);

            var aToken = GetAccessToken();

            m_Service.AuthenticateWith(aToken.Token, aToken.TokenSecret);

        }

        private OAuthAccessToken GetAccessToken()
        {
            if (Settings.Default.AccessToken == null)
            {
                var rToken = m_Service.GetRequestToken();

                var url = m_Service.GetAuthenticationUrl(rToken).ToString();

                Process.Start(url);

                var authDialog = new AuthorisationDialog();

                if (authDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    throw new OperationCanceledException("User Canceld Login Process");

                var aToken = m_Service.GetAccessToken(rToken, authDialog.AuthoritationCode);

                Settings.Default.AccessToken = aToken;
            }
            
            return Settings.Default.AccessToken;
        }
    }
}
