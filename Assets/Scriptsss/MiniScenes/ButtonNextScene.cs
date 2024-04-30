using UnityEngine;
using UnityEngine.SceneManagement;
using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Sound;
namespace QuachDai.NinjaSchool.Scenes
{
    public class ButtonNextScene : MonoBehaviour
    {
        public MiniSceneData sceneActive;
        public MiniSceneData sceneDisActive;
        int index;
        public void OnClick(int i)  // nhấn nut button
        {
            index = i;
            Application.targetFrameRate = 60;
            LoadingPanel.Instance.SetActive(true);
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(LoadScene,1f));
        }
        public AudioClip music => sceneActive.music;
        public void LoadScene()
        {
            if (SceneManager.GetSceneByName(sceneDisActive.sceneName).isLoaded)
                SceneManager.UnloadSceneAsync(sceneDisActive.sceneName);

            SceneManager.LoadScene(sceneActive.sceneName, LoadSceneMode.Additive);
            Player.Instance.SetPositon(sceneActive.PosPlayer[index]);
            SoundSystem.Instance.PlaySound(music);
        }
    }
}