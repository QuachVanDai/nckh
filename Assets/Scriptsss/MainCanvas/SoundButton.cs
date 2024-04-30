using QuachDai.NinjaSchool.MainCanvas;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Sound
{
    public class SoundButton : MonoBehaviour
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
        AudioClip clip=>ClipSystem.Instance.buttonClip;
        private void ListenerMethod()
        {
            SoundSystem.Instance.PlayOneShotSound(clip);
        }
    }
}
