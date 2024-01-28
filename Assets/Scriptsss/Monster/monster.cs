
using UnityEngine;


public class Monster:MonoBehaviour
{
    [SerializeField] private monsterID _ID;
    [SerializeField] private string _Name;
    [SerializeField] private int _Level;

    [SerializeField]   private float _MaxHp;
    [SerializeField]  private float _CurrHp;
    [SerializeField]  private int _MinDame;
    [SerializeField] private int _MaxDame;

    public monsterID ID { get { return _ID; } }
    public int Level { get { return _Level; } set { _Level = value; } }
    public string Name { get { return _Name; } set { _Name = value; } }
    public float MaxHp { get { return _MaxHp; } set { _MaxHp = value; } }
    public float CurrHp { get { return _CurrHp; } set { _CurrHp = value; } }
    public int MinDame { get { return _MinDame; } set { _MinDame = value; } }
    public int MaxDame { get { return _MaxDame; } set { _MaxDame = value; } }
    public SetMonster SetMonster = new SetMonster();
    private void Start()
    {
        CurrHp = SetMonster.getHPMonsterDictionary()[Level];
        MaxHp = SetMonster.getHPMonsterDictionary()[Level];
        MinDame = SetMonster.getDameMonsterDictionary(Level).Item1;
        MaxDame = SetMonster.getDameMonsterDictionary(Level).Item2;
    }
    public Monster GetMonster()
    {
        return this;
    }

 

}
