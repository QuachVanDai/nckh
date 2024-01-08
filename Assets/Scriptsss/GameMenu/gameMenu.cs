
using UnityEngine;

public class gameMenu : MonoBehaviour
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
