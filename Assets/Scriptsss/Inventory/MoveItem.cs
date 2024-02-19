using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MoveItem : SelectItem, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Slot movingSlot;
    public Slot originalSlot;
    public GameObject ItemCursor;
    public bool IsMoveItem;

    private int PosSlot;
    public void OnDrag(PointerEventData eventData)
    {
        if (!IsMoveItem) return;
        ItemCursor.SetActive(true);
        ItemCursor.transform.position = Input.mousePosition;
        ItemCursor.GetComponent<Image>().sprite = movingSlot.getItemSO().Icon;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.InventoryManager.getItems()[this.PosItem()].getItemSO()){
            originalSlot = this.InventoryManager.getItems()[this.PosItem()];
            movingSlot = new Slot(originalSlot);
            IsMoveItem = true;
            originalSlot.Clear();
            this.InventoryManager.RefreshUI();
        }
       // HideImage();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsMoveItem = false;
        ItemCursor.SetActive(false);
        if (GetClosestSlot()==-1)
        {
            this.InventoryManager.setItem(movingSlot,this.PosItem());
            this.InventoryManager.RefreshUI();
        }
        else
        {
            if (this.InventoryManager.getItems()[PosSlot].getItemSO() != null)
            {
                if (this.InventoryManager.getItems()[PosSlot].getItemSO().ItemName == movingSlot.getItemSO().ItemName)
                {

                    movingSlot.addQuantity(this.InventoryManager.getItems()[PosSlot].getQuantity());
                    this.InventoryManager.setItem(movingSlot, PosSlot);
                }
                else
                {
                    this.InventoryManager.setItem(this.InventoryManager.getItems()[PosSlot], this.PosItem());
                    this.InventoryManager.setItem(movingSlot, PosSlot);
                }
            }

            else
            {
                this.InventoryManager.setItem(movingSlot, PosSlot);
            }
            this.InventoryManager.RefreshUI();
        }
    }
    public int GetClosestSlot()
    {
        PosSlot = -1;
        for (int i = 0; i < this.InventoryManager.getSlots().Length; i++)
        {
            if (Vector2.Distance(this.InventoryManager.getSlots()[i].transform.position, Input.mousePosition) <= 29)
            {
                PosSlot = i;
                return PosSlot;
            }
        }
        return PosSlot;
    }
    

}
