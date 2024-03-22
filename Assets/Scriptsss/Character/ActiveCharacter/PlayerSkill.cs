using QuachDai.NinjaSchool.Animations;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerSkill : MonoBehaviour
    {
        [SerializeField]  SkillAnimation skillAnimation;
        [SerializeField]  FrameSkill[] frameSkill;
        [SerializeField]  SkillRecoveryTime[] skillRecoveryTimes;
        private SetSkillParameters skillParameters = new SetSkillParameters();
        public bool isActtack, isSkillLv5, isSkillLv15, isIncreaseDamage;
        Player player => Player.Instance;
         UseSkill useSkill=>  UseSkill.Instance;
        TextTemplate textTemplate=> TextTemplate.Instance;
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        private void Start()
        {
            isActtack = true;
            isSkillLv5 = true;
            isSkillLv15 = true;
            isIncreaseDamage = false;
        }
        public void SkillAttack()
        {
            StartCoroutine(_SkillAttack());
            IEnumerator _SkillAttack()
            {
                skillAnimation.AnimationSkill(frameSkill[useSkill.getCurrKeySkill()]);
                animatorSystem.SetBool(player.GetAnimator(), "IsAttack", true);
                isActtack = false;
                player.SetMp(frameSkill[useSkill.getCurrKeySkill()].mp * (-1));
                yield return new WaitForSeconds(0.23f);
                animatorSystem.SetBool(player.GetAnimator(), "IsAttack", false);
                skillRecoveryTimes[useSkill.getCurrKeySkill()].isTime = true;
                yield return new WaitForSeconds(frameSkill[useSkill.getCurrKeySkill()].timeSkill);
                isActtack = true;
                skillRecoveryTimes[useSkill.getCurrKeySkill()].isTime = false;
            }
        }
        public void SkillLevel5()
        {
            if (useSkill.getIsUseSkill(1) == false) { return; }
            ManaUseSkill();
            if (!isSkillLv5) { textTemplate.SetText(TagScript.hoiChieu); return; }
            if (isSkillLv5)
            {
                StartCoroutine(UseSkillLv5());
            }
             IEnumerator UseSkillLv5()
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
        }
        public void InCreaseDamage( ref float damage)
        {
            if (isIncreaseDamage)
            {
                if (player.GetLevel() >= 20)
                    damage += skillParameters.getSkillLv15Parameters()[6];
                else
                {
                    damage += skillParameters.getSkillLv15Parameters()[player.GetLevel() - 14];
                }
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
        public void SkillLevel15()
        {
            if (useSkill.getIsUseSkill(3) == false) { return; }
            ManaUseSkill();
            if (!isSkillLv15) { textTemplate.SetText(TagScript.hoiChieu); return; }
            if (isSkillLv15)
            {
                StartCoroutine(UseSkillLv15());
            }
             IEnumerator UseSkillLv15()
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
        }
        public void ManaUseSkill()
        {
            if (player.GetMp() < frameSkill[useSkill.getCurrKeySkill()].mp)
            {
                Debug.Log("khong du Mana de su dung  " + player.GetMp());
                return;
            }

        }
        public float GetCoefficient()
        {
            return frameSkill[useSkill.getCurrKeySkill()].coefficient;
        }
    }
}
