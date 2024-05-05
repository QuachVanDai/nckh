using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Scenes;
using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class BackSchoolButton : MonoBehaviour
    {
        Button button;
        [SerializeField]
        Button ThisButton
        {
            get
            {
                if (button == null)
                    button = GetComponent<Button>();
                return button;
            }
        }
        private void OnEnable()
        {
            ThisButton.onClick.AddListener(ListenerMethod);
        }

        private void OnDisable()
        {
            ThisButton.onClick.RemoveListener(ListenerMethod);
        }
        private void ListenerMethod()
        {
            Application.targetFrameRate = 60;
            LoadingPanel.Instance.SetActive(true);
            LoadingPanel.Instance.StartCoroutine(LoadingPanel.Instance.LoadingPopUp(LoadScene, 1f));
        }
        public MiniSceneData sceneActive;
        public MiniSceneData sceneDisActive;
        public void LoadScene()
        {
            sceneActive = GameManager.Instance.sceneDefault;
            sceneDisActive = GameManager.Instance.sceneCurrent;
            if (SceneManager.GetSceneByName(sceneDisActive.sceneName).isLoaded)
                SceneManager.UnloadSceneAsync(sceneDisActive.sceneName);

            SceneManager.LoadScene(sceneActive.sceneName, LoadSceneMode.Additive);
            Player.Instance.SetPosition(sceneActive.posPlayerFinal);
            SoundSystem.Instance.PlaySound(sceneActive.music);
            GameManager.Instance.IsPlayGame = true;

        }
    }
}
