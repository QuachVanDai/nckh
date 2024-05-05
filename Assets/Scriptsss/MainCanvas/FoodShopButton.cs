using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class FoodShopButton : MonoBehaviour
    {
        public GameObject foodShop;
        public InventoryManager inventoryManager;
        Button button;
        [SerializeField]
        Button ThisButton
        {
            get
            {
                if (button == null)
                    button = GetComponent<Button>();
                return button;
            }
        }
        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        private void ListenerMethod()
        {
            foodShop.SetActive(true);
            GameManager.Instance.IsPlayGame = false;
            inventoryManager.SetXuText();
        }
    }
}