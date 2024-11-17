using UnityEngine;


public class ItemSO: ScriptableObject
{
    public ItemName Name;
    public ItemType ItemType;
    public Sprite Icon;
    public bool IsStackable = true;
    public string Description;
 
    public virtual ItemSO getItemSO() { return this; }
   
}
public enum ItemType
{
    None, Potion, Equipment, Money
}
public enum ItemName
{
    None, Hp, Mp, Xu,Food
}