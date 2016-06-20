using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valve.VR;
using VRGIN.Controls;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Modes;

namespace HoneySelectVR
{
    class HoneySeatedMode : SeatedMode
    {

        protected override IEnumerable<IShortcut> CreateShortcuts()
        {
            return base.CreateShortcuts().Concat(new IShortcut[] {
                new MultiKeyboardShortcut(new KeyStroke("Ctrl + C"), new KeyStroke("Ctrl + C"), ChangeModeOnControllersDetected ),
            });
        }

        protected override void ChangeModeOnControllersDetected()
        {
            VR.Manager.SetMode<HoneyStandingMode>();
        }

    }

}
