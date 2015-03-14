using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ICities;

using MiosModAPIExtension;

using ColossalFramework.UI;

using System.Reflection;

namespace MiosModLoader
{
    // Implementing IUserMod to get into the MainMenu
    public class ModLoader : IUserMod
    {
        #region IUserMod
        public string Description
        {
            get { return "Loads Mods with more than the standard references"; }
        }

        public string Name
        {
            get { return "MiosModLoader"; }
        }
        #endregion

        public ModLoader()
        {
            DebugLogger.Log(MessageType.Message, "ModLoaderConfigurator Loaded");

            var view = UIView.GetAView();

            foreach(var memberInfo in typeof(UIView).GetMembers(BindingFlags.Instance))
            {
                DebugLogger.Log(MessageType.Message, memberInfo.MemberType.ToString() + " " + memberInfo.DeclaringType.ToString() + " " + memberInfo.Name);
            }
        }
    }
}
