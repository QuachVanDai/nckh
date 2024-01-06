using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class dragAndDrop : MonoBehaviour
{
    public inventoryManager inventoryManager;
    private void Update()
    {
        inventoryManager.itemCursor.SetActive(inventoryManager.isMovingItem);
        inventoryManager.itemCursor.transform.position = Input.mousePosition;
        if (inventoryManager.isMovingItem) { inventoryManager.itemCursor.GetComponent<Image>().
                sprite = inventoryManager.movingSlot.getItemSO().icon; }


        if (Input.GetMouseButtonDown(1))
        {
            if (!inventoryManager.isMovingItem)
            {
                inventoryManager.BeginItemMove();
            }
            else
            {
                inventoryManager.EndItemMove();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            inventoryManager.showInforItem();
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            if (isMovingItem)
            {
                EndItemMove();
            }
        }*/
    }
 
}
