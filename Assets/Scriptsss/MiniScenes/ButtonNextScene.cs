using UnityEngine;
using UnityEngine.SceneManagement;
using QuachDai.NinjaSchool.Character;
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
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(LoadScene));
        }

        public void LoadScene()
        {
            if (SceneManager.GetSceneByName(sceneDisActive.scene.name).isLoaded)
                SceneManager.UnloadSceneAsync(sceneDisActive.scene.name);

            SceneManager.LoadScene(sceneActive.scene.name, LoadSceneMode.Additive);
            Player.Instance.SetPositon(sceneActive.PosPlayer[index]);
        }
    }
}