using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEffect : MonoBehaviour
{
    public TextMeshProUGUI TxtCurrentName;
    public TextMeshProUGUI TxtCurrentHP;
    public TextMeshProUGUI TxtCurrentMP;
/*    public TextMeshProUGUI TxtCurrentMinDamage;
    public TextMeshProUGUI TxtCurrentMaxDamage;*/
    public TextMeshProUGUI TxtCurrentLevel;
    public TextMeshProUGUI TxtCurrentPercentExp;
    public TextMeshProUGUI TxtCurrentGold;

    public GameObject TxtDamaged;
    public Image FillBarHP;
    public Image FillBarMP;
    public RectTransform canvas;
    private void Reset()
    {
        LoadComponent();
    }
    public void TextGUI(int damage, Color color)
    {
        GameObject g = Instantiate(TxtDamaged);
        NumberTxt numberTxt = g.GetComponent<NumberTxt>();
        numberTxt.aniTextY1(canvas, (int)damage, new Vector3(0, 1.2f, 0), 1, 0.5f, color);
    }
    protected void LoadComponent()
    {
        GameObject Object = GameObject.Find("TxtHp");
        TxtCurrentHP = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("TxtMp");
        TxtCurrentMP = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("Percentage");
        TxtCurrentPercentExp = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("TextGold");
        TxtCurrentGold = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("Level");
        TxtCurrentLevel = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("FullHp");
        FillBarHP = Object.GetComponent<Image>();

        Object = GameObject.Find("FullMp");
        FillBarMP = Object.GetComponent<Image>();

        Object = GameObject.Find("PlayerCanvas");
        canvas = Object.GetComponent<RectTransform>();

        Object = GameObject.Find("NamePlayer");
        TxtCurrentName = Object.GetComponent<TextMeshProUGUI>();

     
    }
    private void Start()
    {
        UpdateHp(0);
        UpdateMp(0);
        UpdateXu(0);
        TxtCurrentLevel.text = Player.Instance.Level.ToString();
        TxtCurrentPercentExp.text = (Player.Instance.PercentExp).ToString("F2") + "%";
    }
    public void UpdateHp(float hp)
    {
         Player.Instance.CurrHp += hp;
         Player.Instance.CurrHp =  Player.Instance.CurrHp >=  Player.Instance.MaxHp ?  Player.Instance.MaxHp :  Player.Instance.CurrHp;
        FillBarHP.fillAmount =  Player.Instance.CurrHp /  Player.Instance.MaxHp;
        TxtCurrentHP.text =  Player.Instance.CurrHp.ToString();
    }
    public void UpdateMp(float mp)
    {
         Player.Instance.CurrMp += mp;
         Player.Instance.CurrMp =  Player.Instance.CurrMp >=  Player.Instance.MaxMp ?  Player.Instance.MaxMp :  Player.Instance.CurrMp;
        FillBarMP.fillAmount =  Player.Instance.CurrMp /  Player.Instance.MaxMp;
        TxtCurrentMP.text =  Player.Instance.CurrMp.ToString();
    }
    public bool UpdateXu(int number)
    {

         Player.Instance.Gold += number;
        if ( Player.Instance.Gold <= 0)
        {
             Player.Instance.Gold = 0;
            TxtCurrentGold.text = 0 + "";
            return false;
        }
        TxtCurrentGold.text =  Player.Instance.Gold.ToString();
        return true;
    }
}
