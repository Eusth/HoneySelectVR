using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;
using static Config.VoiceSystem;

namespace HoneySelectVR
{
    public class HoneyActor : DefaultActorBehaviour<CharInfo>
    {
        public TransientHead Head { get; private set; }

        private LookTargetController _TargetController;

        protected override void Initialize(CharInfo actor)
        {
            base.Initialize(actor);

            Head = actor.gameObject.AddComponent<TransientHead>();
        }

        public override Transform Eyes
        {
            get
            {
          
                return Head.Eyes;
                //return Actor.GetReferenceInfo(CharReference.RefObjKey.AP_Nose).transform;
            }
        }

        public override bool HasHead
        {
            get
            {
                return Head.Visible;
            }
            set
            {
                Head.Visible = value;
            }
        }

        public bool IsFemale
        {
            get
            {
                return Actor.Sex == 1;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (IsFemale)
            {
                VRLog.Info("Create target controller");
                _TargetController = LookTargetController.AttachTo(this, gameObject);
            }
        }

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);
        }


        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();

            if (IsFemale)
            {
                var eyeLook = Actor.chaBody.eyeLookCtrl;
                var neckLook = Actor.chaBody.neckLookCtrl;
                var mainCamera = Camera.main.transform;

                if (mainCamera)
                {
                    if (eyeLook && eyeLook.target == mainCamera)
                    {

                        eyeLook.target = _TargetController.Target;
                    }

                    if (neckLook && neckLook.target == mainCamera)
                    {

                        neckLook.target = _TargetController.Target;
                    }
                }
                //UnityHelper.DrawDebugBall(_TargetController.Target);
            }
        }

    }
}
