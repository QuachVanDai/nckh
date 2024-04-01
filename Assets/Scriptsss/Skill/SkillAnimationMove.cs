using DG.Tweening;
using UnityEngine;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillAnimationMove : MonoBehaviour
    {
        [SerializeField] SpriteRenderer skillSpriteMove;
        Vector2 positionStart;
        public Transform target;
        protected void Awake()
        {
            positionStart = transform.localPosition;
        }
        public void AnimationSkill(FrameSkill _frameSkill)
        {
            gameObject.SetActive(true);
            StartCoroutine(AnimatorFrame.FrameGame(skillSpriteMove, _frameSkill.framesMove, true, null, 0.05f));
            MoveSkill();
        }
      
        void MoveSkill()
        {
            transform.DOKill();
            transform.localPosition = positionStart;
            var t = transform.DOMoveX(target.position.x, 0.5f).OnComplete(() => DisActive());
        }
        void DisActive()
        {
            gameObject.SetActive(false);
        }

    }

}

