using TMPro;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;

public class usefood: MonoBehaviour
{
    // Start is called before the first frame update
    public Slot SlotFoodSO;
    public TextMeshProUGUI TxtFirstTime;
    public TextMeshProUGUI TxtSecondTime;
    public bool IsUse;
    public Image ImgFullTime;
    public GameObject FoodPanel;
    [Header("Đơn vị S")]
    public int ExpiredTime = 0; // thời gian hết hạn sử dụng thức ăn
    private float _GetTime;
    private FoodSO FoodSO;
    private int _ExpiredTimetmp ; // thời gian hết hạn sử dụng thức ăn

    void Start()
    {
        _ExpiredTimetmp = ExpiredTime;
        IsUse = true;
        _GetTime = 0;
    }
    public void useItemFood()
    {
        if (!InventoryUpdate.Instance.IsHaveFood())
        {
            TextTemplate.Instance.SetText(TagScript.notFood);
            return;
        }
        if (IsUse)
        {
            InventoryUpdate.Instance.RemoveItem(SlotFoodSO);
            FoodPanel.gameObject.SetActive(true);
            InvokeRepeating(nameof(setTimeUse), 0, 0.5f);
            IsUse = false;
        }
       
       
    }
    public void setTimeUse()
    {
        FoodSO = (FoodSO)SlotFoodSO.getItemSO();
        ExpiredTime--;
        Player.Instance.PlayerEffect.UpdateMp(FoodSO.MP);
        Player.Instance.PlayerEffect.UpdateHp(FoodSO.HP);
        TxtFirstTime.text = (ExpiredTime / 60).ToString()+":";
        TxtSecondTime.text = (ExpiredTime -  ((ExpiredTime / 60) * 60)).ToString();
        if (ExpiredTime <= 0)
        {
            IsUse = true;
            ExpiredTime = _ExpiredTimetmp;
            CancelInvoke(nameof(setTimeUse));
            FoodPanel.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyUp(KeyCode.T))
        {
            useItemFood();
        }
        if (!IsUse)
        {
            ImgFullTime.fillAmount = (Time.time - _GetTime) / (ExpiredTime);
        }
    }
}
