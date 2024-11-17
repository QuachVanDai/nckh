using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyItem : BaseButton
{
    [SerializeField] InventoryPlayer inventoryPlayer;
    [SerializeField] InventoryShop inventoryShop;
    protected override void ListenerMethod()
    {
        base.ListenerMethod();
        inventoryPlayer.AddItem(inventoryShop.ItemClick);
    }
}
