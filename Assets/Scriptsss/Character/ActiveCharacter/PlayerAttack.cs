using QuachDai.NinjaSchool.Animations;
using QuachDai.NinjaSchool.Mission;
using QuachDai.NinjaSchool.Monsters;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private SkillAnimation skillAnimation;
        [SerializeField] private FrameSkill[] frameSkill;
        [SerializeField] private SkillRecoveryTime[] skillRecoveryTimes;
       
        public MonsterAttacked monsterAttacted;
        public MissionUi missionUi;

        private float distance;
        private SetPlayer setPlayer = new SetPlayer();
        private SetMonster setMonste = new SetMonster();
        private SetSkillParameters skillParameters = new SetSkillParameters();
        private bool isActtack, isSkillLv5, isSkillLv15, isIncreaseDamage;
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        Player player => Player.Instance;
        private void Start()
        {
            isActtack = true;
            isSkillLv5 = true;
            isSkillLv15 = true;
            isIncreaseDamage = false;
        }

        private void Update()
        {
            /* if (GameManager.Instance.IsPlaygame == false) return;
             if (PlayerController2D.Instance.IsGround() == false) return;
             if (MonsterAttacted == null)
             {
                 return;
             }
             _Distance = Vector2.Distance(transform.position, MonsterAttacted.transform.position);
             if (_Distance > 7)
             {
                 SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                 MonsterAttacted = null;
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
                //  if (UseSkill.Instance.getCurrKeySkill() == 1 || UseSkill.Instance.getCurrKeySkill() == 3)
                //{
                //   TextTemplate.Instance.SetText(TagScript.useSkill); return;
                // }
                // check mana
                //ManaUseSkill();
                // player can attack
                //if (_IsActtack)
                {
                    StartCoroutine(PlayerAttackMonster());
                }
            }
        }

        #region người chơi đánh quái và nhận kinh nghiệm
        public IEnumerator PlayerAttackMonster()
        {
            // 
            //  float damage = Random.Range(
            // player.SetPlayer.getDamePlayerDictionary(player.Level).Item1,
            // player.SetPlayer.getDamePlayerDictionary(player.Level).Item2) *
            // _FrameSkill[UseSkill.Instance.getCurrKeySkill()].coefficient; //coefficient: hệ số

            // if player use skillLv15 , player can increase damage
            /* if (_IsIncreaseDamage)
             {
                 if (player.Level >= 20)
                     damage += _SkillParameters.getSkillLv15Parameters()[6];
                 else { damage += _SkillParameters.getSkillLv15Parameters()[player.Level - 14]; }
             }*/
            //AddExp((int)damage);
            //   MonsterAttacted.Attacked((int)damage);
            skillAnimation.AnimationSkill(frameSkill[UseSkill.Instance.getCurrKeySkill()]);
            animatorSystem.SetBool(player.animatorPlayer,"IsAttack", true);
            isActtack = false;
            player.PlayerEffect.UpdateMp(frameSkill[UseSkill.Instance.getCurrKeySkill()].mp * (-1));
            yield return new WaitForSeconds(0.23f);
            animatorSystem.SetBool(player.animatorPlayer,"IsAttack", false);
            skillRecoveryTimes[UseSkill.Instance.getCurrKeySkill()].isTime = true;
            yield return new WaitForSeconds(frameSkill[UseSkill.Instance.getCurrKeySkill()].timeSkill);
            isActtack = true;
            skillRecoveryTimes[UseSkill.Instance.getCurrKeySkill()].isTime = false;
        }
        public void AddExp(float damage)
        {
            if (monsterAttacted.monCurrent.currHp < damage)
            {
                damage = monsterAttacted.monCurrent.currHp;
            }
            double exp = (damage * setMonste.getExpMonsterDictionary()[monsterAttacted.monCurrent.level] * 100)
            / setPlayer.getExpPlayerDictionary()[player.Level];
            player.PlayerEffect.TextGUI((int)damage, new Color(0, 1, 0.753031f, 1));
            if (player.PercentExp + exp >= 100)
            {
                player.PercentExp = 0;
                player.Level++;
                player.PlayerEffect.TxtCurrentLevel.text = player.Level.ToString();
            }
            else player.PercentExp += (float)exp;
            player.PlayerEffect.TxtCurrentPercentExp.text = (player.PercentExp).ToString("F2") + "%";
        }
        public void FindMonster(MonsterAttacked m)
        {
            monsterAttacted = m.GetComponent<MonsterAttacked>();
        }
        #endregion
        #region  người chơi sử dụng kỹ năng lv5 và lv15
        public void PlayerUseSkillLv5()
        {
            if (UseSkill.Instance.getIsUseSkill(1) == false) { return; }
            ManaUseSkill();
            if (!isSkillLv5) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
            if (isSkillLv5)
            {
                StartCoroutine(UseSkillLv5());
            }
        }
        public IEnumerator UseSkillLv5()
        {
            skillAnimation.AnimationSkillLv5_15(frameSkill[1]);
            isSkillLv5 = false;
            InvokeRepeating(nameof(InCreaseHPMP), 0, 0.5f);
            skillRecoveryTimes[1].isTime = true;
            yield return new WaitForSeconds(1.5f);
            CancelInvoke(nameof(InCreaseHPMP));
            yield return new WaitForSeconds(frameSkill[1].timeSkill - 1.5f);
            skillRecoveryTimes[1].isTime = false;
            isSkillLv5 = true;
        }
        public void InCreaseHPMP()
        {
            float hp, mp;
            if (player.Level >= 10)
            {
                hp = skillParameters.getSkillLv5Parameters()[6];
                mp = skillParameters.getSkillLv5Parameters()[6];
            }
            else
            {
                hp = skillParameters.getSkillLv5Parameters()[player.Level - 4];
                mp = skillParameters.getSkillLv5Parameters()[player.Level - 4];
            }
            player.PlayerEffect.UpdateHp(hp);
            player.PlayerEffect.UpdateMp(mp);
        }
        public void PlayerUseSkillLv15()
        {
            if (UseSkill.Instance.getIsUseSkill(3) == false) { return; }
            ManaUseSkill();
            if (!isSkillLv15) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
            if (isSkillLv15)
            {
                StartCoroutine(UseSkillLv15());
            }
        }

        public IEnumerator UseSkillLv15()
        {
            skillAnimation.AnimationSkillLv5_15(frameSkill[3]);
            isSkillLv15 = false;
            isIncreaseDamage = true;
            skillRecoveryTimes[3].isTime = true;
            yield return new WaitForSeconds(frameSkill[3].timeSkill);
            isSkillLv15 = true;
            isIncreaseDamage = false;
            skillRecoveryTimes[3].isTime = false;

        }

        public void ManaUseSkill()
        {
            if (player.CurrMp < frameSkill[UseSkill.Instance.getCurrKeySkill()].mp)
            {
                Debug.Log("khong du Mana de su dung  " + player.CurrMp);
                return;
            }

        }
        #endregion

        void OnDrawGizmos()
        {
            if (monsterAttacted == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, monsterAttacted.transform.position);
        }
    }
}