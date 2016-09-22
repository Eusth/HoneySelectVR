using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRGIN.Core;
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
    }
}
