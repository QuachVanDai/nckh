using UnityEngine;

namespace QuachDai.NinjaSchool.Animations
{
    public class AnimatorSystem : Singleton<AnimatorSystem>
    {
        public void SetBool(Animator animator,string key, bool values)
        {
            animator.SetBool(key, values);
        }
        public void SetFloat(Animator animator, string key, float values)
        {
            animator.SetFloat(key, values);
        }
    }
}
