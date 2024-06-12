
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public void quitGame()
    {
        Game.Quit();
    }
    public void continueGame()
    {
        if (PlayerPrefs.GetInt(TagScript.firstPlay) == 0) return;
        Game.Continue();
    }
 
}
