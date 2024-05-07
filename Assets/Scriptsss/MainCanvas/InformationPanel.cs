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
        string namePlayer => player.GetNamePlayer();
        string level => player.GetLevel().ToString();

        string exp => player.GetPercentExp().ToString("F2");
        string hp => player.GetHp() + "/" + player.GetMaxHp();
        string mp => player.GetMp() + "/" + player.GetMaxMp();
        string attackMin => player.GetMinDamage().ToString();
        string attackMax => player.GetMaxDamage().ToString();
        public void UpdateInformation()
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
            nameText.text = "Name : " + namePlayer;
        }

        public void GetLevelText()
        {
            levelText.text = "Level : " + level;
        }

        public void GetExpText()
        {
            expText.text = "Exp : " + exp + " %";
        }

        public void GetHpText()
        {
            hpText.text = "Hp : " + hp;
        }
        public void GetMpText()
        {
            mpText.text = "Mp : " + mp;
        }
        public void GetAttackText()
        {
            attackText.text = "Attack : " + attackMin + " - " + attackMax;
        }
        int levelInt => player.GetLevel();
        public void GetWindSkillText()
        {

            if (levelInt >= 1)
                windSkillText.text = "WindSkill : Yes";
            else windSkillText.text = "WindSkill : No";
        }
        public void GetFireSkillText()
        {
            if (levelInt >= 15)
                fireSkillText.text = "FireSkill : Yes";
            else fireSkillText.text = "FireSkill : No";
        }
        public void GetIceSkillText()
        {
            if (levelInt >= 20)
                iceSkillText.text = "IceSkill : Yes";
            else iceSkillText.text = "IceSkill : No";
        }
    }
}
