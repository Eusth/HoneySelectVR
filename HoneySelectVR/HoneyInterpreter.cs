using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;
using System.Linq;

namespace HoneySelectVR
{
    internal class HoneyInterpreter : GameInterpreter
    {
        public HScene Scene;
        private List<HoneyActor> _Actors = new List<HoneyActor>();
        private Camera _SubCamera;

        protected override void OnStart()
        {
            base.OnStart();

            //VR.GUI.AddGrabber(new CameraConsumer());

            // Create secondary camera
            //_SubCamera = UnityHelper.CreateGameObjectAsChild("VRGIN_SubCamera", VR.Camera.Origin.transform, true).gameObject.AddComponent<Camera>();
            //_SubCamera.gameObject.AddComponent<SteamVR_Camera>();

            //var vrCamera = VR.Camera.GetComponent<Camera>();
            //_SubCamera.cullingMask = VR.Context.IgnoreMask;

            //_SubCamera.clearFlags = CameraClearFlags.Depth;
            //_SubCamera.nearClipPlane = vrCamera.nearClipPlane;
            //_SubCamera.farClipPlane = vrCamera.farClipPlane;
            //_SubCamera.depth = vrCamera.depth + 1;
        }

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            Scene = FindObjectOfType<HScene>();
        }

        public override IActor FindNextActorToImpersonate()
        {
            var actors = Actors.ToList();
            var currentlyImpersonated = FindImpersonatedActor();

            return currentlyImpersonated != null
                ? actors[(actors.IndexOf(currentlyImpersonated) + 1) % actors.Count]
                : actors.FirstOrDefault();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            // Refresh actors
            _Actors.Clear();

            // Males
            foreach(var male in Character.Instance.dictMale.Values)
            {
                if (male.LoadEnd)
                {
                    AddActor(HoneyActor.Create<HoneyActor>(male));
                }
            }
            foreach(var female in Character.Instance.dictFemale.Values)
            {
                if (female.LoadEnd)
                {
                    AddActor(HoneyActor.Create<HoneyActor>(female));
                }
            }
        }     

        private void AddActor(HoneyActor actor)
        {
            if (!actor.Eyes)
            {
                actor.Head.Reinitialize();
            }
            else
            {
                _Actors.Add(actor);
            }
        }
        
        public override IEnumerable<IActor> Actors
        {
            get
            {
                return _Actors.Cast<IActor>();
            }
        }

        public override bool IsAllowedEffect(MonoBehaviour effect)
        {
            return !(VR.Settings as HoneySettings).EffectBlacklist.Contains(effect.GetType().Name);
        }

        //public override bool IsBody(Collider collider)
        //{
        //    VRLog.Info("{0} ({1})", collider.name, LayerMask.LayerToName(collider.gameObject.layer));
        //    return base.IsBody(collider);
        //}

    }
}