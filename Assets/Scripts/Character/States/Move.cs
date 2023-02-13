using System;
using UnityEngine;

namespace Kenshi.Character.States
{
    [Serializable]
    public class Move : State
    {
        private UnityEngine.Camera _camera;
        private Vector3 _destination;
        
        public override void Enter(Character character)
        {
            base.Enter(character);
            if (_camera == null)
                _camera = UnityEngine.Camera.main;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
            {
                Exit();
                return;
            }

            _destination = hit.point;
            
            if(!_character.Agent.SetDestination(_destination))
                _character.ChangeState(_character.IdleState);
        }

        public override void Update()
        {
            base.Update();

            if(!_character.Agent.hasPath)
                _character.ChangeState(_character.IdleState);
        }
    }
}
