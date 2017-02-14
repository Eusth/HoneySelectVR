using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VRGIN.Core;
using VRGIN.Helpers;

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

        //[XmlElement(Type = typeof(HoneyShortcuts))]
        //[XmlComment("Shortcuts used by VRGIN. Refer to https://docs.unity3d.com/ScriptReference/KeyCode.html for a list of available keys.")]
        //public override Shortcuts Shortcuts { get { return _Shortcuts; } protected set { _Shortcuts = value; } }
        //private Shortcuts _Shortcuts = new HoneyShortcuts();

        //[XmlIgnore]
        //public HoneyShortcuts HShortcuts { get { return Shortcuts as HoneyShortcuts; } }
    }

    //public class HoneyShortcuts : Shortcuts
    //{
    //    public XmlKeyStroke ChangeMode = new XmlKeyStroke("Ctrl+C, Ctrl+C", KeyMode.PressUp);
    //}
}
