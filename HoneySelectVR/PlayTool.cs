using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using VRGIN.Controls.Tools;
using VRGIN.Core;
using VRGIN.Helpers;

namespace HoneySelectVR
{
    public class GaugeCutout : ProtectedBehaviour
    {
        RawImage _RawImage;
        protected override void OnAwake()
        {
            base.OnAwake();

            _RawImage = gameObject.AddComponent<RawImage>();
            _RawImage.texture = VR.GUI.uGuiTexture;

            // Measured values
            float width = 140 / 720f * Screen.height;
            float offsetRight = 5 / 720f * Screen.height;
            float offsetBottom = 14 / 720f * Screen.height;
            float offsetLeft = Screen.width - offsetRight - width;
            float offsetTop = Screen.height - offsetBottom - width;

            _RawImage.uvRect = new Rect(offsetLeft / Screen.width, offsetBottom / Screen.height, width / Screen.width, width / Screen.height);
        }

        protected void OnEnable()
        {
            VR.GUI.Listen();
        }

        protected void OnDisable()
        {
            VR.GUI.Unlisten();
        }
    }

    public class PlayTool : Tool
    {
        private const float DOT_PRODUCT_THRESHOLD = 0.7f;

        float prevVal;
        float val;
       
        private Canvas _Canvas;


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
            CreateCanvas();

            UpdateVisibility();
        }

        void UpdateVisibility()
        {
            _Canvas.gameObject.SetActive(Singleton<HScene>.Instance);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            UpdateVisibility();

        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _Canvas.gameObject.SetActive(false);
        }


        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            UpdateVisibility();
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


        private void CreateCanvas()
        {
            var canvas = _Canvas = UnityHelper.CreateGameObjectAsChild("ToolCanvas", FindAttachPosition("trackpad")).gameObject.AddComponent<Canvas>();
            
            canvas.renderMode = RenderMode.WorldSpace;

            canvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
            canvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);

            canvas.transform.localPosition = new Vector3(-0.00327f, 0, 0.00327f);
            canvas.transform.localRotation = Quaternion.Euler(0, 180, 90);
            canvas.transform.localScale = Vector3.one * 0.0002294636f;

            var cutout = UnityHelper.CreateGameObjectAsChild("Cutout", _Canvas.transform).gameObject.AddComponent<GaugeCutout>();
            cutout.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            cutout.GetComponent<RectTransform>().anchorMax = Vector2.one;
        }
    }
}
