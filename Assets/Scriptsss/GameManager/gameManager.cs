using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Scenes;
using QuachDai.NinjaSchool.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField]bool isPlayGame;
    public bool IsPlayGame
    {
        get
        {
            return isPlayGame;
        }
        set
        {
            isPlayGame = value;
        }
    }
    public MiniSceneData sceneDefault;
    public MiniSceneData sceneCurrent;
    public MiniSceneData[] miniSceneDatas;
    public AudioClip music;

    private void Start()
    {
        isPlayGame = true;
        LoadSceneActive();
    }
    string nameScene;
    void LoadSceneActive()
    {
        nameScene = PlayerPrefs.GetString(TagScript.sceneCurrent);
        for(int i = 0; i < miniSceneDatas.Length; i++)
        {
            if (miniSceneDatas[i].sceneName == nameScene)
            {
                sceneCurrent.SetMiniSceneData(miniSceneDatas[i]);
                break;
            }
        }
        if (sceneCurrent.Id == MiniSceneId.None)
            sceneCurrent.SetMiniSceneData(sceneDefault);
        music = sceneCurrent.music;
        SceneManager.LoadScene(sceneCurrent.sceneName, LoadSceneMode.Additive);
        SoundSystem.Instance.PlaySound(music);
        Player.Instance.SetPosition(sceneCurrent.posPlayerFinal);
    }
    void OnApplicationQuit()
    {
        Player.Instance.SaveDataPlayer();
        PlayerPrefs.Save();
    }
    public void OnEnable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Physics2D.IgnoreLayerCollision(7, 11, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);

    }
    public void OnDisable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
        Physics2D.IgnoreLayerCollision(7, 11, false);
        Physics2D.IgnoreLayerCollision(8, 8, false);
    }
}
// Vector3(-19.4025517,-1.70443642,0)
// Vector3(-11.5521994,-6.70442104,0)
//Vector3(-60,-6.70442104,0)
// Vector3(-7.21193647,1.29710376,0)
// Vector3(16.8611641,3.29555106,0)