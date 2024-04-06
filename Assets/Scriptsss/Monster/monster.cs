
using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Spawn;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Monsters
{
    public class Monster : MonoBehaviour
    {
        public MonsterID ID;
        public string nameMonster;
        public int level;
        public float maxHp;
        public float currHp;
        public int minDamage;
        public int maxDamage;
        public Image hpBar;
        public RectTransform canvasUi;
        

        public SetMonster SetMonster = new SetMonster();

        public MonsterAttack monsterAttack;
        public MonsterAttacked monsterAttacked;

        private void Start()
        {
            currHp = SetMonster.getHPMonsterDictionary()[level];
            maxHp = SetMonster.getHPMonsterDictionary()[level];
            minDamage = SetMonster.getDameMonsterDictionary(level).Item1;
            maxDamage = SetMonster.getDameMonsterDictionary(level).Item2;
        }
      
        string infoText;
        public void UpdateHp(float CurrentHp, float MaxHp, string Name, int Level)
        {
            hpBar.fillAmount = (float)CurrentHp / (float)MaxHp;
            infoText = " " + Name + "  " + "Lv" + Level + " " + CurrentHp.ToString() + "/" + MaxHp.ToString();
            SystemUi.Instance.SetInfoMonsterText(infoText);
            SystemUi.Instance.SetActive(true);
        }
        public Monster GetMonster()
        {
            return this;
        }
        public int GetMinDamage()
        {
            return minDamage;
        }
        public void SetMaxDamage()
        {
            maxDamage = SetMonster.getDameMonsterDictionary(level).Item1;
        }
        public void SetMinDamage()
        {
            minDamage = SetMonster.getDameMonsterDictionary(level).Item2;
        }
        public int GetMaxDamage()
        {
            return maxDamage;
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
    SoiTuyet=7,

}
