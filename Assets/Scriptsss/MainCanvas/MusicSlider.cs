using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.UI;
public class MusicSlider : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    Slider ThisSlider
    {
        get
        {
            if (slider == null)
                slider = GetComponent<Slider>();
            return slider;
        }
    }
    private void OnEnable()
    {
        ThisSlider.onValueChanged.AddListener(Volume);
        GetDataSound();
    }

    private void OnDisable()
    {
        ThisSlider.onValueChanged.RemoveListener(Volume);
        SaveDataSound();
    }
    [SerializeField] AudioSource AudioSource=>SoundSystem.Instance.musicAudioSource;
    private void Volume(float _values)
    {
        AudioSource.volume = _values;
    }
    void SaveDataSound()
    {
        Debug.Log("SaveMusic");
        PlayerPrefs.SetFloat(TagScript.volumeMusic, ThisSlider.value);
    }
    void GetDataSound()
    {
        Debug.Log("GetMusic");
        AudioSource.volume = PlayerPrefs.GetFloat(TagScript.volumeMusic);
        slider.value = PlayerPrefs.GetFloat(TagScript.volumeMusic);
    }
}
