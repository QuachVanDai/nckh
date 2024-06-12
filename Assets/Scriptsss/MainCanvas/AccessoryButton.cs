using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class AccessoryButton : MonoBehaviour
    {
        [SerializeField] RectTransform panelSlot;
        [SerializeField] GameObject panelDisguise;
        [SerializeField] GameObject panelAccessory;
        [SerializeField] DisguiseButton disguiseButton;
        [SerializeField] float startTarget;
        [SerializeField] float endTarget;
        [SerializeField] RectTransform thisRectTransform=>GetComponent <RectTransform>();
        [SerializeField] Tween tween;

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
            if(tween != null) tween.Kill();
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        public void ListenerMethod()
        {
            panelSlot.anchoredPosition = new Vector3(0, -182, 0);
            panelAccessory.SetActive(true);
            panelDisguise.SetActive(false);
            Move(endTarget);
            disguiseButton.Move(startTarget);
        }
        public void Move(float posTarget)
        {
            tween = thisRectTransform.DOAnchorPosX(posTarget, 0.2f);
        }
    }
}
