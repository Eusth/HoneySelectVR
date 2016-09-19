using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;

namespace HoneySelectVR
{
    internal class HoneyInterpreter : GameInterpreter
    {
        public HScene Scene;
        private IList<IActor> _Actors = new List<IActor>();

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            Scene = InitScene(GameObject.FindObjectOfType<HScene>());
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        private HScene InitScene(HScene scene)
        {
            _Actors.Clear();
            if(scene)
            {
                StartCoroutine(DelayedInit());
            }
            return scene;
        }

        IEnumerator DelayedInit()
        {
            yield return null;
            yield return null;
            var charFemaleField = typeof(HScene).GetField("chaFemale", BindingFlags.NonPublic | BindingFlags.Instance);
            var charMaleField = typeof(HScene).GetField("chaMale", BindingFlags.NonPublic | BindingFlags.Instance);

            var female = charFemaleField.GetValue(Scene) as CharFemale;
            var male = charMaleField.GetValue(Scene) as CharMale;

            if (male)
            {
                _Actors.Add(new HoneyActor(male));
            }
            if (female)
            {
                _Actors.Add(new HoneyActor(female));
            }
            
            VRLog.Info("Found {0} chars", _Actors.Count);
        }


        public override IEnumerable<IActor> Actors
        {
            get
            {
                return _Actors;
            }
        }

    }
}