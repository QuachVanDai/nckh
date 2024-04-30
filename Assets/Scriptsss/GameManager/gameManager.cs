using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isPlayGame;
    public string scenes;
    private void Start()
    {
        isPlayGame = true;
        SceneManager.LoadScene(scenes, LoadSceneMode.Additive);
    }

    public void OnEnable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);

    }
    public void OnDisable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
        Physics2D.IgnoreLayerCollision(8, 8, false);
    }
}
