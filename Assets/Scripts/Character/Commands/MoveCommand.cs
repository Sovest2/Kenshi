using Kenshi.Character.States;
using UnityEngine;

namespace Kenshi.Character.Commands
{
    public class MoveCommand : ICommand
    {
        private static readonly int Move = Animator.StringToHash("Move");
        
        private Character _character;
        private Vector3 _destination;

        public MoveCommand(Character character, Vector3 destination)
        {
            _character = character;
            _destination = destination;
        }

        public void Execute()
        {
            _character.Animator.SetTrigger(Move);
            _character.Animator.GetBehaviour<MoveBehaviour>().SetDestination(_destination);
        }
    }
}
