using UnityEngine;

namespace Kenshi.Character.States
{
    public class IdleBehaviour : StateMachineBehaviour
    {
        private Character _character;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _character = animator.GetComponent<Character>();
            _character.ExecuteCommand();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // if(animator.)
            // _character.ExecuteCommand();
        }
    }
    
}
