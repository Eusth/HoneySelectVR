using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
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
        protected override void OnLevel(int level)
        {
            base.OnLevel(level);
            VRLog.Info("Level {0}", level);
            
            switch(level)
            {
                case (int)Levels.ADV:
                case (int)Levels.ADV2:
                    StartCoroutine(PositionForADV());
                  
                    break;
                case (int)Levels.Customization:
                    var bg = FindObjectsOfType<Canvas>().FirstOrDefault(c => c.name == "BackGround");
                    if(bg)
                    {
                        bg.gameObject.SetActive(false);
                    }

                    //Recenter();
                    //VR.Camera.SteamCam.origin.position = new Vector3(0, 1.4f, 1f);
                    //VR.Camera.SteamCam.origin.rotation = Quaternion.LookRotation(-Vector3.forward);

                    //var cc = Camera.main.GetComponent<CameraControl>();
                    //cc.CameraDir = -Vector3.left;
                    //cc.TargetPos = Vector3.zero;
                    //cc.ForceCalculate();
                    break;
            }
        }

        public override IEnumerable<Type> Tools
        {
            get
            {
                return base.Tools.Concat(new Type[] { typeof(PlayTool) });
            }
        }

        private IEnumerator PositionForADV()
        {
            yield return new WaitForEndOfFrame();
            Recenter();
            VR.Camera.Copy(Camera.main);
            //VR.Camera.SteamCam.origin.position = -VR.Camera.SteamCam.origin.forward + VR.Camera.SteamCam.origin.position.y * Vector3.up;

            //VR.Camera.SteamCam.origin.position = new Vector3(0, 1.4f, 1f);
            //VR.Camera.SteamCam.origin.rotation = Quaternion.LookRotation(-Vector3.forward);
        }
    }

}
