
using UnityEngine;

public enum ItemType
{
    None, Potion, Equipment, Money
}

public class ItemSO: ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    public int level;
    public int cost;
    public bool isStackable = true;
    public string Description;

    public void OnEnable()
    {
        this.Update();
    }

    public virtual void Update()
    {
           
    }
    public void show()
    {

    }
    public virtual ItemSO getItemSO() { return this; }
  
}
