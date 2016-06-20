using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VRGIN.Core;

namespace HoneySelectVR
{
    [XmlRoot("Settings")]
    public class HoneySettings : VRSettings
    {
        public bool ApplyShaders { get; set; }
    }
}
