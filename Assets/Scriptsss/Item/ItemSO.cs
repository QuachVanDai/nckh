using UnityEngine;


public class ItemSO: ScriptableObject
{
    public ItemName itemName;
    public ItemType ItemType;
    public Sprite Icon;
    public bool IsStackable = true;
    public int Cost;
    public string Description;

    public void OnEnable()
    {
        this.Update();
    }

    public virtual ItemSO getItemSO() { return this; }
    public virtual void Update()
    {
           
    }
}
public enum ItemType
{
    None, Potion, Equipment, Money
}
public enum ItemName
{
    None, Hp, Mp, Xu,Food
}