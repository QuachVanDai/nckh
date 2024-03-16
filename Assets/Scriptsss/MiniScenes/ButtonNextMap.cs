using UnityEngine;
using UnityEngine.SceneManagement;
using QuachDai.NinjaSchool.Character;

public class ButtonNextMap : MonoBehaviour
{
    public MiniSceneData ScreenActive;
    public MiniSceneData ScreenDisActive;
    public GameObject PanelLoadMap;
 
    public void OnClick(int i)
    {
        this.PanelLoadMap.SetActive(true);
        LoadAnimation.Instance.getLoadmap();
        Invoke(nameof(CallMap), 2.2f);
    }
 
    public void CallMap()
    {
        if (SceneManager.GetSceneByName(ScreenDisActive.Scene.name).isLoaded)
            SceneManager.UnloadSceneAsync(ScreenDisActive.Scene.name);
            SceneManager.LoadScene(ScreenActive.Scene.name, LoadSceneMode.Additive);
        this.PanelLoadMap.SetActive(false);
        Player.Instance.transform.position = ScreenActive.PosPlayer[0];
    }
}