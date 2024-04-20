using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] Text nameText;
        [SerializeField] Text levelText;
        [SerializeField] Text expText;
        [SerializeField] Text hpText;
        [SerializeField] Text mpText;
        [SerializeField] Text attackText;
        [SerializeField] Text windSkillText;
        [SerializeField] Text fireSkillText;
        [SerializeField] Text iceSkillText;

        Player player => Player.Instance;
        private void Start()
        {
            GetNameText();
            GetLevelText();
            GetExpText();
            GetHpText();
            GetMpText();
            GetAttackText();
            GetWindSkillText();
            GetFireSkillText();
            GetIceSkillText();
        }
        public void GetNameText()
        {
            nameText.text = "Name : " + player.GetNamePlayer();
        }

        public void GetLevelText()
        {
            levelText.text = "Level : " + player.GetLevel();
        }

        public void GetExpText()
        {
            expText.text = "Exp : " + player.GetPercentExp().ToString() + " %";
        }

        public void GetHpText()
        {
            hpText.text = "Hp : " + player.GetHp() + "/" + player.GetMaxHp();
        }
        public void GetMpText()
        {
            mpText.text = "Mp : " + player.GetMp() + "/" + player.GetMaxMp();
        }
        public void GetAttackText()
        {
            attackText.text = "Attack : " + player.GetMinDamage() + " - " + player.GetMaxDamage();
        }
        public void GetWindSkillText()
        {
            if (player.GetLevel() >= 1)
                windSkillText.text = "WindSkill : Yes";
            else windSkillText.text = "WindSkill : No";
        }
        public void GetFireSkillText()
        {
            if (player.GetLevel() >= 15)
                fireSkillText.text = "FireSkill : Yes";
            else fireSkillText.text = "FireSkill : No";
        }
        public void GetIceSkillText()
        {
            if (player.GetLevel() >= 20)
                iceSkillText.text = "IceSkill : Yes";
            else iceSkillText.text = "IceSkill : No";
        }
    }
}
