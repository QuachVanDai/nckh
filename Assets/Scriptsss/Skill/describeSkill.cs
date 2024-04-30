
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class DescribeSkill : MonoBehaviour
    {
        [SerializeField] Text describeSkillText;

        public void Show(string title, string contend, int requiresLevel, int damage, int level)
        {
            describeSkillText.text = title + "\n";
            describeSkillText.text += contend + "\n";
            describeSkillText.text += "RequiresLevel: " + requiresLevel + "\n";
            describeSkillText.text += "Damage: " + damage + "\n";
            describeSkillText.text += "Skill Level: " + level + "\n";
        }
    }

}
