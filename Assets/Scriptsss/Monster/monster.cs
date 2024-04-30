
using QuachDai.NinjaSchool.Scenes;
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
        public MiniSceneId placeOfAppearance;
     //   public RectTransform canvasUi;
        public SpriteRenderer spriteMonsterAttacked;

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
        public void UpdateHp(float _currentHp, float _maxHp, string _name, int _level)
        {
            hpBar.fillAmount = (float)_currentHp / (float)_maxHp;
            infoText = " " + _name + "  " + "Lv" + _level + " " + _currentHp.ToString() + "/" + _maxHp.ToString();
            InforMonster.Instance.SetInfoMonsterText(infoText);
            InforMonster.Instance.SetActive(true);
        }
        public Vector3 GetPosition()
        {
            return transform.position;
        }
        public Monster GetMonster()
        {
            return this;
        }
        public int GetMinDamage()
        {
            minDamage = SetMonster.getDameMonsterDictionary(level).Item1;
            return minDamage;
        }
        public int GetMaxDamage()
        {
            maxDamage = SetMonster.getDameMonsterDictionary(level).Item2;
            return maxDamage;
        }
        public int GetDamage()
        {
            return Random.Range(GetMinDamage(), GetMaxDamage());
        }
    }
}
public enum MonsterID
{
    None = 0,
    FireDemonKing = 1,
    GreenDragon = 2,
    GreenSnake = 3,
    GreenToad = 4,
    Monkey = 5,
    IceDevil = 6,
    SnowWolf = 7,
    Pterosaurs = 8,
    DevilHerbs = 9,
    CarnivorousFlower = 10,
    FireScorpion = 11,
    FireBat = 12,




}
