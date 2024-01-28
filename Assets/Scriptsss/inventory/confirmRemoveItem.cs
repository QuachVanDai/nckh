
using UnityEngine.EventSystems;

public  class ConfirmRemoveItem : SelectItem
{
    public InventoryUpdate inventoryUpdate;
    public override void OnPointerDown(PointerEventData eventData)
    {
       base.OnPointerDown(eventData);
        inventoryUpdate.i = this.SlotClass.getItemSO();
    }
}
