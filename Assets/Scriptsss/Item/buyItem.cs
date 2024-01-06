using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyItem : MonoBehaviour
{
    public inventoryManager inventoryManager;
    public slotClass item;

    private void Update()
    {
       //  slotClass = inventoryManager.GetClosestSLot();
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
            inventoryManager.updateHP(1);
        }

        else if ( item.getItemSO().itemName == "MP")
        {
            if (Player.Instance.UpdateXu(item.getItemSO().cost*-1))
                inventoryManager.updateMP(1);
        }
        else if(item.getItemSO().itemName == "chicken")
        {
            if (Player.Instance.UpdateXu(item.getItemSO().cost*-1))
                inventoryManager.Add(item.getItemSO(),1);
        }
       
    }
}
