
using QuachDai.NinjaSchool.Spawn;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterSpawn : MonoBehaviour
    {
        private Transform thisTranform;
        [SerializeField] Holder cloneHolder;
        [SerializeField] float spawnTime = 5;
        [SerializeField] Monster monster;

        Spawner spawner => Spawner.Instance;
        void Start()
        {
            if (thisTranform != null) return;
            monster = monster.GetMonster();
            if (monster == null) return;
            thisTranform = spawner.Spawn(monster.transform, transform.position, Quaternion.identity, cloneHolder);
        }
        private void Update()
        {
            if (thisTranform != null) return;
            InvokeRepeating(nameof(SpawnMonster), spawnTime, 1);
        }
        private void SpawnMonster()
        {
            thisTranform = spawner.Spawn(monster.transform, transform.position, Quaternion.identity, cloneHolder);
            CancelInvoke(nameof(SpawnMonster));
        }
    }
}