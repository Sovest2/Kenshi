using UnityEngine;

namespace Kenshi.Character.Commands
{
    public class SitCommand : ICommand
    {
        private static readonly int SitTrigger = Animator.StringToHash("Sit");
        private Character _character;
        private Seat _seat;
        private SeatPoint _point;

        public SitCommand(Character character, Seat seat)
        {
            _character = character;
            _seat = seat;
        }
    
        public bool Execute()
        {
            if (!_seat.TryGetFreeSeatPoint(out _point))
                return false;
               
            _character.Animator.SetTrigger(SitTrigger);
            
            _point.Occupy(_character);
            _character.OnCommandExecuted += HandleCommandExecuted;
            return true;
        }

        public void HandleCommandExecuted(ICommand command)
        {
            if(command == this)
                return;

            _point.Occupy(null);
            _character.OnCommandExecuted -= HandleCommandExecuted;
        }
    }
}