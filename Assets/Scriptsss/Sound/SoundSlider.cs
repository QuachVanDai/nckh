using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Sound
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] AudioSource audioSource;
        private void Start()
        {
            slider.value = audioSource.volume;
        }
        private void OnEnable()
        {
            slider.onValueChanged.AddListener(Volume);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(Volume);
        }
        private void Volume(float _values)
        {
            audioSource.volume = _values;
        }
        public Slider ThisSlider { get { return slider; } }

        public float GetValueSlider()
        {
            return slider.value;
        }
    }
}
