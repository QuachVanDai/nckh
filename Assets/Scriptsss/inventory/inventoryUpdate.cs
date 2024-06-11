

using UnityEngine;

public class InventoryUpdate : Singleton<InventoryUpdate>
{
    public InventoryManager InventoryManager;
    public UseHp useHp;
    public UseMp useMp;
    #region update
   
    public void UpdateHP(Slot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO() && InventoryManager.getSlotItems()[i].getItemSO().itemName == ItemName.Hp)
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.RefreshUI();
                useHp.quanitityText.text = InventoryManager.getSlotItems()[i].getQuantity().ToString();
                InventoryManager.SetXuText();
                InventoryManager.SetData(InventoryManager.getSlotItems()[i],i);
                return;
            }
        }
        AddItem(slot);
        useHp.quanitityText.text = slot.getQuantity().ToString();
        InventoryManager.SetXuText();
    }
    public void UpdateMP(Slot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO()
                && InventoryManager.getSlotItems()[i].getItemSO().itemName == ItemName.Mp)
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.RefreshUI();
                useMp.quanitityText.text = InventoryManager.getSlotItems()[i].getQuantity().ToString();
                InventoryManager.SetXuText();
                InventoryManager.SetData(InventoryManager.getSlotItems()[i],i);
                return;
            }
        }
        AddItem(slot);
        useMp.quanitityText.text = slot.getQuantity().ToString();
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
            potion = (PotionSO)InventoryManager.getSlotItems()[i].getItemSO();
            if (potion && potion.PotionType == PotionType.hp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sum += InventoryManager.getSlotItems()[i].getQuantity();
                    if (InventoryManager.getSlotItems()[i].getQuantity() == 0)
                    {
                        RemoveItem(i);
                    }
                    flat = true;
                }
                else
                {
                    sum += InventoryManager.getSlotItems()[i].getQuantity();
                }
                InventoryManager.SetData(InventoryManager.getSlotItems()[i], i);
            }
        }
        InventoryManager.RefreshUI();
        useHp.quanitityText.text = sum.ToString();
        return sum;
    }
    public int UpdateMP(int number)
    {
        flat = false;
        sum = 0;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            potion = (PotionSO)InventoryManager.getSlotItems()[i].getItemSO();
            if (potion && potion.PotionType == PotionType.mp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sum += InventoryManager.getSlotItems()[i].getQuantity();
                    if (InventoryManager.getSlotItems()[i].getQuantity() == 0)
                    {
                        RemoveItem(i);
                        
                    }
                    flat = true;
                }
                else
                {
                    sum += InventoryManager.getSlotItems()[i].getQuantity();
                }
                InventoryManager.SetData(InventoryManager.getSlotItems()[i], i);
            }
        }
        InventoryManager.RefreshUI();
        useMp.quanitityText.text = sum.ToString();
        return sum;
    }
   
    public bool IsHaveFood()
    {
        PotionSO food;

        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            food = (PotionSO)InventoryManager.getSlotItems()[i].getItemSO();
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
    public void AddItem(Slot slot)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
             if (InventoryManager.getSlotItems()[i].getItemSO() == null)
            {
                InventoryManager.getSlotItems()[i].addItemSO(slot.getItemSO(), 1);
                InventoryManager.RefreshUI();
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
            if (InventoryManager.getSlotItems()[i].getItemSO() == null)
            {
                return true;
            }
        }
        return false;
    }
 
    public bool RemoveItem(int index)
    {
        Slot slot = InventoryManager.getSlotItems()[index];
        PotionSO potion = (PotionSO)slot.getItemSO();
        try
        {
            if (potion.PotionType == PotionType.hp)
            {
                if (slot.getQuantity() == 0)
                    InventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateHP(-1);
            }
            else if (potion.PotionType == PotionType.mp)
            {
                if (slot.getQuantity() == 0)
                    InventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateMP(-1);
            }
            else
            {
                InventoryManager.getSlotItems()[index].Clear();
                InventoryManager.SetData(InventoryManager.getSlotItems()[index], index);
            }
            InventoryManager.RefreshUI();
            return true;
        }
        catch
        {
            return false;

        }

    }
    public bool RemoveItem(Slot slot)
    {
        Slot s;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            s = InventoryManager.getSlotItems()[i];
            try
            {
                if (slot.getItemSO().itemName == s.getItemSO().itemName)
                {
                    InventoryManager.getSlotItems()[i].Clear();
                    InventoryManager.SetData(s, i);
                    InventoryManager.RefreshUI();
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
