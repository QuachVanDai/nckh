
using UnityEngine;

[System.Serializable]
public class SlotClass 
{
    [SerializeField] private ItemSO _item;
    [SerializeField]  private int _quantity;

    public SlotClass()
    {
        _item = null;
        _quantity = 0;
    }
    public SlotClass(SlotClass slot)
    {
        this._item = slot.getItemSO();
        this._quantity = slot.getQuantity();
    }
    public SlotClass (ItemSO item,int quantity)
    {
        this._item = item;
        this._quantity = quantity;
    }
    public ItemSO getItemSO() { return _item; }
    public int getQuantity() {  return _quantity; }
    public void addQuantity(int quantity) { _quantity += quantity; }
    public void SubQuantity(int quantity) { _quantity -= quantity; }
    public void addItemSO(ItemSO item, int quantity) { _item = item; _quantity = quantity; }
    public void Clear() { _item = null; _quantity = 0; }
}
