
using QuachDai.NinjaSchool.Scenes;

public static class Game
{
    public static void Continue()
    {
        LoadingScene.Instance.Loading();
    }
    public static void Quit()
    {
        ConfirmPanel.Ask("Are you sure you want to quit game?");
    }
}