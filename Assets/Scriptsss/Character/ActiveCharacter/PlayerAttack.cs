using QuachDai.NinjaSchool.Animations;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private SkillAnimation _SkillAnimation;
        [SerializeField] private FrameSkill[] _FrameSkill;
        [SerializeField] private SkillRecoveryTime[] _SkillRecoveryTimes;
       
        public MonsterAttacked MonsterAttacted;
        public MissionUi MissionUi;

        private float _Distance;
        private SetPlayer _SetPlayer = new SetPlayer();
        private SetMonster _SetMonste = new SetMonster();
        private SetSkillParameters _SkillParameters = new SetSkillParameters();
        private bool _IsActtack, _IsSkillLv5, _IsSkillLv15, _IsIncreaseDamage;
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        Player player => Player.Instance;
        private void Start()
        {
            _IsActtack = true;
            _IsSkillLv5 = true;
            _IsSkillLv15 = true;
            _IsIncreaseDamage = false;
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
            _SkillAnimation.AnimationSkill(_FrameSkill[UseSkill.Instance.getCurrKeySkill()]);
            animatorSystem.SetBool(player.animatorPlayer,"IsAttack", true);
            _IsActtack = false;
            player.PlayerEffect.UpdateMp(_FrameSkill[UseSkill.Instance.getCurrKeySkill()].mp * (-1));
            yield return new WaitForSeconds(0.23f);
            animatorSystem.SetBool(player.animatorPlayer,"IsAttack", false);
            _SkillRecoveryTimes[UseSkill.Instance.getCurrKeySkill()].isTime = true;
            yield return new WaitForSeconds(_FrameSkill[UseSkill.Instance.getCurrKeySkill()].timeSkill);
            _IsActtack = true;
            _SkillRecoveryTimes[UseSkill.Instance.getCurrKeySkill()].isTime = false;
        }
        public void AddExp(float damage)
        {
            if (MonsterAttacted.MonCurrent.CurrHp < damage)
            {
                damage = MonsterAttacted.MonCurrent.CurrHp;
            }
            double exp = (damage * _SetMonste.getExpMonsterDictionary()[MonsterAttacted.MonCurrent.Level] * 100)
            / _SetPlayer.getExpPlayerDictionary()[player.Level];
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
            MonsterAttacted = m.GetComponent<MonsterAttacked>();
        }
        #endregion
        #region  người chơi sử dụng kỹ năng lv5 và lv15
        public void PlayerUseSkillLv5()
        {
            if (UseSkill.Instance.getIsUseSkill(1) == false) { return; }
            ManaUseSkill();
            if (!_IsSkillLv5) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
            if (_IsSkillLv5)
            {
                StartCoroutine(UseSkillLv5());
            }
        }
        public IEnumerator UseSkillLv5()
        {
            _SkillAnimation.AnimationSkillLv5_15(_FrameSkill[1]);
            _IsSkillLv5 = false;
            InvokeRepeating(nameof(InCreaseHPMP), 0, 0.5f);
            _SkillRecoveryTimes[1].isTime = true;
            yield return new WaitForSeconds(1.5f);
            CancelInvoke(nameof(InCreaseHPMP));
            yield return new WaitForSeconds(_FrameSkill[1].timeSkill - 1.5f);
            _SkillRecoveryTimes[1].isTime = false;
            _IsSkillLv5 = true;
        }
        public void InCreaseHPMP()
        {
            float hp, mp;
            if (player.Level >= 10)
            {
                hp = _SkillParameters.getSkillLv5Parameters()[6];
                mp = _SkillParameters.getSkillLv5Parameters()[6];
            }
            else
            {
                hp = _SkillParameters.getSkillLv5Parameters()[player.Level - 4];
                mp = _SkillParameters.getSkillLv5Parameters()[player.Level - 4];
            }
            player.PlayerEffect.UpdateHp(hp);
            player.PlayerEffect.UpdateMp(mp);
        }
        public void PlayerUseSkillLv15()
        {
            if (UseSkill.Instance.getIsUseSkill(3) == false) { return; }
            ManaUseSkill();
            if (!_IsSkillLv15) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
            if (_IsSkillLv15)
            {
                StartCoroutine(UseSkillLv15());
            }
        }

        public IEnumerator UseSkillLv15()
        {
            _SkillAnimation.AnimationSkillLv5_15(_FrameSkill[3]);
            _IsSkillLv15 = false;
            _IsIncreaseDamage = true;
            _SkillRecoveryTimes[3].isTime = true;
            yield return new WaitForSeconds(_FrameSkill[3].timeSkill);
            _IsSkillLv15 = true;
            _IsIncreaseDamage = false;
            _SkillRecoveryTimes[3].isTime = false;

        }

        public void ManaUseSkill()
        {
            if (player.CurrMp < _FrameSkill[UseSkill.Instance.getCurrKeySkill()].mp)
            {
                Debug.Log("khong du Mana de su dung  " + player.CurrMp);
                return;
            }

        }
        #endregion

        void OnDrawGizmos()
        {
            if (MonsterAttacted == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, MonsterAttacted.transform.position);
        }
    }
}