using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Scenes;
using QuachDai.NinjaSchool.Sound;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    bool isPlayGame;
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
    public AudioClip music;

    private void Start()
    {
        isPlayGame = true;
        LoadSceneActive();
    }
    void LoadSceneActive()
    {
        if(sceneCurrent.Id == MiniSceneId.None)
            SetMiniSceneData(sceneDefault);
        music = sceneCurrent.music;
        SceneManager.LoadScene(sceneCurrent.sceneName, LoadSceneMode.Additive);
        SoundSystem.Instance.PlaySound(music);
        Player.Instance.SetPosition(sceneCurrent.posPlayerFinal);
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
    public void SetMiniSceneData(MiniSceneData _miniSceneData)
    {
        sceneCurrent.Id = _miniSceneData.Id;
        sceneCurrent.sceneName = _miniSceneData.sceneName;
        sceneCurrent.scene = _miniSceneData.scene;
        sceneCurrent.yMax = _miniSceneData.yMax;
        sceneCurrent.yMin = _miniSceneData.yMin;
        sceneCurrent.xMin = _miniSceneData.xMin;
        sceneCurrent.xMax = _miniSceneData.xMax;
        sceneCurrent.music = _miniSceneData.music;
        sceneCurrent.posPlayerFinal = _miniSceneData.posPlayerFinal;
        sceneCurrent.PosPlayer = _miniSceneData.PosPlayer;
    }
}
// Vector3(-19.4025517,-1.70443642,0)
// Vector3(-11.5521994,-6.70442104,0)
//Vector3(-60,-6.70442104,0)
// Vector3(-7.21193647,1.29710376,0)
// Vector3(16.8611641,3.29555106,0)