using DG.Tweening;
using QuachDai.NinjaSchool.Mission;
using QuachDai.NinjaSchool.Monsters;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] PlayerSkill playerSkill;
        public Monster monster;
        public MissionUi missionUi;
        public Text[] expText;

        private float distance;
        private SetPlayer setPlayer = new SetPlayer();
        private SetMonster setMonster = new SetMonster();
        Player player => Player.Instance;
        PlayerController2D playerController2D => PlayerController2D.Instance;
        UseSkill useSkill => UseSkill.Instance;
        private void Start()
        {
            posStartText = expText[0].rectTransform.anchoredPosition;

        }
        private void Update()
        {
            if (GameManager.Instance.IsPlaygame == false) return;
            if (playerController2D.IsGround() == false) return;
            if (monster == null) return;
            distance = Vector2.Distance(transform.position, monster.GetPosition());
            if (distance > 7)
            {
                SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                monster = null;
                return;
            }

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
            damage = Random.Range(player.GetMinDamage(), player.GetMaxDamage() * playerSkill.GetCoefficient());
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

            TextMove(damage.ToString());
            if (player.GetPercentExp() + exp >= 100)
            {
                if (player.GetLevel() == 20)
                    player.SetPercentExp(99.99f);
                else
                    player.SetPercentExp(0);
                player.IncreaseLevel();
                player.SetLevelText(player.GetLevel());
            }
            else
                player.IncreasePercentExp((float)exp);
            player.SetPercentExpText(player.GetPercentExp());
        }
        public Vector3 posStartText;

        public void TextMove(string _damage)
        {
            for (int i = 0; i < expText.Length; i++)
            {
                if (!expText[i].gameObject.activeSelf)
                {
                    expText[i].text = _damage;
                    expText[i].rectTransform.anchoredPosition = posStartText;
                    expText[i].gameObject.SetActive(true);
                    var t = expText[i].rectTransform.DOAnchorPosY(expText[i].rectTransform.localPosition.y + 2.5f, 0.5f)
               .OnComplete(() =>
               {
                   expText[i].gameObject.SetActive(false);
               });
                    return;
                }
            }

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