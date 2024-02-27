
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadAnimation : Singleton<LoadAnimation>
{
    public GameObject sprite_Time1;
    public GameObject sprite_Time2;
    public Sprite[] img;
    public int number=0;

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
}
