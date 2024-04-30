using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.UI;
public class SoundSlider : MonoBehaviour
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
    [SerializeField] AudioSource AudioSource => SoundSystem.Instance.soundAudioSource;
    private void Volume(float _values)
    {
        AudioSource.volume = _values;

    }
    void SaveDataSound()
    {
        Debug.Log("GetSound");

        PlayerPrefs.SetFloat(TagScript.volumeSound, ThisSlider.value);
    }
    void GetDataSound()
    {

        Debug.Log("GetSound");

        AudioSource.volume = PlayerPrefs.GetFloat(TagScript.volumeSound);
        slider.value = PlayerPrefs.GetFloat(TagScript.volumeSound);
    }
}
