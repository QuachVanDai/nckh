
using System;
using UnityEngine;

[Serializable]
public class Slot

{
    public ItemSO item;
    public int quantity;

    public Slot()
    {
        item = null;
        quantity = 0;
    }
    public Slot(Slot slot)
    {
        this.item = slot.getItemSO();
        this.quantity = slot.getQuantity();
    }
    public Slot (ItemSO item,int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
    public ItemSO getItemSO() { return item; }
    public int getQuantity() {  return quantity; }
    public void UpdateQuantity(int quantity) { this.quantity += quantity; }
    public void SubQuantity(int quantity) { this.quantity -= quantity; }
    public void addItemSO(ItemSO item, int quantity) { this.item = item; this.quantity = quantity; }
    public void Clear() { item = null; quantity = 0; }

}
