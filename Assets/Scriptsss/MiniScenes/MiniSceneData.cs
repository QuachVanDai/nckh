using UnityEngine;
namespace QuachDai.NinjaSchool.Scenes
{
    [CreateAssetMenu(fileName = "MiniScene", menuName = "ScriptableObjects/MiniSceneData")]
    public class MiniSceneData : ScriptableObject
    {
        public MiniSceneId Id;
        public string sceneName;
        public Object scene;
        public Vector3[] PosPlayer;
        public float yMax;
        public float yMin;
        public float xMax;
        public float xMin;
        public AudioClip music;
        public Vector3 posPlayerFinal;
        public void SetMiniSceneData(MiniSceneData _miniSceneData)
        {
           Id = _miniSceneData.Id;
           sceneName = _miniSceneData.sceneName;
           scene = _miniSceneData.scene;
           yMax = _miniSceneData.yMax;
           yMin = _miniSceneData.yMin;
           xMin = _miniSceneData.xMin;
           xMax = _miniSceneData.xMax;
           music = _miniSceneData.music;
           posPlayerFinal = _miniSceneData.posPlayerFinal;
           PosPlayer = _miniSceneData.PosPlayer;
        }
    }

    public enum MiniSceneId
    {
        None = 0,
        School = 1,
        TempleA = 2,
        IceMountain = 3,
        LegendaryVillage = 4,
        MysteriousCave = 5,
    }
}
/*IceMountainMiniSceneData
Vector3(-13, -2, 0)
    Vector3(14, -5, 0)*/
/* LegendaryVillageMiniSceneData
Vector3(34, 3, 0)
    Vector3(-10, 3, 0)*/
/*MysteriousCaveMiniSceneData
Vector3(-10, 5, 0)
    Vector3(19, 5, 0)*/
/*SchoolMiniSceneData
Vector3(-10, 5, 0)
    Vector3(-65, 1, 0)*/
/* TempleAMiniSceneData
PosPlayer[0] = Vector3(13,6,0)
PosPlayer[1] = Vector3(-60,-5,0)*/

/*IceMountainMiniSceneData
public float yMax = 4.3f;
public float yMin = -1.7f;
public float xMax = 3.3f;
public float xMin = -3.3f;
*/
/* LegendaryVillageMiniSceneData
public float yMax = 1.2f;
public float yMin = -3.9f;
public float xMax = 24.7f;
public float xMin = 0f;
 */
/*MysteriousCaveMiniSceneData
public float yMax = 3.3f;
public float yMin = -23.6f;
public float xMax = 9.7f;
public float xMin = -1.6f;
*/
/*SchoolMiniSceneData
public float yMax = 6f;
public float yMin = -2.5f;
public float xMax = -19.2f;
public float xMin = -54.3f;
*/
/* TempleAMiniSceneData
public float yMax = 1.8f;
public float yMin = -4.8f;
public float xMax = 3.8f;
public float xMin = -50f;
*/