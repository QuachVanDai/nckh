using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    [CreateAssetMenu(fileName = "MiniScene", menuName = "ScriptableObjects/MiniSceneData")]
    public class MiniSceneData : ScriptableObject
    {
        public MiniSceneId Id;
        public string SceneName;
        public Object Scene;
        public Vector3[] PosPlayer;
    }

    public enum MiniSceneId
    {
        None = 0,
        School = 1,
        TempleA = 2,
        IceMountain = 3,
        LegendaryVillageScene = 4,
        MysteriousCave = 5,
    }
}
/*PosPlayer[0] = new Vector3(-13, -2, 0);
PosPlayer[1] = new Vector3(13, 5, 0);
PosPlayer[2] = new Vector3(-10, 5, 0);
PosPlayer[3] = new Vector3(-61, -6, 0);
PosPlayer[4] = new Vector3(14, -5, 0);
PosPlayer[5] = new Vector3(-65, 1, 0);*/