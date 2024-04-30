using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Sound
{
    public class SoundSystem : Singleton<SoundSystem>
    {
        public AudioSource musicAudioSource;
        public AudioSource soundAudioSource;
        public void PlayOneShotSound(AudioClip clip)
        {
            soundAudioSource.PlayOneShot(clip);
        }
        public void PlayOneShotSound(AudioClip clip, float valueVolume)
        {
            soundAudioSource.PlayOneShot(clip, valueVolume);
        }

        public void PlaySound(AudioClip clip)
        {
            if (clip == null) return;
            soundAudioSource.clip = clip;
            soundAudioSource.loop = true;
            soundAudioSource.Play();
        }
        public void StopSound()
        {
            soundAudioSource.loop = true;
            soundAudioSource.Stop();
        }
    }
}
