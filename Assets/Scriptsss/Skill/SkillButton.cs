using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.EventSystems;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillButton : MonoBehaviour, IPointerDownHandler
    {
        public IDSkill IDSkill;
        [SerializeField] SelectSkill[] selectSkillList;
        [SerializeField] DescribeSkill describeSkill;
        [SerializeField] bool isCheckLevel;
        [SerializeField] bool isDescription;
        SkillManager skillManager => SkillManager.Instance;
        public FrameSkill frameSkill;
        int currentIndexSkill;
        int lastIndexSkill;
        Player player => Player.Instance;
        void Start()
        {
            currentIndexSkill = (int)IDSkill - 1;
            frameSkill = skillManager.GetFrameSkill(currentIndexSkill);
            if (IDSkill == IDSkill.SkillLv1)
            {
                HideSelectSkill();
                selectSkillList[0].SetActive(true);
                if (describeSkill != null)
                    describeSkill.Show(frameSkill.skillName, frameSkill.description);
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (isCheckLevel)
            {
                if (player.GetLevel() >= frameSkill.level)
                {
                    HideSelectSkill();
                    selectSkillList[currentIndexSkill].SetActive(true);
                }
            }
            else if (isDescription)
            {
                HideSelectSkill();
                selectSkillList[currentIndexSkill].SetActive(true);
                if (describeSkill != null)
                    describeSkill.Show(frameSkill.skillName, frameSkill.description);
            }

        }
        public void HideSelectSkill()
        {
            for (int i = 0; i < 5; i++)
                selectSkillList[i].SetActive(false);
        }
    }
}
