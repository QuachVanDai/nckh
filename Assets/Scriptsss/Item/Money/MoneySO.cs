public enum MoneyType
{
    xu
}
public class MoneySO : ItemSO
{
    public MoneyType MoneyType;

  
    private int _xu;
    public int Xu
    {
        get { return _xu; }
        set { _xu = value; }
    }
 
}
