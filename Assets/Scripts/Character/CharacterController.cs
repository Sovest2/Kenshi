using System;
using UnityEngine;

namespace Kenshi.Character
{
    public class CharacterController : MonoBehaviour
    {
        private Character _character;

        private void Awake()
        {
            Character.OnSelect += HandleSelect;
        }

        private void OnDestroy()
        {
            Character.OnSelect -= HandleSelect;
        }

        private void HandleSelect(Character character)
        {
            _character = character;
        }

        private void Update()
        {
            if(_character == null)
                return;
            
            if(Input.GetButtonDown("Fire2"))
                _character.ChangeState(_character.MoveState);
        }
    }
}
