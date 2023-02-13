using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusTarget : MonoBehaviour, IPointerClickHandler
{
    private const int ClicksToSelect = 2;

    public static event Action<FocusTarget> OnSelect;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.button.Equals(PointerEventData.InputButton.Left))
            return;

        if(eventData.clickCount < ClicksToSelect)
            return;
        
        OnSelect?.Invoke(this);
    }
}
