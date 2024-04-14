using QuachDai.NinjaSchool.Character;
using System.Buffers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] SelectSkill[] selectSkillList;
        [SerializeField] SelectSkill selectSkill;
        [SerializeField] DescribeSkill describeSkill;
        [SerializeField] bool isCheckLevel;
        [SerializeField] bool isDescription;
        [SerializeField] FrameSkill frameSkill;
        [SerializeField] Image icon;

        public PlayerSkill playerSkill;
        public SkillRecoveryTime skillRecoveryTime;
        Player player => Player.Instance;

        private void Start()
        {
            icon.sprite = frameSkill.icon;
            
            if (frameSkill.IDSkill == IDSkill.SkillLv1 && isCheckLevel)
            {
                playerSkill.SetFrameSkill(frameSkill);
                playerSkill.SetSkillRecoveryTimes(skillRecoveryTime);
                selectSkill.SetActive(true);

            }
            if (frameSkill.level >= player.GetLevel())
                frameSkill.isBlock = true;
            else
                frameSkill.isBlock = false;
        }
        public FrameSkill GetFrameSkill()
        {
            return frameSkill;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (isCheckLevel)
            {
                if (player.GetLevel() >= frameSkill.level)
                    HideSelectSkill();
            }
            else if (isDescription)
            {
                HideSelectSkill();
                if (describeSkill != null)
                    describeSkill.Show(frameSkill.skillName, frameSkill.description);
            }

        }
        public void HideSelectSkill()
        {
            for (int i = 0; i < 5; i++)
                selectSkillList[i].SetActive(false);
            selectSkill.SetActive(true);
        }
        Button button;
        public Button ThisButton
        {
            get
            {
                if (button == null)
                {
                    button = GetComponent<Button>();
                }
                return button;
            }
        }

        private void OnEnable()
        {
            ThisButton.onClick.AddListener(OnClickListener);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(OnClickListener);
        }

        private void OnClickListener()
        {
            playerSkill.SetFrameSkill(frameSkill);
            playerSkill.SetSkillRecoveryTimes(skillRecoveryTime);
        }
    }
}
