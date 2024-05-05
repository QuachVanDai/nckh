using UnityEngine;
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
            musicAudioSource.clip = clip;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }
        public void StopSound()
        {
            soundAudioSource.loop = true;
            soundAudioSource.Stop();
        }
    }
}
