
using UnityEngine.EventSystems;

public  class confirmRemoveItem : selectItem
{
    public inventoryUpdate inventoryUpdate;
    public override void OnPointerDown(PointerEventData eventData)
    {
       base.OnPointerDown(eventData);
        inventoryUpdate.i = this.SlotClass.getItemSO();
    }
}
