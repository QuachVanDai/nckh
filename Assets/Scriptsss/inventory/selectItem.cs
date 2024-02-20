using UnityEngine.EventSystems;

public class SelectItem : Select
{
    public BuyItem BuyItem;
    public RemoveItem RemoveItem;
    public int number;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if(number == 0)
            BuyItem.Slot = this.GetSlotItem();
        else if (number == 1)
            RemoveItem.index = this.PosItem();

    }
}
