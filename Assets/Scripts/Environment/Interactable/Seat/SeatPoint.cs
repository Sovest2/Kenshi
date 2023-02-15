using Kenshi.Character;
using UnityEngine;

public class SeatPoint : MonoBehaviour
{
    public bool IsOccupied => _occupiedBy != null;

    private Character _occupiedBy;

    public void Occupy(Character character)
    {
        _occupiedBy = character;
    }

    private void Update()
    {
        if (!IsOccupied) return;

        _occupiedBy.transform.position = transform.position;
        _occupiedBy.transform.forward = transform.forward;
    }
}
