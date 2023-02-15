using Kenshi.Character;
using Kenshi.Character.Commands;
using Kenshi.Environment.Interactable;
using UnityEngine;

public class Seat : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _seatPoint;

    public ICommand Interact(Character character)
    {
        return new Sit(character, _seatPoint);
    }
}

public class Sit : ICommand
{
    private static readonly int SitTrigger = Animator.StringToHash("Sit");
    private Character _character;
    private Transform _point;

    public Sit(Character character, Transform point)
    {
        _character = character;
        _point = point;
    }
    
    public void Execute()
    {
        _character.Animator.SetTrigger(SitTrigger);
        
        _character.transform.position = _point.position;
        _character.transform.forward = _point.forward;
    }
}
