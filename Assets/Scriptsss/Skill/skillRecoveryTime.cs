
using UnityEngine;
using UnityEngine.UI;

public class SkillRecoveryTime: MonoBehaviour
{
    [SerializeField]
    private FrameSkill FrameSkill;
    [SerializeField]
    private Image Fill_time;
    private float getTime;
    public bool isTime;
    public void Update()
    {
        if (!isTime) { getTime = Time.time; return; }
        Fill_time.fillAmount = 1 -( (Time.time - getTime)/ FrameSkill.timeSkill);
    }

}
