using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class SmallButton : MonoBehaviour
    {
        [SerializeField] GameObject objectActive;
        [SerializeField] GameObjectPanelList gameObjectPanelList;
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
            gameObjectPanelList.Hidden();
            objectActive.SetActive(true);
        }

    }

}
