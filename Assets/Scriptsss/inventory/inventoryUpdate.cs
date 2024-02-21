
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    public InventoryManager InventoryManager;
    private static InventoryUpdate _Instance;
    public static InventoryUpdate Instance { get => _Instance; }
    public TextMeshProUGUI[] TextGold;
    protected void Awake()
    {
        if (InventoryUpdate._Instance != null) Debug.LogError("Only 1 inventoryUpdate allow to exist");
        InventoryUpdate._Instance = this;
    }

    private void Start()
    {
        UpdateGold(Player.Instance.Gold);
    }
    #region update
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
                    InventoryManager.getSlotItems()[i].SubQuantity(number);
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
                    InventoryManager.getSlotItems()[i].SubQuantity(number);
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
    public void UpdateMP(Slot slot, int number)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO() && InventoryManager.getSlotItems()[i].getItemSO().ItemName == "MP")
            {
                InventoryManager.getSlotItems()[i].UpdateQuantity(number);
                InventoryManager.RefreshUI();
                return;
            }
        }
        AddItem(slot);
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
    public bool AddItem(Slot slot)
    {
        for (int i = 0; i < InventoryManager.getSlotItems().Count; i++)
        {
            if (InventoryManager.getSlotItems()[i].getItemSO() == null)
            {
                InventoryManager.getSlotItems()[i].addItemSO(slot.getItemSO(), 1);
                InventoryManager.RefreshUI();
                return true;
            }
        }
        return false;
    }
    public void UpdateGold(int Gold)
    {
        foreach (TextMeshProUGUI t in TextGold)
        {
            t.text = Gold.ToString();
        }
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
                    UpdateHP(1);
            }
            else if (potion.PotionType == PotionType.hp)
            {
                if (slot.getQuantity() == 0)
                    InventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateMP(1);
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
