
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Skill
{
    public class DescribeSkill : MonoBehaviour
    {
        [SerializeField] Text describeSkillText;

        public void Show(string title, string contend)
        {
            describeSkillText.text = title + "\n";
            describeSkillText.text = contend;
        }
    }
    
}
