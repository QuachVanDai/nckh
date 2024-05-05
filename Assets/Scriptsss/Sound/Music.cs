using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Sound
{
    public class MusicSlider : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] SoundSlider soundSlider;
        private void Start()
        {
            GetSaveMusic();
        }
        private void OnDisable()
        {
            SaveMusic();
        }
        void SaveMusic()
        {
            Debug.Log(":: SaveMusic");
            PlayerPrefs.SetFloat(TagScript.volumeMusic, soundSlider.GetValueSlider());
        }
        void GetSaveMusic()
        {
            Debug.Log(":: GetMusic");
            audioSource.volume = PlayerPrefs.GetFloat(TagScript.volumeMusic);
        }
    }
}
