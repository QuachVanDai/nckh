
using System.Threading;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private Transform _Tranform;

    [SerializeField] private float _SpawnTime=5;
   [SerializeField] private Transform _MonsterName;

    public GameObject HolderMonster;
    public Monster Monster;


    private void Reset()
    {
        HolderMonster = GameObject.Find("clonedMonster");
        _SpawnTime = 5;
    }
    void Start()
    {
        if (_Tranform != null) return;
        Monster = Monster.GetMonster();
        if (Monster == null) return;
        _Tranform = LstMonster.Instance.spawn(_MonsterName.gameObject.name, transform.position, Quaternion.identity);
        _Tranform.parent = HolderMonster.transform;
        _Tranform.gameObject.SetActive(true);

    }
    private void Update()
    {
        if (_Tranform != null) return;
        InvokeRepeating(nameof(SpawnMonster), _SpawnTime, 1);
    }
    private void SpawnMonster()
    {
        Monster = Monster.GetMonster();
        _Tranform = LstMonster.Instance.spawn(_MonsterName.gameObject.name, transform.position, Quaternion.identity);
        _Tranform.gameObject.SetActive(true);
        _Tranform.parent = HolderMonster.transform;
        CancelInvoke(nameof(SpawnMonster));
    }
}
