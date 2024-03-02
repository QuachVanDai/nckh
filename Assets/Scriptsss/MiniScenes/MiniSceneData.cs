using UnityEngine;

[CreateAssetMenu(fileName = "MiniScene", menuName = "ScriptableObjects/MiniSceneData")]
public class MiniSceneData : ScriptableObject
{
    public MiniSceneId Id;
    public string SceneName;
    public Object Scene;
    public Vector3[] PosPlayer;
}

public enum MiniSceneId {
    School = 0,
    TempleA = 1,
    IceMountain = 2,
}
/*PosPlayer[0] = new Vector3(-13, -2, 0);
PosPlayer[1] = new Vector3(13, 5, 0);
PosPlayer[2] = new Vector3(-10, 5, 0);
PosPlayer[3] = new Vector3(-61, -6, 0);
PosPlayer[4] = new Vector3(14, -5, 0);
PosPlayer[5] = new Vector3(-65, 1, 0);*/