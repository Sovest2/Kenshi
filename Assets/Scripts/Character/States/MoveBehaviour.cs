using UnityEngine;
using UnityEngine.AI;

namespace Kenshi.Character.States
{
    public class MoveBehaviour : StateMachineBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Property = Animator.StringToHash("Movement Speed");

        private Vector3 _destination;
        private Animator _animator;
        private NavMeshAgent _agent;

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _agent = animator.GetComponent<NavMeshAgent>();
            _agent.SetDestination(_destination);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat(Property, _agent.velocity.magnitude / _agent.speed);
            
            if (_agent.remainingDistance <= _agent.stoppingDistance)
                Stop();
            
            if(!_agent.hasPath)
                Stop();
        }

        private void Stop()
        {
            _agent.SetDestination(_agent.transform.position);
            _animator.SetTrigger(Idle);
        }
    }
    
}
