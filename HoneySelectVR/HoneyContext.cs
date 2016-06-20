using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Visuals;

namespace HoneySelectVR
{
    internal class HoneyContext : IVRManagerContext
    {
        DefaultMaterialPalette _Materials;
        VRSettings _Settings;
        public HoneyContext()
        {
            _Materials = new DefaultMaterialPalette();
            _Settings = VRSettings.Load<VRSettings>("vr_settings.xml");

            //_Materials.StandardShader = Shader.Find("Marmoset/Specular IBL");
        }


        public bool GUIAlternativeSortingMode
        {
            get
            {
                return false;
            }
        }

        public string GuiLayer
        {
            get
            {
                return "Default";
            }
        }

        public string HMDLayer
        {
            get
            {
                return "Ignore Raycast";
            }
        }

        public string[] IgnoredCanvas
        {
            get
            {
                return new string[] { };
            }
        }

        public IMaterialPalette Materials
        {
            get
            {
                return _Materials;
            }
        }

        public Color PrimaryColor
        {
            get
            {
                return Color.cyan;
            }
        }

        public VRSettings Settings
        {
            get
            {
                return _Settings;
            }
        }

        public int UILayerMask
        {
            get
            {
                return LayerMask.GetMask(UILayer);
            }
        }

        public string UILayer
        {
            get
            {
                return "UI";
            }
        }

        public bool SimulateCursor
        {
            get
            {
                return true;
            }
        }
    }
}