using System;
using System.Collections.Generic;
using System.Linq;
using Kenshi.Character;
using Kenshi.Character.Commands;
using Kenshi.Environment.Interactable;
using UnityEngine;

public class Seat : MonoBehaviour, IInteractable
{
    [SerializeField] private List<SeatPoint> _seatPoints;

    public ICommand Interact(Character character)
    {
        return new SitCommand(character, this);
    }

    public bool TryGetFreeSeatPoint(out SeatPoint point)
    {
        point = _seatPoints.FirstOrDefault(x => !x.IsOccupied);
        return point != null;
    }
}
