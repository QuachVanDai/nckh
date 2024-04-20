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
        private void Start()
        {
            icon.sprite = frameSkill.icon;
        }
        public FrameSkill GetFrameSkill()
        {
            return frameSkill;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            HideSelectSkill();
            describeSkill.Show(frameSkill.skillName, frameSkill.description);

        }
        public void HideSelectSkill()
        {
            for (int i = 0; i < 5; i++)
                selectSkillList[i].SetActive(false);
            selectSkill.SetActive(true);
        }
    }
}
