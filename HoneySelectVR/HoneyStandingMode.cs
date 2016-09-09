using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRGIN.Controls;
using VRGIN.Helpers;
using VRGIN.Modes;
using VRGIN.Core;
using System.Collections;
using UnityEngine;

namespace HoneySelectVR
{
    class HoneyStandingMode : StandingMode
    {
        protected override IEnumerable<IShortcut> CreateShortcuts()
        {
            return base.CreateShortcuts().Concat(new IShortcut[] {
                new MultiKeyboardShortcut(new KeyStroke("Ctrl + C"), new KeyStroke("Ctrl + C"), delegate { VR.Manager.SetMode<HoneySeatedMode>(); } )
            });
        }

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);
            VRLog.Info("Level {0}", level);

            switch (level)
            {
                case (int)Levels.ADV:
                case (int)Levels.ADV2:
                    StartCoroutine(PositionForADV());

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

            if (Camera.main)
            {
                VR.Camera.Copy(Camera.main);

                MoveToPosition(Camera.main.transform.position, Camera.main.transform.rotation);
            }
            //VR.Camera.SteamCam.origin.position = -VR.Camera.SteamCam.origin.forward + VR.Camera.SteamCam.origin.position.y * Vector3.up;

            //VR.Camera.SteamCam.origin.position = new Vector3(0, 1.4f, 1f);
            //VR.Camera.SteamCam.origin.rotation = Quaternion.LookRotation(-Vector3.forward);
        }
    }
}
