
using UnityEngine;
using DG.Tweening;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;

public class SkillAnimation : MonoBehaviour
{
    SpriteRenderer skillSprite;
    Vector2 positionStart;
    public Transform target;
    protected  void Awake()
    {
        positionStart = transform.localPosition;
        skillSprite = GetComponent<SpriteRenderer>();
    }
    public void AnimationSkill(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        StartCoroutine(AnimatorFrame.FrameGame(skillSprite, _frameSkill.skillFrames, true, null, 0.05f));
        MoveSkill();
    }
    public void AnimationSkillLv5_15(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        transform.localPosition = positionStart;
        StartCoroutine(AnimatorFrame.FrameGame(skillSprite, _frameSkill.skillFrames, true, DisActive, 0.05f));
    }
    void MoveSkill()
    {
        transform.DOKill();
        transform.localPosition = positionStart;
        var t = transform.DOMoveX(target.position.x, 0.5f).OnComplete(()=> DisActive());
    }
    void DisActive()
    {
        gameObject.SetActive(false);
    }
  
}
