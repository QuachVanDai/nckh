
using UnityEngine;
using UnityEngine.UI;

public class dragAndDrop : NCKHMonoBehaviour
{
    public inventoryManager inventoryManager;
    public inventoryUpdate inventoryUpdate;
    private void Update()
    {
        inventoryManager.itemCursor.SetActive(inventoryUpdate.isMovingItem);
        inventoryManager.itemCursor.transform.position = Input.mousePosition;
        if (inventoryUpdate.isMovingItem) { inventoryManager.itemCursor.GetComponent<Image>().
                sprite = inventoryUpdate.movingSlot.getItemSO().icon; }


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
        /*if (Input.GetMouseButtonUp(0))
        {
            if (isMovingItem)
            {
                EndItemMove();
            }
        }*/
    }
 
}
