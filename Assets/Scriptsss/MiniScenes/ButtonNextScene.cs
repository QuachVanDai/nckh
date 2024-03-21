using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using QuachDai.NinjaSchool.Character;
namespace QuachDai.NinjaSchool.Scenes
{
    public class ButtonNextScene : MonoBehaviour
    {
        public MiniSceneData screenActive;
        public MiniSceneData screenDisActive;
        public GameObject loadScenePanel;
        const float  fakeLoadTime=1;
        float currentFakeLoadTime;
        float progess = 0;
        int index;
        public void OnClick(int i)
        {
            index = i;
            Application.targetFrameRate = 60;
            Debug.Log("click");
           StartCoroutine( CallMap());
        }

        public IEnumerator CallMap()
        {
            this.loadScenePanel.SetActive(true);
            progess = 0;
            currentFakeLoadTime = fakeLoadTime;
            while (progess <= 1)
            {
                currentFakeLoadTime -= Time.deltaTime;
                progess = 1 - (currentFakeLoadTime / fakeLoadTime);
                LoadingSlider.Instance.SetProgress(progess);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            if (SceneManager.GetSceneByName(screenDisActive.Scene.name).isLoaded)
                SceneManager.UnloadSceneAsync(screenDisActive.Scene.name);
            SceneManager.LoadScene(screenActive.Scene.name, LoadSceneMode.Additive);
            this.loadScenePanel.SetActive(false);
           // Player.Instance.transform.position = screenActive.PosPlayer[index];
        }
    }
}