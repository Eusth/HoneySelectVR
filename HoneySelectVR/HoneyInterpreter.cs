using System;
using System.Collections.Generic;
using UnityEngine;
using VRGIN.Core;

namespace HoneySelectVR
{
    internal class HoneyInterpreter : GameInterpreter
    {
        private new Camera camera;

        public override IEnumerable<IActor> Actors
        {
            get
            {
                yield break;
            }
        }
        private Camera lastCamera;

        //protected override void OnUpdate()
        //{
        //    var newCamera = FindCamera();

        //    if (!camera && newCamera)
        //    {
        //        VR.Camera.Copy(newCamera);
        //    }

        //    camera = newCamera;
        //}
    }
}