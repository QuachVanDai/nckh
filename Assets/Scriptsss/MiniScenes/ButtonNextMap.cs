
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextMap : MonoBehaviour
{
    public string NameScreenActive;
    public string NameScreenDisActive;
    public GameObject PanelLoadMap;
    private Vector3[] PosPlayer;
    private int Index;
    private void Start()
    {
        SetPosPlayer();
    }
    public void OnClick(int i)
    {
        Index = i;
        this.PanelLoadMap.SetActive(true);
        LoadAnimation.Instance.getLoadmap();
        Invoke(nameof(CallMap), 2.2f);
    }
    private void SetPosPlayer()
    {
        PosPlayer = new Vector3[100];
        PosPlayer[0] = new Vector3(-13 ,-2 ,0 );
        PosPlayer[1] = new Vector3(13, 5, 0);
        PosPlayer[2] = new Vector3(-10, 5, 0);
        PosPlayer[3] = new Vector3(-61, -6, 0);
        PosPlayer[4] = new Vector3(14, -5, 0);
        PosPlayer[5] = new Vector3(-65, 1, 0);
    }
    public void CallMap()
    {
        if (SceneManager.GetSceneByName(NameScreenDisActive).isLoaded)
            SceneManager.UnloadSceneAsync(NameScreenDisActive);
            SceneManager.LoadScene(NameScreenActive, LoadSceneMode.Additive);
        this.PanelLoadMap.SetActive(false);
        Player.Instance.transform.position = PosPlayer[Index];
    }
}
public enum IDMap
{
   

}