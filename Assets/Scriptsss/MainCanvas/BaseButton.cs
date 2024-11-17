using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] Button ThisButton => GetComponent<Button>();
    AudioClip clip => ClipSystem.Instance.buttonClip;

    private void OnEnable()
    {
        ThisButton.onClick.AddListener(ListenerMethod);

    }
    private void OnDisable()
    {
        ThisButton.onClick.RemoveListener(ListenerMethod);
    }

    protected virtual void ListenerMethod()
    {
       // SoundSystem.Instance.PlayOneShotSound(clip);
    }
}
