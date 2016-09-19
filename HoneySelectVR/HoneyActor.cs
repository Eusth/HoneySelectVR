using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRGIN.Core;

namespace HoneySelectVR
{
    public class HoneyActor : DefaultActor<CharInfo>
    {
        private GameObject _HeadRoot;
        private TransientHead _Head;

        public HoneyActor(CharInfo nativeActor) : base(nativeActor)
        {
            _Head = nativeActor.gameObject.AddComponent<TransientHead>();
        }

        private Transform _Eyes;
        public override Transform Eyes
        {
            get
            {
                return _Head.Eyes;
                //return Actor.GetReferenceInfo(CharReference.RefObjKey.AP_Nose).transform;
            }
        }

        public override bool HasHead
        {
            get
            {
                return _Head.Visible;
            }
            set
            {
                _Head.Visible = value;
            }
        }
    }
}
