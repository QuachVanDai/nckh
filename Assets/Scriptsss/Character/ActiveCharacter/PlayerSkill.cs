using QuachDai.NinjaSchool.Animations;
using QuachDai.NinjaSchool.Skill;
using System;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerSkill : MonoBehaviour
    {
        [SerializeField] SkillAnimation skillAnimation;
        [SerializeField] FrameSkill frameSkill;
        [SerializeField] SkillRecoveryTime skillRecoveryTime;
        private SetSkillParameters skillParameters = new SetSkillParameters();
        public bool isActtack, isSkillLv5, isSkillLv15, isIncreaseDamage;
        Player player => Player.Instance;
        TextTemplate textTemplate => TextTemplate.Instance;
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        private void Start()
        {
            isActtack = true;
            isSkillLv5 = true;
            isSkillLv15 = true;
            isIncreaseDamage = false;
        }
        public void SetFrameSkill(FrameSkill _frameSkill)
        {
            frameSkill = _frameSkill;
        }
        public void SetSkillRecoveryTimes(SkillRecoveryTime _skillRecoveryTime)
        {
            skillRecoveryTime = _skillRecoveryTime;
        }
        public void SkillAttack(Action _damaged, Action _addExp)
        {
            StartCoroutine(_SkillAttack());
            IEnumerator _SkillAttack()
            {
               
                animatorSystem.SetBool(player.GetAnimator(), "IsAttack", true);
                isActtack = false;
                player.SetMp(frameSkill.mp * (-1));
                yield return new WaitForSeconds(0.23f);
                skillRecoveryTime.isTime = true;
                animatorSystem.SetBool(player.GetAnimator(), "IsAttack", false);
                _damaged?.Invoke();
                _addExp?.Invoke();
                skillAnimation.AnimationSkill(frameSkill);
                yield return new WaitForSeconds(frameSkill.timeSkill);
                isActtack = true;
                skillRecoveryTime.isTime = false;
            }
        }
       

        public void InCreaseHPMP()
        {
            float hp, mp;
            if (player.GetLevel() >= 10)
            {
                hp = skillParameters.getSkillLv5Parameters()[6];
                mp = skillParameters.getSkillLv5Parameters()[6];
            }
            else
            {
                hp = skillParameters.getSkillLv5Parameters()[player.GetLevel() - 4];
                mp = skillParameters.getSkillLv5Parameters()[player.GetLevel() - 4];
            }
            player.SetHp(hp);
            player.SetMp(mp);
        }
        public void SkillLevel5()
        {
            ManaUseSkill();
            if (!isSkillLv5)
            {
                textTemplate.SetText(TagScript.hoiChieu);
                return;
            }
            if (isSkillLv5)
                StartCoroutine(_UseSkillLv5());
            IEnumerator _UseSkillLv5()
            {
                skillAnimation.AnimationSkillLv5_15(frameSkill);
                isSkillLv5 = false;
                InvokeRepeating(nameof(InCreaseHPMP), 0, 0.5f);
                skillRecoveryTime.isTime = true;
                yield return new WaitForSeconds(1.5f);
                CancelInvoke(nameof(InCreaseHPMP));
                yield return new WaitForSeconds(frameSkill.timeSkill - 1.5f);
                skillRecoveryTime.isTime = false;
                isSkillLv5 = true;
            }
        }
        public void SkillLevel15()
        {
            if (!isSkillLv15)
            {
                textTemplate.SetText(TagScript.hoiChieu);
                return;
            }
            ManaUseSkill();

            if (isSkillLv15)
                StartCoroutine(_UseSkillLv15());

            IEnumerator _UseSkillLv15()
            {
                player.SetMp(frameSkill.mp * (-1));
                skillAnimation.AnimationSkillLv5_15(frameSkill);
                isSkillLv15 = false;
                isIncreaseDamage = true;
                skillRecoveryTime.isTime = true;
                yield return new WaitForSeconds(frameSkill.timeSkill);
                isSkillLv15 = true;
                isIncreaseDamage = false;
                skillRecoveryTime.isTime = false;
            }
        }
        public void ManaUseSkill()
        {
            if (player.GetMp() < frameSkill.mp)
            {
                Debug.Log("khong du Mana de su dung  " + player.GetMp());
                return;
            }

        }
        public float GetCoefficient()
        {
            return frameSkill.coefficient;
        }
    }
}
