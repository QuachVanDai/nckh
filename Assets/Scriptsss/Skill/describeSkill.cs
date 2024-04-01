
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescribeSkill : MonoBehaviour
{
    [SerializeField] Text describeSkillText;
   
    public void Show(string title,string contend)
    {
        describeSkillText.text = title+"\n";
        describeSkillText.text = contend;
    }
    
}
