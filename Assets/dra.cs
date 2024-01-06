using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dra : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public inventoryManager inventoryManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        inventoryManager.BeginItemMove();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("shsq2");

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("shs3");
        inventoryManager.EndItemMove();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("shs4");

    }
}
