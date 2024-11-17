


using UnityEngine;

public class InventoryPlayer : InventoryManager
{
    public void RemoveItem()
    {
        for (int i = 0; i < SizeInventory; i++)
        {
            try
            {
                if (ItemSlots[i] == ItemClick)
                {
                    ItemSlots[i].SubQuantity(1);
                    if (ItemSlots[i].GetQuantity() <= 0)
                    {
                        ItemSlots.RemoveAt(i);
                    }
                    break;
                }
            }
            catch
            {
                break;
            }

        }
        Refresh();

    }
    public void AddItem(ItemSlot _itemSlot)
    {
        for (int i = 0; i < SizeInventory; i++)
        {
            Debug.Log(_itemSlot.GetItemSO().Name);
            try
            {
                if (ItemSlots[i].GetItemSO().Name == _itemSlot.GetItemSO().Name)
                {
                    ItemSlots[i].AddQuantity(1);
                    Refresh();
                    break;
                }
            }
            catch
            {
                ItemSlots.Add(_itemSlot);
                Refresh();
                break;
            }
        }
    }
}
