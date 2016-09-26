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
        private FieldInfo _FemaleField = typeof(HScene).GetField("chaFemale", BindingFlags.NonPublic | BindingFlags.Instance);
        private FieldInfo _MaleField = typeof(HScene).GetField("chaMale", BindingFlags.NonPublic | BindingFlags.Instance);
        private HoneyActor _Female;
        private HoneyActor _Male;

        protected override void OnLevel(int level)
        {
            base.OnLevel(level);

            Scene = GameObject.FindObjectOfType<HScene>();
            if (Scene)
            {
                StartCoroutine(DelayedInit());
            }
            
            _Male = null;
            _Female = null;
            
        }
    
        private IEnumerator DelayedInit()
        {
            yield return null;
            yield return null;

            var characterController = Character.Instance;
            if(characterController)
            {
                var male = characterController.dictMale.Values.FirstOrDefault();
                var female = characterController.dictFemale.Values.FirstOrDefault();

                if(male)
                    _Male = new HoneyActor(male);
                if(female)
                    _Female = new HoneyActor(female);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
        
        public override IEnumerable<IActor> Actors
        {
            get
            {

                foreach(var actor in new HoneyActor[] { _Male, _Female })
                {
                    if(actor != null && actor.Actor && actor.Actor.chaBody.eyeLookCtrl)
                    {
                        if(!actor.Eyes)
                        {
                            actor.Head.Reinitialize();
                        }
                        yield return actor;
                    }
                }
            }
        }

    }
}