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
        public bool ApplyShaders { get { return _ApplyShaders; } set { _ApplyShaders = value; } }
        private bool _ApplyShaders = true;

        public string[] EffectBlacklist { get { return _EffectBlacklist; } set { _EffectBlacklist = value; } }
        private string[] _EffectBlacklist = { "BloomAndFlares", "DepthOfField" };
    }
}
