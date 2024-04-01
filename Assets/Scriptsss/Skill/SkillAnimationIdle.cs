using UnityEngine;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillAnimationIdle : MonoBehaviour
    {

        [SerializeField] SpriteRenderer skillSpriteIdle;
        public Vector2 positionStart;
        public Transform target;
        protected void Awake()
        {
            positionStart = transform.localPosition;
        }
        public void AnimationSkillLv5_15(FrameSkill _frameSkill)
        {
            gameObject.SetActive(true);
            transform.localPosition = positionStart;
            StartCoroutine(AnimatorFrame.FrameGame(skillSpriteIdle, _frameSkill.framesStart, true, DisActive, 0.05f));
        }
        void DisActive()
        {
            gameObject.SetActive(false);
        }
    }
}
