
using UnityEngine;
using UnityEngine.UI;

public class SkillRecoveryTime: MonoBehaviour
{
    [SerializeField]
    private FrameSkill frameSkill;
    [SerializeField]
    private Image fillTime;
    private float getTime;
    public bool isTime;
    public void Update()
    {
        if (!isTime) 
        {
            frameSkill.isActack = true;
            getTime = Time.time; 
            return; 
        }
        fillTime.fillAmount = 1 -( (Time.time - getTime)/ frameSkill.timeSkill);
        frameSkill.isActack = false;
    }
    public void SetFrameSkill(FrameSkill _frameSkill)
    {
        this.frameSkill = _frameSkill;
    }
}
