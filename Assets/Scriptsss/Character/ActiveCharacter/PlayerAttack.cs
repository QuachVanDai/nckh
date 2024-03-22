using QuachDai.NinjaSchool.Animations;
using QuachDai.NinjaSchool.Mission;
using QuachDai.NinjaSchool.Monsters;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] PlayerSkill playerSkill;
        public Monster monster;
        public MonsterAttacked monsterAttacked;
        public MissionUi missionUi;

        private float distance;
        private SetPlayer setPlayer = new SetPlayer();
        private SetMonster setMonster = new SetMonster();
        Player player => Player.Instance;


        private void Update()
        {
             if (GameManager.Instance.IsPlaygame == false) return;
             if (PlayerController2D.Instance.IsGround() == false) return;
             //if (monsterAttacked == null)  return;
             //distance = Vector2.Distance(transform.position, monsterAttacked.transform.position);
            /* if (distance > 7)
             {
                 SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                monsterAttacked = null;
                 return;
             }*/

            if (PlayerController2D.Instance.getInputSpace())
            {
                // 
                /*  if (_Distance > 4)
                  {
                      TextTemplate.Instance.SetText(TagScript.khoangCach);
                      return;
                  }*/

                // if player use skilllv5 or skilllv15  , player cannot attack.
                 if (UseSkill.Instance.getCurrKeySkill() == 1 || UseSkill.Instance.getCurrKeySkill() == 3)
                {
                   TextTemplate.Instance.SetText(TagScript.useSkill); return;
                 }
                playerSkill.ManaUseSkill();
                if (playerSkill.isActtack)
                {
                    StartCoroutine(PlayerAttackMonster());
                }
            }
        }

        float damage;
        public IEnumerator PlayerAttackMonster()
        {
          //  damage  = Random.Range(player.GetMinDamage(), player.GetMaxDamage() * playerSkill.GetCoefficient());
          //  playerSkill.InCreaseDamage(ref damage);
         //   AddExp((int)damage);
            yield return new WaitForSeconds(0.23f);
           // monsterAttacked.Attacked((int)damage);
            playerSkill.SkillAttack();
        }
        double exp;
        public void AddExp(float damage)
        {
            if (monster.currHp < damage)
            {
                damage = monster.currHp;
            }
            exp = (damage * setMonster.getExpMonsterDictionary(monster.level) * 100) /
                setPlayer.getExpPlayerDictionary(player.GetLevel());
            player.TextGUI((int)damage, new Color(0, 1, 0.753031f, 1));
            if (player.GetPercentExp() + exp >= 100)
            {
                player.SetPercentExp(0);
                player.IncreaseLevel();
                player.SetLevelText(player.GetLevel());
            }
            else
                player.IncreasePercentExp((float)exp);
            player.SetPercentExpText(player.GetPercentExp());
        }
        public void FindMonster(Monster _monster)
        {
            monster = _monster.GetComponent<Monster>();
        }

        void OnDrawGizmos()
        {
            if (monster == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, monster.transform.position);
        }
    }
}