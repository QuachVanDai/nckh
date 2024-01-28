using UnityEngine;
using UnityEngine.UI;

public class MonsterEffect : MonoBehaviour
{
    [SerializeField] private Image _HpBar;
    [SerializeField] private RectTransform _CanvasUi;
    [SerializeField] private GameObject _TxtDamaged;

    public void TexTGui(int Damge, Color Color)
    {

        GameObject g = Instantiate(_TxtDamaged);
        NumberTxt numberTxt = g.GetComponent<NumberTxt>();
        numberTxt.aniTextY1(_CanvasUi, (int)Damge, new Vector3(0, 1.2f, 0), 1, 0.5f, Color);
    }
    public void UpdateHp(float CurrentHp, float MaxHp, string Name, int Level)
    {
        _HpBar.fillAmount = (float)CurrentHp / (float)MaxHp;
        systemUi.Instance.infoMonster.text = " " + Name + "  " + "Lv" + Level + " " + CurrentHp.ToString() + "/" + MaxHp.ToString();
        systemUi.Instance.infoMonster.gameObject.SetActive(true);
    }
}
