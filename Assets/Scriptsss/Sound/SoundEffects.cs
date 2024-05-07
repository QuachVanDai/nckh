using UnityEngine;
namespace QuachDai.NinjaSchool.Sound
{
    public class SoundEffects : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] SoundSlider soundSlider;
        private void Start()
        {
            GetSaveSoundEffects();
        } 
        private void OnDisable()
        {
            SaveSoundEffects();
        }

        void SaveSoundEffects()
        {
            Debug.Log(":: SaveSound");
            PlayerPrefs.SetFloat(TagScript.volumeSound, soundSlider.GetValueSlider());
        }
        void GetSaveSoundEffects()
        {
            Debug.Log(":: GetSound");
            audioSource.volume = PlayerPrefs.GetFloat(TagScript.volumeSound);
        }
    }
}
