using UnityEngine.EventSystems;

public  class ConfirmBuyItem : SelectItem
{
    public BuyItem buyItem;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        buyItem.item = this.SlotClass;
    }
}
