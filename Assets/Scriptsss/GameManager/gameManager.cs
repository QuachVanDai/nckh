using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private bool isPlayGame;
    public bool IsPlaygame {  get { return isPlayGame; } set { isPlayGame = value; } }

    public string scenes;
    private void Start()
    {
        SceneManager.LoadScene(scenes, LoadSceneMode.Additive);
    }

}
