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
        private IList<HoneyActor> _Actors = new List<HoneyActor>();

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            Scene = GameObject.FindObjectOfType<HScene>();
            StartCoroutine(DelayedInit());
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        IEnumerator DelayedInit()
        {
            var scene = Singleton<Scene>.Instance;
            if (!scene)
                VRLog.Error("No scene");

            while(scene.IsNowLoading)
            {
                yield return null;
            }

            foreach(var actor in GameObject.FindObjectsOfType<CharInfo>())
            {
                _Actors.Add(new HoneyActor(actor));
            }

            _Actors = _Actors.OrderBy(a => a.Actor.Sex).ToList();
            
            VRLog.Info("Found {0} chars", _Actors.Count);
        }


        public override IEnumerable<IActor> Actors
        {
            get
            {
                return _Actors.Cast<IActor>();
            }
        }

    }
}