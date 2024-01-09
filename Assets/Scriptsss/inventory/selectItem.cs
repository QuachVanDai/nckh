using UnityEngine.EventSystems;

public abstract  class selectItem : NCKHMonoBehaviour, IPointerDownHandler
{
    public inventoryManager inventoryManager;
    private slotClass _slotClass ;
    public slotClass SlotClass{ get { return _slotClass; } set { _slotClass = value; } }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _slotClass = inventoryManager.GetClosestSLot();
    }
}
