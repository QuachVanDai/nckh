using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dra : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public inventoryUpdate inventoryUpdate;
    public void OnPointerDown(PointerEventData eventData)
    {
        inventoryUpdate.BeginItemMove();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("shsq2");
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventoryUpdate.EndItemMove();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("shs4");

    }
}
