using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Valve.VR;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Helpers;

namespace HoneySelectVR
{
    public class PlayTool : Tool
    {
        private const float DOT_PRODUCT_THRESHOLD = 0.7f;

        float prevVal;
        float val;



        public override Texture2D Image
        {
            get
            {
                return UnityHelper.LoadImage("icon_play.png");
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            Tracking = GetComponent<SteamVR_TrackedObject>();
        }
        protected override void OnFixedUpdate()
        {
            if (IsTracking)
            {
                var device = this.Controller;

                var tPadPos = device.GetAxis();
                var tPadTouch = device.GetTouch(EVRButtonId.k_EButton_SteamVR_Touchpad);

                if (device.GetTouchDown(EVRButtonId.k_EButton_Axis0))
                {
                    prevVal = tPadPos.y;
                    val = 0;
                }

                if (tPadTouch)
                {
                    // Normalize
                    val += (tPadPos.y - prevVal) * 5;
                    while (Mathf.Abs(val) >= 1) {
                        Owner.StartRumble(new RumbleImpulse(200));
                        VR.Input.Mouse.VerticalScroll(val > 0 ? 1 : -1);
                        val = val > 0 ? (val - 1) : (val + 1);
                    }

                    prevVal = tPadPos.y;
                }
               
            }
        }
        
        protected override void OnDestroy()
        {
        }
    }
}
