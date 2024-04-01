using QuachDai.NinjaSchool.Character;
using UnityEngine;
namespace QuachDai.NinjaSchool.Skill
{
    public class SkillManager :Singleton<SkillManager>
    {
        // Start is called before the first frame update
        [SerializeField] FrameSkill[] frameSkill;
        Player player =>Player.Instance;
        void Start()
        {
            UnlockSkills();
        }
        public FrameSkill GetFrameSkill(int index)
        {
            return frameSkill[index];
        }
        void UnlockSkills()
        {
            for(int i = 0; i < frameSkill.Length; i++)
            {
                if (player.GetLevel() >= frameSkill[i].level)
                {
                    frameSkill[i].isBlock = true;
                }
                else frameSkill[i].isBlock = false;
                Debug.Log(frameSkill[i].IDSkill+" "+ frameSkill[i].isBlock);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
