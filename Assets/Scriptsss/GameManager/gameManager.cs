using UnityEngine;

public class gameManager : NCKHMonoBehaviour
{
    private static gameManager instance;
    public static  gameManager Instance { get { return instance; } }

    [SerializeField]
    private bool isPlayGame;
    public bool IsPlaygame {  get { return isPlayGame; } set { isPlayGame = value; } }
    protected override void Awake()
    {
        base.Awake();
        if (gameManager.instance != null) Debug.LogError("Only 1 gameManager allow to exist");
        gameManager.instance = this;
        isPlayGame = true;
    }

}
