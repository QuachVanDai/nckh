public enum PotionType
{
    mp, hp, food
}
public class PotionSO : ItemSO
{
    public PotionType PotionType;
    public int Level;
    public int Buy;
    public int Price;
    public override void Update()
    {
        base.Update();
        this.ItemType = ItemType.Potion;
    }
    private int _hP;
    public int HP
    {
        get { return _hP; }
        set { _hP = value; }
    }
    private int _mP;
    public int MP
    {
        get { return _mP; }
        set { _mP = value; }
    }
}
