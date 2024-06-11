using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class DisguiseButton : MonoBehaviour
    {
        [SerializeField] GameObject panelDisguise;
        [SerializeField] GameObject panelAccessory;
        [SerializeField] AccessoryButton accessoryButton;
        [SerializeField] float startTarget;
        [SerializeField] float endTarget;
        [SerializeField] RectTransform thisRectTransform => GetComponent<RectTransform>();
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
            panelDisguise.SetActive(true);
            panelAccessory.SetActive(false);
            Move(endTarget);
            accessoryButton.Move(startTarget);
        }
        public void Move(float posTarget)
        {
            thisRectTransform.DOAnchorPosX(posTarget, 0.2f);
        }
    }
}
