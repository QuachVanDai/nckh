using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class SelectFashionButton : MonoBehaviour
    {
        [SerializeField]
        SelectFashionButton[] selectFashionButtons;
        [SerializeField] Image framSelect;
        [SerializeField] bool isOption;
        [SerializeField] DisguiseSO disguiseSO;
        [SerializeField] UseDisguiseButton useDisguise;
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
        private void Start()
        {
            isOption = false;
        }
        private void OnEnable()
        {
            Debug.Log("On");
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            framSelect.gameObject.SetActive(false);
            isOption = false;
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        private void ListenerMethod()
        {
            isOption = !isOption;
            framSelect.gameObject.SetActive(isOption);
            if(isOption )
                 useDisguise.SetDisguise(disguiseSO);
            else useDisguise.SetDisguise(null);
            foreach (var button in selectFashionButtons)
            {
                button.DisActive();
            }
        }

        public void DisActive()
        {
            framSelect.gameObject.SetActive(false);
            isOption = false;
        }
    }
}