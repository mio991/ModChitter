using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ColossalFramework;

using MessageTypeInternal = ColossalFramework.Plugins.PluginManager.MessageType;

namespace ChirperOutbound
{
    public static class DebugLogger
    {
        public static void Log(MessageType type, string message)
        {
            MessageTypeInternal typeInternal;
            switch(type)
            {
                default:
                case MessageType.Error:
                    typeInternal = MessageTypeInternal.Error;
                    break;
                case MessageType.Warning:
                    typeInternal = MessageTypeInternal.Warning;
                    break;
                case MessageType.Message:
                    typeInternal = MessageTypeInternal.Message;
                    break;
            }
            DebugOutputPanel.AddMessage(typeInternal, message);
        }

        public static void Message(string message)
        {
            Log(MessageType.Message, message);
        }

        public static void Error(string message)
        {
            Log(MessageType.Error, message);
        }

        public static void Warning(string message)
        {
            Log(MessageType.Warning, message);
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Message
    }
}
