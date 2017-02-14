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
        [XmlComment("Whether or not to copy image effects from the main camera.")]
        public bool ApplyShaders { get { return _ApplyShaders; } set { _ApplyShaders = value; } }
        private bool _ApplyShaders = true;

        [XmlComment("Blacklist of effects that are to be disable (because they don't look good in VR).")]
        public string[] EffectBlacklist { get { return _EffectBlacklist; } set { _EffectBlacklist = value; } }
        private string[] _EffectBlacklist = { "BloomAndFlares", "DepthOfField" };
    }
}
