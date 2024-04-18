using UnityEngine;
using UnityEngine.SceneManagement;
namespace QuachDai.NinjaSchool.Scenes
{
    public class LoadingScene : MonoBehaviour
    {
        private void Start()
        {
            Invoke("Loading", 0.2f);
        }
        void Loading()
        {
            LoadingPanel.Instance.SetActive(true);
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(LoadScene, 2f));
        }
        public void LoadScene()
        {
            SceneManager.LoadScene("PlayerScene");
        }
    }
}
