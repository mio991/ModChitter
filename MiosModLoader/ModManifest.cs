using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace MiosModLoader
{
    [Serializable()]
    [XmlRoot("Manifest"), XmlInclude(typeof(ModDescribtion)), XmlInclude(typeof(ModDependencie))]
    class ModManifest
    {
        [XmlElement("Mod")]
        public ModDescribtion Description
        {
            get;
            set;
        }

        [XmlArray("Dependencies"), XmlArrayItem("Depends")]
        public List<ModDependencie> Dependencies
        {
            get;
            set;
        }
    }

    [Serializable()]
    class ModDescribtion
    {
        [XmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlAttribute("description")]
        public string Description
        {
            get;
            set;
        }

        [XmlAttribute("source")]
        public string Source
        {
            get;
            set;
        }
    }

    [Serializable()]
    class ModDependencie
    {
        [XmlAttribute("assembly")]
        public string Assembly
        {
            get;
            set;
        }

    }
}
