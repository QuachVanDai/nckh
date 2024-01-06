using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyItem : MonoBehaviour
{
    public inventoryUpdate inventoryUpdate;
    public slotClass item;

    private void Update()
    {
       //  slotClass = inventoryUpdate.GetClosestSLot();
    }
  
    public void BuyItem()
    {
        if (item.getItemSO() == null)
        {
            Debug.Log("NUll");
            return;
        }
        if ( item.getItemSO().itemName == "HP")
        {
            if(Player.Instance.UpdateXu(item.getItemSO().cost*-1))
            {
                inventoryUpdate.updateHP(1);
            }
        }

        else if ( item.getItemSO().itemName == "MP")
        {
            if (Player.Instance.UpdateXu(item.getItemSO().cost*-1))
            {
                inventoryUpdate.updateMP(1);
            }   
        }
        else if(item.getItemSO().itemName == "chicken")
        {
            if (Player.Instance.UpdateXu(item.getItemSO().cost*-1))
                inventoryUpdate.Add(item.getItemSO(),1);
        }
       
    }
}
