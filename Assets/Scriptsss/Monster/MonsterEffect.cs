using QuachDai.NinjaSchool.Spawn;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterEffect : MonoBehaviour
    {
        [SerializeField] private Image hpBar;
        [SerializeField] private RectTransform canvasUi;
        [SerializeField] private NumberTxt textDamaged;

        public void TexTGui(int Damge, Color Color)
        {
            Spawner.Instance.Spawn(textDamaged.transform, transform.position, Quaternion.identity, null);
            textDamaged.aniTextY1(canvasUi, (int)Damge, new Vector3(0, 1.2f, 0), 1, 0.5f, Color);
        }
        public void UpdateHp(float CurrentHp, float MaxHp, string Name, int Level)
        {
            hpBar.fillAmount = (float)CurrentHp / (float)MaxHp;
            SystemUi.Instance.InfoMonster.text = " " + Name + "  " + "Lv" + Level + " " + CurrentHp.ToString() + "/" + MaxHp.ToString();
            SystemUi.Instance.InfoMonster.gameObject.SetActive(true);
        }
    }
}
