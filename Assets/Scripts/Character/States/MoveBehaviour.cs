using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kenshi.Character.States
{
    public class MoveBehaviour : StateMachineBehaviour
    {
        private Vector3 _destination;
        private Character _character;
        public void SetDestination(Vector3 destionation)
        {
            _destination = destionation;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _character = animator.GetComponent<Character>();
            _character.Agent.SetDestination(_destination);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_character.Agent.remainingDistance <= _character.Agent.stoppingDistance)
            {
                animator.SetTrigger("Idle");
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _character.Agent.SetDestination(_character.transform.position);
        }
    }
    
}
