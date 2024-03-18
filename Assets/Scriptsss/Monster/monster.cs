
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class Monster : MonoBehaviour
    {
        public MonsterID ID;
        public string nameMonster;
        public int level;
        public float maxHp;
        public float currHp;
        public int minDame;
        public int maxDame;

        public SetMonster SetMonster = new SetMonster();
        private void Start()
        {
            currHp = SetMonster.getHPMonsterDictionary()[level];
            maxHp = SetMonster.getHPMonsterDictionary()[level];
            minDame = SetMonster.getDameMonsterDictionary(level).Item1;
            maxDame = SetMonster.getDameMonsterDictionary(level).Item2;
            Destroy(gameObject, 1f);
        }
        public Monster GetMonster()
        {
            return this;
        }
    }
}
public enum MonsterID
{
    MaVuongLua = 1,
    RongXanh = 2,
    KhiNgo = 3,
    RoiLua = 4,
    Rua = 5,
    QuyBang = 6,


}
