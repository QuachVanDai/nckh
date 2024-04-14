using QuachDai.NinjaSchool.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private bool isPlayGame;
    public bool IsPlaygame {  get { return isPlayGame; } set { isPlayGame = value; } }
    public ButtonNextScene buttonNextScene;
    public string scenes;
    public GameObject ingameDebug;
    private void Start()
    {
        SceneManager.LoadScene(scenes, LoadSceneMode.Additive);
      //  ingameDebug = buttonNextScene.LoadScene();
    }

}
