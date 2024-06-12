using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class CheckButton : MonoBehaviour
    {
        Button button;
        public KeyShowOpion keyShowOpion;
        [SerializeField] Image checkMark;
        [SerializeField] Sprite offOpion;
        [SerializeField] Sprite onOpion;
        [SerializeField] bool isOption;
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
            isOption = PlayerPrefs.GetInt(keyShowOpion.ToString()) == 1 ? true : false;
            if (isOption)
                checkMark.sprite = onOpion;
            else
                checkMark.sprite = offOpion;
        }

        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        FashionPlayer FashionPlayer => FashionPlayer.Instance;
        private void ListenerMethod()
        {
            if (isOption)
            {
                PlayerPrefs.SetInt(keyShowOpion.ToString(), 0);
                checkMark.sprite = offOpion;
                isOption = !isOption;
                FashionPlayer.SetActive(keyShowOpion);
            }
            else
            {
                PlayerPrefs.SetInt(keyShowOpion.ToString(), 1);
                checkMark.sprite = onOpion;
                isOption = !isOption;
                FashionPlayer.SetActive(keyShowOpion);
            }
        }

    }
}

