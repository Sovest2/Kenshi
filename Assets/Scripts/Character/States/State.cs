using System;
using UnityEngine;

namespace Kenshi.Character.States
{
    [Serializable]
    public class State
    {
        protected Character _character;
        [SerializeField] private string _parameter;
        
        public virtual void Enter(Character character)
        {
            _character = character;
            
            if(string.IsNullOrEmpty(_parameter))
                return;
            
            _character.Animator.SetBool(_parameter, true);
        }

        public virtual void Update()
        {
            
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void Exit()
        {
            if(string.IsNullOrEmpty(_parameter))
                return;
            
            _character.Animator.SetBool(_parameter, false);
        }
    }
}
