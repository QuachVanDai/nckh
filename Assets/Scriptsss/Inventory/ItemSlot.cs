
using System;
using UnityEngine;

[Serializable]
public class ItemSlot

{
    public ItemSO Item;
    public int Quantity;

    public ItemSlot()
    {
        Item = null;
        Quantity = 0;
    }
    public ItemSlot(ItemSlot slot)
    {
        this.Item = slot.GetItemSO();
        this.Quantity = slot.GetQuantity();
    }
    public ItemSlot (ItemSO item,int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }
    public ItemSO GetItemSO() { return Item; }
    public int GetQuantity() {  return Quantity; }
    public void UpdateQuantity(int quantity) { this.Quantity += quantity; }
    public void SubQuantity(int quantity) { this.Quantity -= quantity; }
    public void AddQuantity(int quantity) { this.Quantity += quantity; }
    public void AddItemSO(ItemSO item, int quantity) { this.Item = item; this.Quantity = quantity; }
    public void Clear() { Item = null; Quantity = 0; }

}
