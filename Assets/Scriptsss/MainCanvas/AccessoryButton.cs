using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class AccessoryButton : MonoBehaviour
    {
        [SerializeField] GameObject panelDisguise;
        [SerializeField] GameObject panelAccessory;
        [SerializeField] DisguiseButton disguiseButton;
        [SerializeField] float startTarget;
        [SerializeField] float endTarget;
        [SerializeField] RectTransform thisRectTransform=>GetComponent <RectTransform>();

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
        public void Start()
        {
            ListenerMethod();
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
            panelAccessory.SetActive(true);
            panelDisguise.SetActive(false);
            Move(endTarget);
            disguiseButton.Move(startTarget);
        }
        public void Move(float posTarget)
        {
            thisRectTransform.DOAnchorPosX(posTarget, 0.2f);
        }
    }
}
