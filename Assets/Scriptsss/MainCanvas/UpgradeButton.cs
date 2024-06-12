using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Skill;
using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class UpgradeButton : MonoBehaviour
    {
        Button button;
        [SerializeField]
        Button ThisButton
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
        public void SetActive(bool _values)
        {
            gameObject.SetActive(_values);
        }
        [SerializeField] SkillPanel skillPanel;
        Player player => Player.Instance;
        private void ListenerMethod()
        {
            if (player.GetLevel() < skillPanel.GetRequiresLevel())
            {
                TextTemplate.Instance.SetText("RequiresLevel: " + skillPanel.GetRequiresLevel());
                return;
            }
            if (player.GetXu() < skillPanel.GetUpgradeFee())
            {
                TextTemplate.Instance.SetText(TagScript.notMoney+ " < " + skillPanel.GetUpgradeFee());
                return;
            }
            player.SetXu(-skillPanel.GetUpgradeFee());
            skillPanel.Upgrade();
        }
        public SkillPanel GetSkillPanel()
        {
           return skillPanel;
        }
        public void SetSkillPanel(SkillPanel _skillPanel)
        {
            skillPanel=_skillPanel;
        }
    }
}
