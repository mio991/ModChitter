using System;

using ColossalFramework.UI;

namespace Chitter
{
    class LoginDialog
    {
        private UIView m_View;
        private UIPanel m_Panel;

        public LoginDialog()
        {
            m_View = UIView.GetAView();

            m_Panel = (UIPanel)m_View.AddUIComponent(typeof(UIPanel));

            m_Panel.Show(true);

        }
    }
}
