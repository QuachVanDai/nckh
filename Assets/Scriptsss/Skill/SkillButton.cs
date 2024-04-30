using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillButton : MonoBehaviour
    {
        [SerializeField] SelectSkill[] selectSkillList;
        [SerializeField] SelectSkill selectSkill;
        [SerializeField] FrameSkill frameSkill;
        [SerializeField] Image icon;

        public PlayerSkill playerSkill;
        public SkillRecoveryTime skillRecoveryTime;
        Player player => Player.Instance;

        private void Start()
        {
            icon.sprite = frameSkill.icon;

            if (frameSkill.IDSkill == IDSkill.SkillLv1)
            {
                playerSkill.SetFrameSkill(frameSkill);
                playerSkill.SetSkillRecoveryTimes(skillRecoveryTime);
                selectSkill.SetActive(true);

            }
            if (frameSkill.requiresLevel >= player.GetLevel())
                frameSkill.isBlock = true;
            else
                frameSkill.isBlock = false;
        }
        public FrameSkill GetFrameSkill()
        {
            return frameSkill;
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
                    button = GetComponent<Button>();
                return button;
            }
        }

        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }

        private void ListenerMethod()
        {
            if (player.GetLevel() >= frameSkill.requiresLevel)
            {
                HideSelectSkill();
                playerSkill.SetFrameSkill(frameSkill);
                playerSkill.SetSkillRecoveryTimes(skillRecoveryTime);
                if (frameSkill.IDSkill == IDSkill.SkillLv5)
                    playerSkill.SkillLevel5();
            }
        }
    }
}
