using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class CheckButton : MonoBehaviour
    {
        Button button;
        [SerializeField] KeyShowOpion keyShowOpion;
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
            GetActive(isOption);
        }

        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        Player player => Player.Instance;
        private void ListenerMethod()
        {
            if (isOption)
            {
                PlayerPrefs.SetInt(keyShowOpion.ToString(), 0);
                checkMark.sprite = offOpion;
                isOption = !isOption;
                GetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt(keyShowOpion.ToString(), 1);
                checkMark.sprite = onOpion;
                isOption = !isOption;
                GetActive(true);
            }
        }
        void GetActive(bool _value)
        {
            if (keyShowOpion == KeyShowOpion.ShowHalo)
                player.SetActiveHalo(_value);
            else if (keyShowOpion == KeyShowOpion.ShowLogo)
                player.SetActiveLoGo(_value);
            else if (keyShowOpion == KeyShowOpion.ShowPet)
                player.SetActivePet(_value);
            else if (keyShowOpion == KeyShowOpion.ShowShadow)
                player.SetActiveShadow(_value);
        }
    }
}
public enum KeyShowOpion
{
    None = 0,
    ShowHalo = 1,
    ShowLogo = 2,
    ShowPet = 3,
    ShowShadow = 4,
}
