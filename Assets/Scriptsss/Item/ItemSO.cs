using UnityEngine;


public class ItemSO: ScriptableObject
{
    public string ItemName;
    public ItemType ItemType;
    public Sprite Icon;
    public bool IsStackable = true;
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