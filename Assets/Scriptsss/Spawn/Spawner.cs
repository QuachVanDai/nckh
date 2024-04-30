using UnityEngine;
namespace QuachDai.NinjaSchool.Spawn
{
    public class Spawner : Singleton<Spawner>
    {
        Transform newPrefab;
        public Transform Spawn(Transform _prefabs, Vector3 _position, Quaternion _rotation, Holder _holder)
        {
            newPrefab = Instantiate(_prefabs, _position, _rotation);
            if (_holder != null)
                newPrefab.transform.parent = _holder.GetTranform();
            return newPrefab;
        }
    }
}
