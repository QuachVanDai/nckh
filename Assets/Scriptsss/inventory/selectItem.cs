using UnityEngine.EventSystems;
using UnityEngine;

public abstract  class SelectItem :MonoBehaviour, IPointerDownHandler
{
    public InventoryManager inventoryManager;
    private SlotClass _slotClass ;
    public SlotClass SlotClass{ get { return _slotClass; } set { _slotClass = value; } }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _slotClass = inventoryManager.GetClosestSLot();
    }
}
