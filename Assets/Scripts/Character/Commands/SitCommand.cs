using UnityEngine;

namespace Kenshi.Character.Commands
{
    public class SitCommand : ICommand
    {
        private static readonly int SitTrigger = Animator.StringToHash("Sit");
        private Character _character;
        private Seat _seat;
        private SeatPoint point;

        public SitCommand(Character character, Seat seat)
        {
            _character = character;
            _seat = seat;
        }
    
        public bool Execute()
        {
            if (!_seat.TryGetFreeSeatPoint(out point))
                return false;
               
            _character.Animator.SetTrigger(SitTrigger);

            
            _character.transform.position = point.transform.position;
            _character.transform.forward = point.transform.forward;

            point.IsOccupied = true;
            _character.OnCommandExecuted += HandleCommandExecuted;
            return true;
        }

        public void HandleCommandExecuted(ICommand command)
        {
            if(command == this)
                return;

            point.IsOccupied = false;
            _character.OnCommandExecuted -= HandleCommandExecuted;
        }
    }
}