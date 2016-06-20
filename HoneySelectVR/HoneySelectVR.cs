using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRGIN.Core;
using VRGIN.Modes;

namespace HoneySelectVR
{
    public class HoneySelectVR : IEnhancedPlugin
    {
        public string[] Filter
        {
            get
            {
                return new string[] { "HoneySelectTrial_64", "HoneySelectTrial_32" };
            }
        }

        public string Name
        {
            get
            {
                return "HoneySelectVR";
            }
        }

        public string Version
        {
            get
            {
                return "0.0";
            }
        }

        public void OnApplicationQuit()
        {
        }

        public void OnApplicationStart()
        {
            if (Environment.CommandLine.Contains("--vr"))
            {
                VRManager.Create<HoneyInterpreter>(new HoneyContext());
                VR.Manager.SetMode<HoneySeatedMode>();
            }
        }

        public void OnFixedUpdate()
        {
            // Stub
        }

        public void OnLateUpdate()
        {
            // Stub
        }

        public void OnLevelWasInitialized(int level)
        {
            // Stub
        }

        public void OnLevelWasLoaded(int level)
        {
            // Stub
        }

        public void OnUpdate()
        {
            // Stub
        }
    }
}
