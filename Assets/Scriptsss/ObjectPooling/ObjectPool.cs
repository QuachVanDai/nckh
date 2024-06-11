using System;
using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.ObjectPooling
{
    [Serializable]
    public class StartupPool
    {
        public KeyOjectPool keyOjectPool;
        public int size;
        public GameObject prefab;
        public Holder holder;
    }
    public class ObjectPool : Singleton<ObjectPool>
    {
        public StartupPool[] startupPools;

        Dictionary<KeyOjectPool, List<GameObject>> pooledObjects = new Dictionary<KeyOjectPool, List<GameObject>>();

        private GameObject objectClone;
        List<GameObject> objectsList = new List<GameObject>();

        public override void Awake()
        {
            base.Awake();
            foreach (var _startupPools in startupPools)
            {
                objectsList = new List<GameObject>();
                for (int i = 0; i < _startupPools.size; i++)
                {
                    objectClone = Instantiate(_startupPools.prefab);
                    objectClone.SetActive(false);
                    objectsList.Add(objectClone);
                    objectClone.transform.SetParent(_startupPools.holder.GetTranform());
                    //  objectList.Add(objectClone);
                }
                pooledObjects.Add(_startupPools.keyOjectPool, objectsList);
            }
        }
        public List<GameObject> GetObjectList(KeyOjectPool _key)
        {
            foreach (var _pooledObjects in pooledObjects)
                if (_pooledObjects.Key == _key)
                    return _pooledObjects.Value;
            return null;
        }
    }
}
public enum KeyOjectPool
{
    none = 1,
    Snow = 2,
    BulletIce = 3,
    BulletFire = 4,
    BulletWind = 5,
    BulletBossFire = 6,
    Leaf = 6
}