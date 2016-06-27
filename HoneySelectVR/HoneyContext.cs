using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Visuals;

namespace HoneySelectVR
{
    enum Levels
    {
        ADV = 5,
        ADV2 = 8,
        Customization = 7
    }

    internal class HoneyContext : IVRManagerContext
    {
        DefaultMaterialPalette _Materials;
        HoneySettings _Settings;
        public HoneyContext()
        {
            _Materials = new DefaultMaterialPalette();
            _Settings = VRSettings.Load<HoneySettings>("vr_settings.xml");

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

        public string InvisibleLayer
        {
            get
            {
                return "Ignore Raycast";
            }
        }
    }
}