
using TMPro;

public class InventoryUpdate : Singleton<InventoryUpdate>
{
    public InventoryManager InventoryManager;
    #region update
   
    public void UpdateHP(Slot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO() && InventoryManager.getSlotItems()[i].getItemSO().ItemName == "HP")
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.RefreshUI();
                return;
            }
        }
        AddItem(slot);
    }
    public void UpdateMP(Slot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO()
                && InventoryManager.getSlotItems()[i].getItemSO().ItemName == "MP")
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.RefreshUI();
                return;
            }
        }
        AddItem(slot);
    }
    public int UpdateHP(int number)
    {
        int sumHP = 0;
        bool flat = false;
        PotionSO hp;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            hp = (PotionSO)InventoryManager.getSlotItems()[i].getItemSO();
            if (hp && hp.PotionType == PotionType.hp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sumHP += InventoryManager.getSlotItems()[i].getQuantity();
                    if (InventoryManager.getSlotItems()[i].getQuantity() == 0)
                    {
                        RemoveItem(i);
                    }
                    flat = true;
                }
                else
                {
                    sumHP += InventoryManager.getSlotItems()[i].getQuantity();
                }
            }
        }
        InventoryManager.RefreshUI();

        return sumHP;
    }
    public int UpdateMP(int number)
    {
        int sumMP = 0;
        bool flat = false;
        PotionSO mp;
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            mp = (PotionSO)InventoryManager.getSlotItems()[i].getItemSO();
            if (mp && mp.PotionType == PotionType.mp)
            {
                if (!flat)
                {
                    InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                    sumMP += InventoryManager.getSlotItems()[i].getQuantity();
                    if (InventoryManager.getSlotItems()[i].getQuantity() == 0)
                    {
                        RemoveItem(i);
                    }
                    flat = true;
                }
                else
                {
                    sumMP += InventoryManager.getSlotItems()[i].getQuantity();
                }
            }
        }
        InventoryManager.RefreshUI();

        return sumMP;
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
                {
                    return true;
                }
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
                return ;
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
                if (slot.getItemSO().ItemName == s.getItemSO().ItemName)
                {
                    InventoryManager.getSlotItems()[i].Clear();
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
