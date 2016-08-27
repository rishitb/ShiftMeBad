using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

/// <summary>
/// Should be attached to all UI Buttons
/// </summary>
public class ButtonDesignator : MonoBehaviour,IPointerDownHandler {

    public ShapeGlobalVars.ButtonTypes buttonType;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonHandler.Instance.HandleButtonClick(buttonType);
    }
}
