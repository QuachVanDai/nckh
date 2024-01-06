using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : NCKHMonoBehaviour
{
    private static Player instance;
    public string Name;
    public float Currhp;
    public float Currmp;
    public string ClassName;
    public int Level;
    public float PercentExp;
    public int Gold;
    public int MinDamage;
    public int MaxDamage;
    public RectTransform canvas;

    public TextMeshProUGUI TxtCurrentName;
    public TextMeshProUGUI TxtCurrentHP;
    public TextMeshProUGUI TxtCurrentMP;
    public TextMeshProUGUI TxtCurrentClassName;
    public TextMeshProUGUI TxtCurrentMinDamage;
    public TextMeshProUGUI TxtCurrentMaxDamage;
    public TextMeshProUGUI TxtCurrentLevel;
    public TextMeshProUGUI TxtCurrentPercentExp;
    public TextMeshProUGUI TxtCurrentGold;

    public GameObject txt_damaged;
    public Image fill_bar_HP;
    public Image fill_bar_MP;
    public setPlayer _setPlayer;

    private float _hp;
    private float _mp;

    public float HP { get { return _hp; } }
    public float MP { get { return _mp; } }
    public static Player Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        Player.instance = this;
    }
    public void textGUI(int damage,Color color)
    {
        GameObject g = Instantiate(txt_damaged);
          numberTxt numberTxt = g.GetComponent<numberTxt>();
        numberTxt.aniTextY1(canvas,(int)damage, new Vector3(0, 1.2f, 0), 1, 0.5f, color);
    }
    protected override void loadComponets()
    {
        base.loadComponets();
        _setPlayer = new setPlayer();
        Level = 20;
        MinDamage = _setPlayer.getDamePlayerDictionary(Level).Item1;
        MaxDamage = _setPlayer.getDamePlayerDictionary(Level).Item2;
        Currhp = _setPlayer.getHPPlayerDictionary()[Level];
        Currmp = _setPlayer.getMPPlayerDictionary()[Level];
        _hp = Currhp;
        _mp = Currmp;

      //  numberTxt =  txt_damaged.GetComponent<numberTxt>();

        GameObject Object = GameObject.Find("txt_hp");
        TxtCurrentHP = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("txt_mp");
        TxtCurrentMP = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("percentage");
        TxtCurrentPercentExp = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("level");
        TxtCurrentLevel = Object.GetComponent<TextMeshProUGUI>();

        Object = GameObject.Find("full_hp");
        fill_bar_HP = Object.GetComponent<Image>();

        Object = GameObject.Find("full_mp");
        fill_bar_MP = Object.GetComponent<Image>();

        Object = GameObject.Find("PlayerCanvas");
        canvas = Object.GetComponent<RectTransform>();

        Object = GameObject.Find("NamePlayer");
        TxtCurrentName = Object.GetComponent<TextMeshProUGUI>();

        TxtCurrentName.text = Name.ToString();
        TxtCurrentLevel.text = Level.ToString();
        TxtCurrentPercentExp.text = PercentExp.ToString("F2")+"%";
        UpdateXu(0);
        update_hp(0);
        update_mp(0);
    }

 
    public Player GetCharacter()
    {
        return this;
    }
    public void update_hp(float hp)
    {
        Currhp += hp;
        Currhp = Currhp >= HP?HP:Currhp;
        fill_bar_HP.fillAmount = Currhp / HP;
        TxtCurrentHP.text = Currhp.ToString();
    }
    public void update_mp(float mp)
    {
        Currmp += mp;
        Currmp = Currmp >= MP ? MP : Currmp;
        fill_bar_MP.fillAmount = Currmp / MP;
        TxtCurrentMP.text =Currmp.ToString();
    }
    public bool UpdateXu(int number)
    {
        Gold += number;
        if(Gold<=0)
        {
            Gold = 0;
            TxtCurrentGold.text = 0+"";
            return false;
        }
        TxtCurrentGold.text = Gold.ToString();
        return true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "potion")
        {
            useItem i = collision.gameObject.GetComponent<useItem>();
            inventoryManager.Instance.Add(i.item,1);
        }
    }

}
