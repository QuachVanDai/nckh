using UnityEngine.EventSystems;

public  class ConfirmBuyItem : SelectItem
{
    public BuyItem buyItem;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //buyItem.item = this.ItemSlot;
    }
}
