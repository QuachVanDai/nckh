using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MoveItem : Select, IDragHandler, IBeginDragHandler, IEndDragHandler
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
        if (this.GetSlotItem().getItemSO()){
            originalSlot = this.GetSlotItem();
            movingSlot = new Slot(originalSlot);
            IsMoveItem = true;
            originalSlot.Clear();
            this.InventoryManager.RefreshUI();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsMoveItem = false;
        ItemCursor.SetActive(false);
        if (GetClosestSlot()==-1)
        {
            this.InventoryManager.setSlotItem(movingSlot,this.PosItem());
            this.InventoryManager.RefreshUI();
        }
        else
        {
            if (this.GetSlotItem(PosSlot).getItemSO() != null)
            {
                if (this.GetSlotItem(PosSlot).getItemSO().itemName == movingSlot.getItemSO().itemName)
                {

                    movingSlot.UpdateQuantity(this.GetSlotItem(PosSlot).getQuantity());
                    this.InventoryManager.setSlotItem(movingSlot, PosSlot);
                }
                else
                {
                    this.InventoryManager.setSlotItem(this.GetSlotItem(PosSlot), this.PosItem());
                    this.InventoryManager.setSlotItem(movingSlot, PosSlot);
                }
            }
            else
            {
                this.InventoryManager.setSlotItem(movingSlot, PosSlot);
            }
            this.InventoryManager.RefreshUI();
        }
    }
    public int GetClosestSlot()
    {
        PosSlot = -1;
        for (int i = 0; i < this.InventoryManager.getSlotGameObject().Length; i++)
        {
            if (Vector2.Distance(this.InventoryManager.getSlotGameObject()[i].transform.position, Input.mousePosition) <= 29)
            {
                PosSlot = i;
                return PosSlot;
            }
        }
        return PosSlot;
    }
    

}
