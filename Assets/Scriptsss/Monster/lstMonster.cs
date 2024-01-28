

public class lstMonster : Spawner
{
    private static lstMonster _Instance;

    public static string MonsterName;
    protected int Index=0;
    public static lstMonster Instance { get => _Instance; }
    protected  void Awake()
    {
        lstMonster._Instance = this;
    }

}
