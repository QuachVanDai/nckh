using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.MainCanvas;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillPanel : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] SelectSkill[] selectSkillList;
        [SerializeField] SelectSkill selectSkill;
        [SerializeField] DescribeSkill describeSkill;
        [SerializeField] FrameSkill frameSkill;
        [SerializeField] Image icon;
        [SerializeField] UpgradeButton upgradeButton;
        private void Start()
        {
            icon.sprite = frameSkill.icon;
        }
        public FrameSkill GetFrameSkill()
        {
            return frameSkill;
        }
        public int GetUpgradeFee()
        {
            return frameSkill.upgradeFee;
        }
        public int GetRequiresLevel()
        {
            return frameSkill.requiresLevel;
        }
        public void Upgrade()
        {
            if (frameSkill.requiresLevel > Player.Instance.GetLevel())
                TextTemplate.Instance.SetText("Level is not enough to upgrade");
            else if (frameSkill.skillLevel >= 3)
                TextTemplate.Instance.SetText("Maximum level reached");
            else
            {
                frameSkill.skillLevel += 1;
                frameSkill.SetFrameSkill(frameSkill);
                Show();
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            upgradeButton.SetSkillPanel(this);
            HideSelectSkill();
            Show();
        }
        public void Show()
        {
            upgradeButton.SetActive(true);
            describeSkill.ResetPosition();
            float _skillDamage = frameSkill.skillDamage +
                (frameSkill.skillDamage * Mathf.Pow(frameSkill.skillLevel, frameSkill.coefficient));
            describeSkill.Show(frameSkill.skillName,
                                frameSkill.description,
                                frameSkill.requiresLevel,
                                (int)_skillDamage,
                                frameSkill.skillLevel,
                                frameSkill.upgradeFee);
        }
        public void HideSelectSkill()
        {
            for (int i = 0; i < 5; i++)
                selectSkillList[i].SetActive(false);
            selectSkill.SetActive(true);
        }

    }
}
/*
  500 * 
 
 
 */
