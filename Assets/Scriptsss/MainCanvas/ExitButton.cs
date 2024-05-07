using QuachDai.NinjaSchool.Character;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class ExitButton : MonoBehaviour
    {
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
            Player.Instance.SaveDataPlayer();
            Debug.Log("Exiting game...");
            Application.Quit();
        }
    }
}
