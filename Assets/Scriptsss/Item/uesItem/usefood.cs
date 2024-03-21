using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;

public class usefood: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slot slotFoodSO;
    [SerializeField] Text timeUseText;
    [SerializeField] bool isUse;
    [SerializeField] Image imgFullTime;
    [SerializeField] GameObject foodPanel;
    [Header("Đơn vị S")]
    [SerializeField] int maxExpiredTime = 0; // thời gian hết hạn sử dụng thức ăn
    int expiredTime; // thời gian hết hạn sử dụng thức ăn
    float getTime;
    FoodSO foodSO;
   

    void Start()
    {
        expiredTime = maxExpiredTime;
        isUse = true;
        getTime = 0;
    }
    public void useItemFood()
    {
        if (!InventoryUpdate.Instance.IsHaveFood())
        {
            TextTemplate.Instance.SetText(TagScript.notFood);
            return;
        }
        if (isUse)
        {
            InventoryUpdate.Instance.RemoveItem(slotFoodSO);
            foodPanel.gameObject.SetActive(true);
            InvokeRepeating(nameof(setTimeUse), 0, 0.5f);
            isUse = false;
        }
       
       
    }
    public void setTimeUse()
    {
        foodSO = (FoodSO)slotFoodSO.getItemSO();
        expiredTime--;
        Player.Instance.PlayerEffect.UpdateMp(foodSO.MP);
        Player.Instance.PlayerEffect.UpdateHp(foodSO.HP);
        timeUseText.text = (expiredTime / 60).ToString()+":";
        timeUseText.text += (expiredTime -  ((expiredTime / 60) * 60)).ToString();
        if (expiredTime <= 0)
        {
            isUse = true;
            maxExpiredTime = expiredTime;
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
        }
        if (!isUse)
        {
            imgFullTime.fillAmount = (Time.time - getTime) / (expiredTime);
        }
    }
}
