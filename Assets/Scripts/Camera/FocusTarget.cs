using System;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    public static event Action<FocusTarget> OnSelect;

    private void OnMouseDown()
    {
        OnSelect?.Invoke(this);
    }
}
