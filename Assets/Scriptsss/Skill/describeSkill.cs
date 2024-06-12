
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class DescribeSkill : MonoBehaviour
    {
        [SerializeField] Text describeSkillText;
        RectTransform rectTransform=>GetComponent<RectTransform>();
        Vector2 posStart;
        private void Start ()
        {
            posStart = rectTransform.anchoredPosition;
        }
        public void Show(string title, string contend, int requiresLevel, int damage, int level,int upgradeFee)
        {
            describeSkillText.text = title + "\n";
            describeSkillText.text += contend + "\n";
            describeSkillText.text += "RequiresLevel: " + requiresLevel + "\n";
            describeSkillText.text += "Damage: " + damage + "\n";
            describeSkillText.text += "Skill Level: " + level + "\n";
            describeSkillText.text += "Upgrade Fee: " + upgradeFee + "\n";
        }
        public void ResetPosition()
        {
            rectTransform.anchoredPosition = posStart;
        }
        public void SetActive(bool _values)
        {
            gameObject.SetActive(_values);
        }
    }

}
