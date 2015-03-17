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
            try
            {
                DebugLogger.Log(MessageType.Message, "ModLoaderConfigurator Loaded");

                var view = UIView.GetAView();

                if (view == null)
                    DebugLogger.Log(MessageType.Error, "text is null");

                foreach(var p in UIComponent.FindObjectsOfType<UIComponent>().Where(c => c.name.Contains("Mod")))
                {
                    DebugLogger.Log(MessageType.Message, p.name + "=" + p.GetType().Name);
                }

                DebugLogger.Log(MessageType.Message, "Try find mod entry");

                UIComponent comp = UIComponent.FindObjectsOfType<UIComponent>().Where(c => c.name.Contains("ModEntry")).First();

                var builder = new StringBuilder();

                if (comp == null)
                    throw new ArgumentException("comp is null");

                DebugLogger.Log(MessageType.Message, "Try write to builder");
                printParrent(builder, comp);

                DebugLogger.Log(MessageType.Message, "Try read builder");
                DebugLogger.Log(MessageType.Message, builder.ToString());

                /*
                var tab = UITabContainer.FindObjectOfType<UITabContainer>();

                DebugLogger.Log(MessageType.Message, tab.name + " - " + tab.childCount);

                

                /*
                foreach(var memberInfo in typeof(UIView).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    DebugLogger.Log(MessageType.Message, memberInfo.MemberType.ToString() + " " + memberInfo.DeclaringType.ToString() + " " + memberInfo.Name);
                }
                 */
            }
            catch(Exception ex)
            {
                DebugLogger.Log(MessageType.Error, ex.Message);
            }
        }

        private string printParrent(StringBuilder builder, UIComponent obj)
        {
            if(obj.parent != null && obj.parent != obj)
            {
                var indention = "\t" + printParrent(builder, obj.parent);

                builder.Append(indention);
                builder.Append(obj.name);
                builder.Append("=");
                builder.AppendLine(obj.GetType().ToString());

                return indention;
            }
            else
            {
                builder.Append(obj.name);
                builder.Append("=");
                builder.AppendLine(obj.GetType().ToString());

                return "˪";
            }
        }
    }
}
