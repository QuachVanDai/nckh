

using UnityEngine;

public class InventoryUpdate : Singleton<InventoryUpdate>
{
    public InventoryManager InventoryManager;
    public UseHp useHp;
    public UseMp useMp;
    #region update
   
    public void UpdateHP(ItemSlot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].GetItemSO() && InventoryManager.getSlotItems()[i].GetItemSO().Name == ItemName.Hp)
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.Refresh();
                useHp.quanitityText.text = InventoryManager.getSlotItems()[i].GetQuantity().ToString();
                InventoryManager.SetXuText();
                InventoryManager.SetData(InventoryManager.getSlotItems()[i],i);
                return;
            }
        }
        AddItem(slot);
        useHp.quanitityText.text = slot.GetQuantity().ToString();
        InventoryManager.SetXuText();
    }
    public void UpdateMP(ItemSlot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].GetItemSO()
                && InventoryManager.getSlotItems()[i].GetItemSO().Name == ItemName.Mp)
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.Refresh();
                useMp.quanitityText.text = InventoryManager.getSlotItems()[i].GetQuantity().ToString();
                InventoryManager.SetXuText();
                InventoryManager.SetData(InventoryManager.getSlotItems()[i],i);
                return;
            }
        }
        AddItem(slot);
        useMp.quanitityText.text = slot.GetQuantity().ToString();
        InventoryManager.SetXuText();

    }
    int sum = 0;
    bool flat = false;
    PotionSO potion;
  
    public int UpdateHP(int number)
    {
        flat = false;
        sum = 0;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            potion = (PotionSO)InventoryManager.getSlotItems()[i].GetItemSO();
            if (potion && potion.PotionType == PotionType.hp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sum += InventoryManager.getSlotItems()[i].GetQuantity();
                    if (InventoryManager.getSlotItems()[i].GetQuantity() == 0)
                    {
                        RemoveItem(i);
                    }
                    flat = true;
                }
                else
                {
                    sum += InventoryManager.getSlotItems()[i].GetQuantity();
                }
                InventoryManager.SetData(InventoryManager.getSlotItems()[i], i);
            }
        }
        InventoryManager.Refresh();
        useHp.quanitityText.text = sum.ToString();
        return sum;
    }
    public int UpdateMP(int number)
    {
        flat = false;
        sum = 0;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            potion = (PotionSO)InventoryManager.getSlotItems()[i].GetItemSO();
            if (potion && potion.PotionType == PotionType.mp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sum += InventoryManager.getSlotItems()[i].GetQuantity();
                    if (InventoryManager.getSlotItems()[i].GetQuantity() == 0)
                    {
                        RemoveItem(i);
                        
                    }
                    flat = true;
                }
                else
                {
                    sum += InventoryManager.getSlotItems()[i].GetQuantity();
                }
                InventoryManager.SetData(InventoryManager.getSlotItems()[i], i);
            }
        }
        InventoryManager.Refresh();
        useMp.quanitityText.text = sum.ToString();
        return sum;
    }
   
    public bool IsHaveFood()
    {
        PotionSO food;

        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            food = (PotionSO)InventoryManager.getSlotItems()[i].GetItemSO();
            try
            {
                if (food.PotionType == PotionType.food)
                    return true;
            }
            catch
            {

            }

        }
        return false;
    }
    public void AddItem(ItemSlot slot)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
             if (InventoryManager.getSlotItems()[i].GetItemSO() == null)
            {
                InventoryManager.getSlotItems()[i].AddItemSO(slot.GetItemSO(), 1);
                InventoryManager.Refresh();
                InventoryManager.SetXuText();
                InventoryManager.SetData(slot,i);
                return;
            }
        }
    }
    public bool IsHaveBox()
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].GetItemSO() == null)
            {
                return true;
            }
        }
        return false;
    }
 
    public bool RemoveItem(int index)
    {
        ItemSlot slot = InventoryManager.getSlotItems()[index];
        PotionSO potion = (PotionSO)slot.GetItemSO();
        try
        {
            if (potion.PotionType == PotionType.hp)
            {
                if (slot.GetQuantity() == 0)
                    InventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateHP(-1);
            }
            else if (potion.PotionType == PotionType.mp)
            {
                if (slot.GetQuantity() == 0)
                    InventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateMP(-1);
            }
            else
            {
                InventoryManager.getSlotItems()[index].Clear();
                InventoryManager.SetData(InventoryManager.getSlotItems()[index], index);
            }
            InventoryManager.Refresh();
            return true;
        }
        catch
        {
            return false;

        }

    }
    public bool RemoveItem(ItemSlot slot)
    {
        ItemSlot s;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            s = InventoryManager.getSlotItems()[i];
            try
            {
                if (slot.GetItemSO().Name == s.GetItemSO().Name)
                {
                    InventoryManager.getSlotItems()[i].Clear();
                    InventoryManager.SetData(s, i);
                    InventoryManager.Refresh();
                    return true;
                }
            }
            catch
            {

            }
        }
        return false;

    }
    #endregion
}
