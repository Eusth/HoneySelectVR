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
    public class HoneyActor : DefaultActor<CharInfo>
    {
        private GameObject _HeadRoot;
        public TransientHead Head { get; private set; }

        public HoneyActor(CharInfo nativeActor) : base(nativeActor)
        {
            Head = nativeActor.gameObject.AddComponent<TransientHead>();

            if (Actor.Sex == 1) // Only females!
            {
                var lookAtMe = nativeActor.gameObject.AddComponent<LookAtMeYouCuteLittleThing>();
                lookAtMe.Actor = this;
            }

            //nativeActor.chaBody.asVoice.spatialBlend = 1f;
            //nativeActor.chaBody.asVoice.spatialize = true;
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

        private class LookAtMeYouCuteLittleThing : ProtectedBehaviour
        {
            public HoneyActor Actor;

            private LookTargetController _TargetController;
            private Transform _MainCamera;

            protected override void OnStart()
            {
                base.OnStart();
                _TargetController = LookTargetController.Attach(Actor);
                _MainCamera = Camera.main.transform;
            }

            protected override void OnUpdate()
            {
                base.OnUpdate();

                var eyeLook = Actor.Actor.chaBody.eyeLookCtrl;
                var neckLook = Actor.Actor.chaBody.neckLookCtrl;

                if(eyeLook && eyeLook.target == _MainCamera)
                {
                    eyeLook.target = _TargetController.Target;
                }

                if(neckLook && neckLook.target == _MainCamera)
                {
                    neckLook.target = _TargetController.Target;
                }
            }
        }
    }
}
