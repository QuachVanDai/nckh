using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Sound
{
    public class ClipSystem : Singleton<ClipSystem>
    {
        public AudioClip attackMonsterClip;
        public AudioClip[] skillClip;
        public AudioClip buttonClip;
        public AudioClip walkClip;
        public AudioClip monsterClip;
        public AudioClip useHpMpClip;
        public int GetIndex()
        {
            return Random.Range(0, skillClip.Length);
        }
    }
}
