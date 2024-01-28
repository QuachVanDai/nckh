
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public void quitGame()
    {
        Game.Quit();
    }
    public void continueGame()
    {
        Game.Continue();
    }
 
}
