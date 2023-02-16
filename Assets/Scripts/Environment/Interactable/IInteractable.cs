using Kenshi.Character.Commands;

namespace Kenshi.Environment.Interactable
{
    public interface IInteractable
    {
        public ICommand Interact(Character.Character character);
    }
}
