using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRGIN.Core;
using VRGIN.Modes;

namespace HoneySelectVR
{
    public class HoneySelectVR : IEnhancedPlugin
    {
        private const String NEW_DEFAULT_TOKEN = "Plugins\\VR\\.vr2";

        public string[] Filter
        {
            get
            {
                return new string[] { "HoneySelectTrial_64", "HoneySelectTrial_32", "HoneySelect_64", "HoneySelect_32", "HoneyStudio_32", "HoneyStudio_64" };
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
            if (Environment.CommandLine.Contains("--vr")) {
                var context = new HoneyContext();
                var settings = context.Settings as HoneySettings;

                // Enforce new default
                if(!File.Exists(NEW_DEFAULT_TOKEN)) {
                    File.Create(NEW_DEFAULT_TOKEN);

                    settings.ApplyShaders = true;
                    settings.Save();
                }
                VRManager.Create<HoneyInterpreter>(context);
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
            if ((VR.Settings as HoneySettings).ApplyShaders && Camera.main)
            {
                VR.Camera.CopyFX(Camera.main);
            }
        }

        public void OnLevelWasLoaded(int level)
        {
            // Stub
        }

        public void OnUpdate()
        {
            // Stub

            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown(KeyCode.Keypad0 + i))
                {
                    SceneManager.LoadScene(i);
                }
            }
        }
    }
}
