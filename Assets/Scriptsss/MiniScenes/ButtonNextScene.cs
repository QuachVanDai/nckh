using UnityEngine;
using UnityEngine.SceneManagement;
using QuachDai.NinjaSchool.Character;
namespace QuachDai.NinjaSchool.Scenes
{
    public class ButtonNextScene : MonoBehaviour
    {
        public MiniSceneData screenActive;
        public MiniSceneData screenDisActive;
        int index;
        public void OnClick(int i)
        {
            index = i;
            Application.targetFrameRate = 60;
            LoadingPanel.Instance.SetActive(true);
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(LoadScene));
        }

        public void LoadScene()
        {
            if (SceneManager.GetSceneByName(screenDisActive.scene.name).isLoaded)
                SceneManager.UnloadSceneAsync(screenDisActive.scene.name);
            SceneManager.LoadScene(screenActive.scene.name, LoadSceneMode.Additive);
            Player.Instance.SetPositon(screenActive.PosPlayer[index]);
        }
    }
}