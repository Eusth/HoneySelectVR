using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        VRConfigEffector _Effector;
        bool _FXInitialized = false;

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
            if (Environment.CommandLine.Contains("--vr"))
            {
                if (!_FXInitialized && (VR.Settings as HoneySettings).ApplyShaders && Camera.main)
                {
                    VR.Camera.CopyFX(Camera.main);
                    _Effector = VR.Camera.gameObject.AddComponent<VRConfigEffector>();
                    _Effector.Reset();
                    _FXInitialized = true;
                }

                //SoundShim.Inject();
                VoiceShim.Inject();

                var scene = GameObject.FindObjectOfType<HScene>();
                if (scene && scene.sprite)
                {
                    var dummy = HSceneSpriteDummy.Create(scene.sprite);
                    var procs = typeof(HScene).GetField("lstProc", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(scene) as List<ProcBase>;
                    foreach (var proc in procs)
                    {
                        typeof(ProcBase).GetField("sprite", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(proc, dummy);
                    }
                }
            }
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnUpdate()
        {
            // Stub

            //if(Input.GetKeyUp(KeyCode.Space))
            //{
            //    foreach (Transform descendent in GameObject.FindObjectsOfType<Transform>())
            //    {
            //        if (descendent.GetComponent<DynamicBone>())
            //        {
            //            VRLog.Info("Changing rate of {0} from {1}", descendent.name, typeof(DynamicBone).GetField("m_UpdateRate").GetValue(descendent.GetComponent<DynamicBone>()));
            //            descendent.GetComponent<DynamicBone>().m_UpdateRate = 90f;
            //            ;
            //        }
            //        if (descendent.GetComponent<DynamicBone_Ver01>())
            //        {
            //            VRLog.Info("Changing rate of {0} from {1}", descendent.name, descendent.GetComponent<DynamicBone_Ver01>().m_UpdateRate);

            //            descendent.GetComponent<DynamicBone_Ver01>().m_UpdateRate = 90f;
            //        }
            //        if (descendent.GetComponent<DynamicBone_Ver02>())
            //        {
            //            VRLog.Info("Changing rate of {0} from {1}", descendent.name, descendent.GetComponent<DynamicBone_Ver02>().UpdateRate);

            //            descendent.GetComponent<DynamicBone_Ver02>().UpdateRate = 90f;
            //        }
            //    }
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    if (Input.GetKeyDown(KeyCode.Keypad0 + i))
            //    {
            //        SceneManager.LoadScene(i);
            //    }
            //}
        }
    }
}
