
using UnityEngine.EventSystems;

public  class ConfirmRemoveItem : SelectItem
{
    public InventoryUpdate inventoryUpdate;
    public override void OnPointerClick(PointerEventData eventData)
    {
       base.OnPointerClick(eventData);
       // inventoryUpdate.i = this.ItemSlot.getItemSO();
    }
}
