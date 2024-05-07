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
            if (player.GetXu() < 1000)
            {
                TextTemplate.Instance.SetText(TagScript.notMoney+ " <1000");
                return;
            }
            player.SetXu(-100);
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
