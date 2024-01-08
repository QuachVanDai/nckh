using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract  class selectItem : NCKHMonoBehaviour, IPointerDownHandler
{
    public inventoryManager inventoryManager;
    private slotClass _slotClass ;
    public slotClass SlotClass{ get { return _slotClass; } set { _slotClass = value; } }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _slotClass = inventoryManager.GetClosestSLot();
    }
}
