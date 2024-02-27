using UnityEngine;

[CreateAssetMenu(fileName = "MiniScene", menuName = "ScriptableObjects/MiniSceneData")]
public class MiniSceneData : MonoBehaviour
{
    public MiniSceneId Id;
    public string SceneName;
    public Object Scene;
}

public enum MiniSceneId {
    FromSchoolToIceMountain = 0,
    FromSchoolToTempleA = 1,
    FromIceMountainToSchool = 2,
    FromIceMountainToTempleA = 3,
    FromTempleAToIceMountain = 4,
    FromTempleAToSchool = 5,
}
