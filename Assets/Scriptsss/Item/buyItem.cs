using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public InventoryUpdate inventoryUpdate;
    public Slot item;


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
        if ( item.getItemSO().ItemName == "HP")
        {
            /*if(Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().Buy*-1))
            {
                inventoryUpdate.Add(item.getItemSO(), 1);
            }*/
        }

        else if ( item.getItemSO().ItemName == "MP")
        {
            /*if (Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().Buy * -1))
            {
                inventoryUpdate.Add(item.getItemSO(), 1);
            }*/
        }
        else if(item.getItemSO().ItemName == "chicken")
        {
           /* if (Player.Instance.PlayerEffect.UpdateXu(item.getItemSO().Buy * -1))
                inventoryUpdate.Add(item.getItemSO(),1);*/
        }
       
    }
}
