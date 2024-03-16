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
            // Player.Instance.SetPlayer.getDamePlayerDictionary(Player.Instance.Level).Item1,
            // Player.Instance.SetPlayer.getDamePlayerDictionary(Player.Instance.Level).Item2) *
            // _FrameSkill[UseSkill.Instance.getCurrKeySkill()].coefficient; //coefficient: hệ số

            // if player use skillLv15 , player can increase damage
            /* if (_IsIncreaseDamage)
             {
                 if (Player.Instance.Level >= 20)
                     damage += _SkillParameters.getSkillLv15Parameters()[6];
                 else { damage += _SkillParameters.getSkillLv15Parameters()[Player.Instance.Level - 14]; }
             }*/
            //AddExp((int)damage);
            //   MonsterAttacted.Attacked((int)damage);
            _SkillAnimation.AnimationSkill(_FrameSkill[UseSkill.Instance.getCurrKeySkill()]);
            PlayerController2D.Instance.animator.SetBool("IsAttack", true);
            _IsActtack = false;
            Player.Instance.PlayerEffect.UpdateMp(_FrameSkill[UseSkill.Instance.getCurrKeySkill()].mp * (-1));
            yield return new WaitForSeconds(0.23f);
            PlayerController2D.Instance.animator.SetBool("IsAttack", false);
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
            / _SetPlayer.getExpPlayerDictionary()[Player.Instance.Level];
            Player.Instance.PlayerEffect.TextGUI((int)damage, new Color(0, 1, 0.753031f, 1));
            if (Player.Instance.PercentExp + exp >= 100)
            {
                Player.Instance.PercentExp = 0;
                Player.Instance.Level++;
                Player.Instance.PlayerEffect.TxtCurrentLevel.text = Player.Instance.Level.ToString();
            }
            else Player.Instance.PercentExp += (float)exp;
            Player.Instance.PlayerEffect.TxtCurrentPercentExp.text = (Player.Instance.PercentExp).ToString("F2") + "%";
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
            if (Player.Instance.Level >= 10)
            {
                hp = _SkillParameters.getSkillLv5Parameters()[6];
                mp = _SkillParameters.getSkillLv5Parameters()[6];
            }
            else
            {
                hp = _SkillParameters.getSkillLv5Parameters()[Player.Instance.Level - 4];
                mp = _SkillParameters.getSkillLv5Parameters()[Player.Instance.Level - 4];
            }
            Player.Instance.PlayerEffect.UpdateHp(hp);
            Player.Instance.PlayerEffect.UpdateMp(mp);
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
            if (Player.Instance.CurrMp < _FrameSkill[UseSkill.Instance.getCurrKeySkill()].mp)
            {
                Debug.Log("khong du Mana de su dung  " + Player.Instance.CurrMp);
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