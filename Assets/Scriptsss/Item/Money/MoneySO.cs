public enum MoneyType
{
    xu
}
public class MoneySO : ItemSO
{
    public MoneyType MoneyType;
    public string Description;

    public override void Update()
    {
        base.Update();
        this.ItemType = ItemType.Money;
    }
    private int _xu;
    public int Xu
    {
        get { return _xu; }
        set { _xu = value; }
    }
 
}
