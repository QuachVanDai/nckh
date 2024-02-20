
using System;
using UnityEngine;

[Serializable]
public class Slot

{
    public ItemSO _item;
    public int _quantity;

    public Slot()
    {
        _item = null;
        _quantity = 0;
    }
    public Slot(Slot slot)
    {
        this._item = slot.getItemSO();
        this._quantity = slot.getQuantity();
    }
    public Slot (ItemSO item,int quantity)
    {
        this._item = item;
        this._quantity = quantity;
    }
    public ItemSO getItemSO() { return _item; }
    public int getQuantity() {  return _quantity; }
    public void UpdateQuantity(int quantity) { _quantity += quantity; }
    public void SubQuantity(int quantity) { _quantity -= quantity; }
    public void addItemSO(ItemSO item, int quantity) { _item = item; _quantity = quantity; }
    public void Clear() { _item = null; _quantity = 0; }

}
