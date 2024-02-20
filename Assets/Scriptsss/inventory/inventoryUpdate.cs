
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    [SerializeField]  private InventoryManager inventoryManager;
     private static InventoryUpdate instance;
    public static InventoryUpdate Instance { get => instance; }
    public TextMeshProUGUI[] TextGold;
    protected void Awake()
    {
        if (InventoryUpdate.instance != null) Debug.LogError("Only 1 inventoryUpdate allow to exist");
        InventoryUpdate.instance = this;
    }

    private void Start()
    {
        UpdateGold(Player.Instance.Gold);
    }
    #region update
    public void UpdateHP(int number)
    {
        for (int i = 0; i < inventoryManager.getSlotItems().Count; i++)
        {
            if(inventoryManager.getSlotItems()[i].getItemSO() && inventoryManager.getSlotItems()[i].getItemSO().ItemName == "HP")
            {
                inventoryManager.getSlotItems()[i].UpdateQuantity(number);
                inventoryManager.RefreshUI();
                return;
            }
        }
    }
    public void UpdateHP(Slot slot, int number)
    {
        for (int i = 0; i < inventoryManager.getSlotItems().Count; i++)
        {
            if (inventoryManager.getSlotItems()[i].getItemSO() && inventoryManager.getSlotItems()[i].getItemSO().ItemName == "HP")
            {
                inventoryManager.getSlotItems()[i].UpdateQuantity(number);
                inventoryManager.RefreshUI();
                return;
            }
        }
        AddItem(slot);
    }
    public void UpdateMP(int number)
    {
        for (int i = 0; i < inventoryManager.getSlotItems().Count; i++)
        {
            if (inventoryManager.getSlotItems()[i].getItemSO() && inventoryManager.getSlotItems()[i].getItemSO().ItemName == "MP")
            {
                inventoryManager.getSlotItems()[i].UpdateQuantity(number);
                inventoryManager.RefreshUI();
                return;
            }
        }
    }
    public void UpdateMP(Slot slot, int number)
    {
        for (int i = 0; i < inventoryManager.getSlotItems().Count; i++)
        {
            if (inventoryManager.getSlotItems()[i].getItemSO() && inventoryManager.getSlotItems()[i].getItemSO().ItemName == "MP")
            {
                inventoryManager.getSlotItems()[i].UpdateQuantity(number);
                inventoryManager.RefreshUI();
                return;
            }
        }
        AddItem(slot);
    }
    public bool AddItem(Slot slot)
    {
        for (int i = 0; i < inventoryManager.getSlotItems().Count; i++)
        {
            if (inventoryManager.getSlotItems()[i].getItemSO() == null)
            {
                inventoryManager.getSlotItems()[i].addItemSO(slot.getItemSO(),1);
                inventoryManager.RefreshUI();
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
        Slot slot = inventoryManager.getSlotItems()[index];
        try
        {
            if (slot.getItemSO().ItemName == "HP")
            {
                if (slot.getQuantity() == 0)
                    inventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateHP(-1);
            }
            else if (slot.getItemSO().ItemName == "MP")
            {
                if (slot.getQuantity() == 0)
                    inventoryManager.getSlotItems()[index].Clear();
                else
                    UpdateMP(-1);
            }
            else
            {
                inventoryManager.getSlotItems()[index].Clear();
            }
            inventoryManager.RefreshUI();
            return true;
        }
        catch
        {
            return false;

        }

    }
    #endregion

}
