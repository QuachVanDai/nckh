using UnityEngine;
namespace QuachDai.NinjaSchool.Spawn
{
    public class Spawner : Singleton<Spawner>
    {
        public Transform Spawn(Transform prefabs, Vector3 v3, Quaternion rotation, Holder holder)
        {
            Transform newPrefab = Instantiate(prefabs, v3, rotation);
            newPrefab.transform.parent = holder.GetTranform();
            return newPrefab;
        }
    }
}
