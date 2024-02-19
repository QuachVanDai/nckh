
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : SelectItem
{
    public InventoryManager inventoryManager;
    public InventoryUpdate inventoryUpdate;
    /*private void Update()
    {
        inventoryManager.ItemCursor.SetActive(inventoryUpdate.isMovingItem);
        inventoryManager.ItemCursor.transform.position = Input.mousePosition;
        if (inventoryUpdate.isMovingItem) { inventoryManager.ItemCursor.GetComponent<Image>().
                sprite = inventoryUpdate.movingSlot.getItemSO().Icon; }


        if (Input.GetMouseButtonDown(1))
        {
            if (!inventoryUpdate.isMovingItem)
            {
                inventoryUpdate.BeginItemMove();
            }
            else
            {
                inventoryUpdate.EndItemMove();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            inventoryUpdate.showInforItem();
        }
        *//*if (Input.GetMouseButtonUp(0))
        {
            if (isMovingItem)
            {
                EndItemMove();
            }
        }*//*
    }*/
 
}
