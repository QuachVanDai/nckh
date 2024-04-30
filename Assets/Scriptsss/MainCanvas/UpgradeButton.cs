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
        AudioClip clip => ClipSystem.Instance.buttonClip;

        [SerializeField] SkillPanel skillPanel;
        private void ListenerMethod()
        {
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
