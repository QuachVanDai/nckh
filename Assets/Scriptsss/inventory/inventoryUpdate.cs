
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    [SerializeField]  private InventoryManager inventoryManager;
   // private GameObject[] slots;
    private SlotClass temSlot;
    private SlotClass originalSlot;

    public bool isMovingItem;
    public SlotClass movingSlot;


     private static InventoryUpdate instance;
    public static InventoryUpdate Instance { get => instance; }

    protected void Awake()
    {
        if (InventoryUpdate.instance != null) Debug.LogError("Only 1 inventoryUpdate allow to exist");
        InventoryUpdate.instance = this;
    }
  
    #region units
    public bool Add(ItemSO item,int quantity)
    {
        SlotClass sl = Contain(item);
        if (sl != null && sl.getItemSO().IsStackable)
        {
            sl.addQuantity(quantity);
            
        }
        else
        {
            for(int i = 0;i < inventoryManager.getItems().Length;i++) 
            {
                if (inventoryManager.getItems()[i].getItemSO()==null)
                {
                    inventoryManager.getItems()[i].addItemSO(item, quantity);
                    break;
                }
            }
        }
        return true;
    }

    public bool Remove(ItemSO ItemSO)
    {

        int slotToRemoveIndex=0 ;
        SlotClass temp = Contain(ItemSO);
        if (temp != null)
        {
            if (temp.getQuantity()>1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                for (int i = 0; i < inventoryManager.getItems().Length; i++)
                {
                    if (inventoryManager.getItems()[i].getItemSO() == ItemSO)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }
                inventoryManager.getItems()[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }

        inventoryManager.RefreshUI();
        return true;
    }
    public ItemSO i;
    public void conFirmRemove()
    {
        Remove(i);
    }
    public SlotClass Contain(ItemSO item)
    {

        for (int i = 0; i < inventoryManager.getItems().Length; i++)
        {
            if (inventoryManager.getItems()[i].getItemSO() == item)
            {
                return inventoryManager.getItems()[i];
            }
        }
        return null;

    }
    #endregion

    #region show Information
    public void showInforItem()
    {
        string str = "";
        originalSlot = inventoryManager.GetClosestSLot();
        if (originalSlot == null || originalSlot.getItemSO() == null)
        {
            inventoryManager.settxtShowInfor("Chọn vật phẩm");
            return ;
        }
    //    < color = "red" > Game </ color >< color = "orange" > Thu </ color >< color = "green" > Thach </ color >

        str += originalSlot.getItemSO().ItemName+ "\n";
      //  str += "Cấp độ "+originalSlot.getItemSO().Level+ "\n";
        str += originalSlot.getItemSO().Description + "\n";
        inventoryManager.settxtShowInfor(str);
        inventoryManager.RefreshUI();
    }
    #endregion
    #region update
    public int updateHP(int number)
    {
        int quanitity = 0;
        bool flat = true;
        for (int i = 0; i < inventoryManager.getItems().Length; i++)
        {
                try
                {
                    if (inventoryManager.getItems()[i].getItemSO().ItemName == "HP")
                    {
                        if (flat)
                        {
                            if (number == 1)
                            {
                                inventoryManager.getItems()[i].addQuantity(1);
                            }
                            else if (number == -1)
                            {
                            inventoryManager.getItems()[i].SubQuantity(1);
                            }
                            if (inventoryManager.getItems()[i].getQuantity() <= 0)
                            {
                                Remove(inventoryManager.getItems()[i].getItemSO());
                            }
                            else
                                quanitity += inventoryManager.getItems()[i].getQuantity();
                        flat = false;
                        }
                        else
                        {
                            quanitity += inventoryManager.getItems()[i].getQuantity();
                        }
                    }
                }
                catch
                {

                }
        }
        inventoryManager.RefreshUI();

        return quanitity;
    }
    public int updateMP(int number)
    {
        int quanitity = 0;
        bool flat = true;
        for (int i = 0; i < inventoryManager.getItems().Length; i++)
        {
            try
            {
                if (inventoryManager.getItems()[i].getItemSO().ItemName == "MP")
                {
                    if (flat)
                    {
                        if (number == 1)
                        {
                            inventoryManager.getItems()[i].addQuantity(1);
                        }
                        else if (number == -1)
                        {
                            inventoryManager.getItems()[i].SubQuantity(1);
                        }
                        if (inventoryManager.getItems()[i].getQuantity() <= 0)
                        {
                            Remove(inventoryManager.getItems()[i].getItemSO());
                        }
                        else
                            quanitity += inventoryManager.getItems()[i].getQuantity();
                        flat = false;
                    }
                    else
                    {
                        quanitity += inventoryManager.getItems()[i].getQuantity();
                    }
                }
            }
            catch
            {

            }
        }
        inventoryManager.RefreshUI();

        return quanitity;
    }

    public bool updateFood()
    {
        for (int i = 0; i < inventoryManager.getItems().Length; i++)
        {
            if (inventoryManager.getItems()[i].getItemSO() !=null && 
                inventoryManager.getItems()[i].getItemSO().ItemName == "chicken")
            {
                return true;
            }
        }
            return false;
    }
    #endregion


    #region 
    public bool BeginItemMove()
    {
        originalSlot = inventoryManager.GetClosestSLot();
        if (originalSlot == null || originalSlot.getItemSO() == null)
        {
            return false;
        }
        movingSlot = new SlotClass(originalSlot);
        isMovingItem = true;
        originalSlot.Clear();
        inventoryManager.RefreshUI();
        return true;
    }

    public bool EndItemMove()
    {
        originalSlot = inventoryManager.GetClosestSLot();
            if (originalSlot == null)
            {
                Add(movingSlot.getItemSO(), movingSlot.getQuantity());
                movingSlot.Clear();
            }
            else
            {
                if (originalSlot.getItemSO() != null)
                {
                    if (originalSlot.getItemSO() == movingSlot.getItemSO())
                    {
                        if (originalSlot.getItemSO().IsStackable)
                        {
                            originalSlot.addQuantity(movingSlot.getQuantity());
                            movingSlot.Clear();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        temSlot = new SlotClass(originalSlot);
                        originalSlot.addItemSO(movingSlot.getItemSO(), movingSlot.getQuantity());
                        movingSlot.addItemSO(temSlot.getItemSO(), temSlot.getQuantity());
                    inventoryManager.RefreshUI();
                        return true;
                    }
                }
                else
                {
                    originalSlot.addItemSO(movingSlot.getItemSO(), movingSlot.getQuantity());
                    movingSlot.Clear();
                }
            }
        isMovingItem = false;
        inventoryManager.RefreshUI();
        return true;
    }
  

   
    #endregion
}
