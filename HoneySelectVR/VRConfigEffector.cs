using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoneySelectVR
{
    public class VRConfigEffector : ConfigEffector
    {
        public override void Update()
        {
            if (!Singleton<Manager.Config>.IsInstance())
                return;

            Refresh();
        }
        
    }
}
