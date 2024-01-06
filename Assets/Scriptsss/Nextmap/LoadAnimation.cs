using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadAnimation : NCKHMonoBehaviour
{
    private static LoadAnimation _instance;
    public GameObject sprite_Time1;
    public GameObject sprite_Time2;
    public Sprite[] img;
    public int number=0;

    public static LoadAnimation Instance {  get { return _instance; } }

    protected override void Awake()
    {
        base.Awake();
        LoadAnimation._instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        number = 0;
    }
    public void getLoadmap()
    {
        InvokeRepeating(nameof(loadMap), 0, 2 / 100f);

    }
    public void loadMap()
    {
        number++;
        if (number > 99)
        {
            CancelInvoke(nameof(loadMap)); 
            return; 
        }
        sprite_Time1.GetComponent<Image>().sprite = img[number/10];
        sprite_Time2.GetComponent<Image>().sprite = img[number%10];
    }
    // Update is called once per frame
    void Update()
    {

    }
}
