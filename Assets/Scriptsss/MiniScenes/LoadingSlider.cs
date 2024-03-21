
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingSlider : Singleton<LoadingSlider>
    {
        [SerializeField] Slider loadingSlider;
        [SerializeField] Text progressText;
        public void SetProgress(float _value)
        {
            loadingSlider.value = _value;
            progressText.text = (Mathf.Clamp01(_value) * 100).ToString("N0") + "%";
        }
    }
}
