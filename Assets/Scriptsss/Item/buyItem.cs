using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public InventoryUpdate inventoryUpdate;
    public SlotClass item;


    private void Update()
    {
       //  slotClass = inventoryUpdate.GetClosestSLot();
    }

   
    public void BuyItem1()
    {
        if (item.getItemSO() == null)
        {
            Debug.Log("NUll");
            return;
        }
        if ( item.getItemSO().itemName == "HP")
        {
            if(Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().cost*-1))
            {
                inventoryUpdate.Add(item.getItemSO(), 1);
            }
        }

        else if ( item.getItemSO().itemName == "MP")
        {
            if (Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().cost*-1))
            {
                inventoryUpdate.Add(item.getItemSO(), 1);
            }
        }
        else if(item.getItemSO().itemName == "chicken")
        {
            if (Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().cost*-1))
                inventoryUpdate.Add(item.getItemSO(),1);
        }
       
    }
}
