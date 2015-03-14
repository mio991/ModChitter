using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;

namespace MiosModLoader
{
    public sealed class ModLoaderSettings
    {
        #region Static

        public static ModLoaderSettings Instance
        {
            get;
            private set;
        }

        static ModLoaderSettings()
        {
            Instance = new ModLoaderSettings();
        }

        #endregion

        #region Instance

        private Dictionary<string, object> m_Settings = new Dictionary<string, object>();
        private FileStream m_SettingsFile;
        private XmlSerializer m_Serializer = new XmlSerializer(typeof(Dictionary<string, object>));

        public ModLoaderSettings()
        {
            m_SettingsFile = new FileStream(Environment.ExpandEnvironmentVariables(@"%APPDATALOCAL%\Colossal Order\Cities_Skylines\Addons\Mods\MiosModLoader\Settings.xml"), FileMode.OpenOrCreate);
            if(m_SettingsFile.Length == 0)
            {
                Save();
            }
            Load();
        }

        public void Save()
        {
            m_Serializer.Serialize(m_SettingsFile, m_Settings);
        }

        public void Load()
        {
            m_Settings = (Dictionary<string, object>) m_Serializer.Deserialize(m_SettingsFile);
        }

        public T GetSetting<T>(string name) where T : class
        {
            return m_Settings[name] as T;
        }

        public void SetSetting<T>(string name, T value) where T : new()
        {
            if (!typeof(T).IsSerializable)
                throw new InvalidOperationException("A serializable Type is required");

            m_Settings[name] = value;
        }

        #endregion
    }
}
