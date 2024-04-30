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
        public void Upgrade()
        {
            if (frameSkill.skillLevel>=3)
            {
                TextTemplate.Instance.SetText("Đã đạt cấp độ tối đa");
                return;
            }
            frameSkill.skillLevel += 1;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            upgradeButton.SetSkillPanel(this);
            HideSelectSkill();
            float _skillDamage = frameSkill.skillDamage +
                (frameSkill.skillDamage * Mathf.Pow( frameSkill.skillLevel,frameSkill.coefficient));
            describeSkill.Show(frameSkill.skillName,
                                frameSkill.description,
                                frameSkill.requiresLevel,
                                (int)_skillDamage,
                                frameSkill.skillLevel);
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
