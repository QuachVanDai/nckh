
using UnityEngine;
using DG.Tweening;

public class SkillAnimation : MonoBehaviour
{
   [SerializeField] SpriteRenderer spriteStart;
   [SerializeField] SpriteRenderer skillFont;
   [SerializeField] SpriteRenderer spriteMove;
    public Vector2 positionStart;
    public Transform target;
    protected  void Awake()
    {
        positionStart = transform.localPosition;
    }
    public void AnimationSkill(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        StartCoroutine(AnimatorFrame.FrameGame(spriteStart, _frameSkill.framesStart, true, null, 0.05f));
        StartCoroutine(AnimatorFrame.FrameGame(skillFont, _frameSkill.framesFont, true, null, 0.05f));
        StartCoroutine(AnimatorFrame.FrameGame(spriteMove, _frameSkill.framesMove, true, null, 0.05f));
        MoveSkill();
    }
    public void AnimationSkillLv5_15(FrameSkill _frameSkill)
    {
        gameObject.SetActive(true);
        transform.localPosition = positionStart;
        StartCoroutine(AnimatorFrame.FrameGame(spriteStart, _frameSkill.framesStart, true, DisActive, 0.1f));
    }
    void MoveSkill()
    {
        spriteMove.transform.DOKill();
        spriteMove.transform.localPosition = positionStart;
        var t = spriteMove.transform.DOMoveX(target.position.x, 0.5f).OnComplete(()=> DisActive());
    }
    void DisActive()
    {
        gameObject.SetActive(false);
    }
  
}
