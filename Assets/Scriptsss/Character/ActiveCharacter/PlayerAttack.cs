using QuachDai.NinjaSchool.Mission;
using QuachDai.NinjaSchool.Monsters;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] PlayerSkill playerSkill;
        public Monster monster;
        public MissionUi missionUi;

        private float distance;
        private SetPlayer setPlayer = new SetPlayer();
        private SetMonster setMonster = new SetMonster();
        Player player => Player.Instance;
        PlayerController2D playerController2D => PlayerController2D.Instance;
        UseSkill useSkill => UseSkill.Instance;
        private void Update()
        {
             if (GameManager.Instance.IsPlaygame == false) return;
             if (playerController2D.IsGround() == false) return;
             //if (monsterAttacked == null)  return;
             //distance = Vector2.Distance(transform.position, monsterAttacked.transform.position);
            /* if (distance > 7)
             {
                 SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                monsterAttacked = null;
                 return;
             }*/

            if (playerController2D.getInputSpace())
            {
                // 
                /*  if (_Distance > 4)
                  {
                      TextTemplate.Instance.SetText(TagScript.khoangCach);
                      return;
                  }*/

                // if player use skilllv5 or skilllv15  , player cannot attack.
                 if (useSkill.getCurrKeySkill() == 1 || useSkill.getCurrKeySkill() == 3)
                {
                   TextTemplate.Instance.SetText(TagScript.useSkill);
                    return;
                 }
                if (playerSkill.isActtack)
                    PlayerAttackMonster(useSkill.getCurrKeySkill());
            }
        }

        float damage;
        public void PlayerAttackMonster(int number)
        {
            playerSkill.ManaUseSkill();
            playerSkill.SkillAttack(number);
             damage  = Random.Range(player.GetMinDamage(), player.GetMaxDamage() * playerSkill.GetCoefficient());
             playerSkill.InCreaseDamage(ref damage);
               AddExp((int)damage);
            monster.monsterAttacked.Attacked((int)damage);

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