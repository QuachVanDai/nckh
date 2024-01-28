public enum MoneyType
{
    xu
}
public class MoneySO : ItemSO
{
    public MoneyType MoneyType;

    public override void Update()
    {
        base.Update();
        this.itemType = ItemType.Money;
    }
    private int _xu;
    public int Xu
    {
        get { return _xu; }
        set { _xu = value; }
    }
 
}
