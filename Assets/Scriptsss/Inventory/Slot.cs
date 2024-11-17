using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public InventoryManager InventoryManager;
    public ItemSlot slot;
    public Image Icon;
    public Text TxtQuantity;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Dai: Click Slot");
        InventoryManager.SetInforItem(slot);
        InventoryManager.ItemClick = slot;
    }

    public void SetSlot(ItemSlot _slot)
    {
        slot = _slot;
        if (_slot == null)
        {
            Icon.sprite = null;
            Icon.color = new Color(1,1,1,0);
            TxtQuantity.text = "";
        }
        else
        {
            Icon.sprite = _slot.Item.Icon;
            Icon.color = new Color(1, 1, 1, 1);
            Icon.enabled = true;
            if (_slot.GetItemSO().IsStackable)
            {
                TxtQuantity.text = _slot.Quantity.ToString();
            }
            else
            {
                TxtQuantity.text = "";
            }
        }
    }
}
