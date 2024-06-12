using UnityEngine;

[CreateAssetMenu(menuName = "Animations/Frame Skill")]
public class FrameSkill : ScriptableObject
{
    public IDSkill IDSkill;
    public Sprite icon;
    public string skillName;
    public int requiresLevel;
    public int skillLevel;
    public Sprite[] framesMove;
    public Sprite[] framesFont;
    public Sprite[] framesStart;
    public Sprite[] framesPosMonster;
    public int mp;
    public float timeSkill;
    public int skillDamage;
    public int increasedHPMP;
    public int upgradeFee;
    public float coefficient;
    public bool isBlock=false;
    public bool isActack=false;
    public string description;

    public void SetFrameSkill(FrameSkill _frameSkill)
    {
        IDSkill = _frameSkill.IDSkill;
        icon = _frameSkill.icon;
        skillName = _frameSkill.skillName;
        requiresLevel = _frameSkill.requiresLevel;
        skillLevel = _frameSkill.skillLevel;
        framesMove = _frameSkill.framesMove;
        framesFont = _frameSkill.framesFont;
        framesStart = _frameSkill.framesStart;
        framesPosMonster = _frameSkill.framesPosMonster;
        mp = _frameSkill.mp;
        timeSkill = _frameSkill.timeSkill;
        skillDamage = _frameSkill.skillDamage;
        increasedHPMP = _frameSkill.increasedHPMP;
        coefficient = _frameSkill.coefficient;
        isBlock = _frameSkill.isBlock;
        isActack = _frameSkill.isActack;
        description = _frameSkill.description;
    }
}
public enum IDSkill
{
    none =0,
    SkillLv1 =1,
    SkillLv5 =2,
    SkillLv10 =3,
    SkillLv15 =4,
    SkillLv20 =5,
}