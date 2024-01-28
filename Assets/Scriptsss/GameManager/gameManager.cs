using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static  GameManager Instance { get { return instance; } }

    [SerializeField]
    private bool isPlayGame;
    public bool IsPlaygame {  get { return isPlayGame; } set { isPlayGame = value; } }
    protected  void Awake()
    {
        if (GameManager.instance != null) Debug.LogError("Only 1 gameManager allow to exist");
        GameManager.instance = this;
        isPlayGame = true;
    }

}
