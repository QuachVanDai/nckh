

public class LstMonster : Spawner
{
    private static LstMonster _Instance;

    public static string MonsterName;
    protected int Index=0;
    public static LstMonster Instance { get => _Instance; }
    protected  void Awake()
    {
        LstMonster._Instance = this;
    }

}
