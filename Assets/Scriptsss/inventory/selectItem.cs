using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selectItem : MonoBehaviour,IPointerDownHandler
{
    public inventoryManager inventoryManager;
    public buyItem buyItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryManager == null) { buyItem.item.Clear(); return; }
        buyItem.item = inventoryManager.GetClosestSLot();
    }

}
