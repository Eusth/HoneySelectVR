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

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            Scene = GameObject.FindObjectOfType<HScene>();
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

        //public override bool IsBody(Collider collider)
        //{
        //    VRLog.Info("{0} ({1})", collider.name, LayerMask.LayerToName(collider.gameObject.layer));
        //    return base.IsBody(collider);
        //}

    }
}