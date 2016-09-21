using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public class PlayButton
    {
        public UnityEngine.Events.UnityEvent OnActivate = new UnityEngine.Events.UnityEvent();
        public UnityEngine.Events.UnityEvent OnSelect = new UnityEngine.Events.UnityEvent();
        public UnityEngine.Events.UnityEvent OnUnselect = new UnityEngine.Events.UnityEvent();
        public int StartAngle;
        public int Degrees;
    }

    public class PlayTool : Tool
    {
        private const float DOT_PRODUCT_THRESHOLD = 0.7f;

        float prevVal;
        float val;
        
        enum PlayToolMode
        {
            Buttons,
            Wheel
        }

        PlayToolMode _Mode = PlayToolMode.Buttons;

        private Canvas _Canvas;

        private List<PlayButton> _Buttons = new List<PlayButton>();
        private PlayButton _SelectedButton;
        private bool IsVisible
        {
            get
            {
                return _Canvas.gameObject.activeSelf;
            }
        }
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
            if (_Canvas)
            {
                _Canvas.gameObject.SetActive(Singleton<HScene>.Instance);

                if(IsVisible)
                {
                    _Buttons.Clear();
                    foreach (var stopControl in FindObjectsOfType<SpriteGaugeStopCtrl>())
                    {
                        var button = new PlayButton();
                        var toggle = stopControl.GetComponent<Toggle>();
                        button.OnSelect.AddListener(delegate { toggle.OnPointerEnter(null); });
                        button.OnUnselect.AddListener(delegate { toggle.OnPointerExit(null); });
                        button.OnActivate.AddListener(delegate { toggle.isOn = !toggle.isOn; stopControl.OnChangeValueStopFeel(toggle.isOn); });
                        button.Degrees = 45;

                        if (stopControl.name.Contains("Female"))
                        {
                            button.StartAngle = 270 - 10 - button.Degrees;
                        }
                        else
                        {
                            button.StartAngle = 270 + 10;
                        }

                        _Buttons.Add(button);
                    }
                }
            }
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
            PlayButton selectedButton = null;
            if (IsTracking && IsVisible)
            {
                var device = this.Controller;

                var tPadPos = device.GetAxis();
                var tPadTouch = device.GetTouch(EVRButtonId.k_EButton_SteamVR_Touchpad);
                var tPadPress = device.GetPress(EVRButtonId.k_EButton_SteamVR_Touchpad);
                var tPadRelease = device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad);
                var triggerState = device.GetAxis(EVRButtonId.k_EButton_Axis1).x;

                if (device.GetTouchDown(EVRButtonId.k_EButton_Axis0))
                {
                    prevVal = tPadPos.y;
                    val = 0;
                }
                if (tPadTouch && !tPadRelease)
                {
                    // Normalize
                    var magnitude = tPadPos.magnitude;
                    if (magnitude < 0.4f)
                    {
                        val += (tPadPos.y - prevVal) * 5;
                        while (Mathf.Abs(val) >= 1)
                        {
                            Owner.StartRumble(new RumbleImpulse(200));
                            VR.Input.Mouse.VerticalScroll(val > 0 ? 1 : -1);
                            val = val > 0 ? (val - 1) : (val + 1);
                        }
                    } else if(magnitude > 0.6f)
                    {
                        selectedButton = DetermineSelectedButton(tPadPos);
                    }

                    prevVal = tPadPos.y;
                }

                if (tPadRelease)
                {
                    if (_SelectedButton != null)
                    {
                        _SelectedButton.OnActivate.Invoke();
                    }
                }
            }

            // Update selected button
            if (_SelectedButton != selectedButton)
            {
                if (_SelectedButton != null)
                {
                    _SelectedButton.OnUnselect.Invoke();
                }
                _SelectedButton = selectedButton;
                if (_SelectedButton != null)
                {
                    _SelectedButton.OnSelect.Invoke();
                }
            }
        }
        
        protected override void OnDestroy()
        {
        }

        private PlayButton DetermineSelectedButton(Vector2 touchPosition)
        {
            PlayButton selectedButton = null;
            if(touchPosition.magnitude > 0.3f)
            {
                var normalized = touchPosition.normalized;
                var currentPoint = Mathf.Atan2(normalized.y, normalized.x) * Mathf.Rad2Deg;
                while (currentPoint < 0) currentPoint += 360;

                selectedButton = _Buttons.FirstOrDefault(button => button.StartAngle <= currentPoint && button.StartAngle + button.Degrees >= currentPoint);
                VRLog.Info("Angle: {0} of {1}", currentPoint, _Buttons.Count);
                if (selectedButton != null)
                {
                    VRLog.Info("Found a button: {0}", selectedButton.GetType().FullName);
                }

            }

            return selectedButton;
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
