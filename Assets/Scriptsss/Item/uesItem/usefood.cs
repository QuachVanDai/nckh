﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class usefood: NCKHMonoBehaviour
{
    // Start is called before the first frame update
    public inventoryUpdate inventoryUpdate;
    public foodSO foodSO;
    public TextMeshProUGUI txt_FirstTime;
    public TextMeshProUGUI txt_SecondTime;
    public bool flat;
    public Image Fill_time;
    private float getTime;
    public GameObject foodPanel;
    [Header("Đơn vị S")]
    public int ExpiredTime = 0; // thời gian hết hạn sử dụng thức ăn
    private int _expiredTimetmp ; // thời gian hết hạn sử dụng thức ăn

    void Start()
    {
        _expiredTimetmp = ExpiredTime;
        flat = true;
        getTime = 0;
    }
    public void useItemFood()
    {
        if(!inventoryUpdate.updateFood()) 
        { 
            TextTemplate.Instance.SetText(TagScript.notFood);
            return; 
        }
        if(flat) { foodPanel.gameObject.SetActive(true); InvokeRepeating(nameof(setTimeUse), 0, 1); flat = false; }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public void setTimeUse()
    {
        ExpiredTime--;
        Player.Instance.update_mp(foodSO.MP);
        Player.Instance.update_hp(foodSO.HP);
        txt_FirstTime.text = (ExpiredTime / 60).ToString()+":";
        txt_SecondTime.text = (ExpiredTime -  ((ExpiredTime / 60) * 60)).ToString();
        if (ExpiredTime <= 0)
        {
            flat = true;
            ExpiredTime = _expiredTimetmp;
            CancelInvoke(nameof(setTimeUse));
            foodPanel.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyUp(KeyCode.T))
        {
            useItemFood();
           // 
        }
        if (!flat)
        {
            Fill_time.fillAmount = (Time.time - getTime) / (ExpiredTime);
        }
    }
}