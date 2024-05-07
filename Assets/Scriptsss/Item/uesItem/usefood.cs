using QuachDai.NinjaSchool.Character;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Item
{
    public class UseFood : MonoBehaviour, IPointerClickHandler
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
        Player player => Player.Instance;


        void Start()
        {
            expiredTime = maxExpiredTime;
            isUse = true;
            getTime = 0;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (GameManager.Instance.IsPlayGame == false) return;
            UseItemFood();
            Debug.Log("using item Food");
        }
        public void UseItemFood()
        {
            if (!InventoryUpdate.Instance.IsHaveFood())
            {
                TextTemplate.Instance.SetText(TagScript.notFood);
                return;
            }

            if (isUse )
            {
                InventoryUpdate.Instance.RemoveItem(slotFoodSO);
                foodPanel.gameObject.SetActive(true);
                StartCoroutine(SetTimeUse());
                isUse = false;
            }
        }
        public IEnumerator SetTimeUse()
        {
            foodSO = (FoodSO)slotFoodSO.getItemSO();
            expiredTime = maxExpiredTime;
            imgFullTime.fillAmount = 0;
            getTime = Time.time;
            while (expiredTime >= 0)
            {
                timeUseText.text = (expiredTime / 60).ToString() + ":";
                timeUseText.text += (expiredTime - ((expiredTime / 60) * 60)).ToString();
                imgFullTime.fillAmount = (Time.time - getTime) / (expiredTime);
                if (GameManager.Instance.IsPlayGame == true)
                {
                    player.SetMp(foodSO.MP);
                    player.SetHp(foodSO.HP);
                }
                expiredTime--;
                yield return new WaitForSeconds(1f);
            }
            isUse = true;
            foodPanel.gameObject.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
                UseItemFood();
        }
    }
}
