
using UnityEngine;

public class MosterMove : MonoBehaviour
{
    [SerializeField] private MonsterController2D _MonsterController2D;
    private float _GetTime;
    private float HeSO;
    private void Reset()
    {
        _MonsterController2D = GetComponent<MonsterController2D>();
        HeSO = 2;
    }
    private void Start()
    {
        _GetTime = Time.time;
    }
    private void Update()
    {
        if (gameObject==null)
        {
            return;
        }
        if (Time.time - _GetTime <= HeSO)
        {
            _MonsterController2D.PlayAnimation(monsterStatus.idle);
        }
        else
        {
            _MonsterController2D.PlayAnimation(monsterStatus.move);
            if (Time.time - _GetTime > HeSO * 3)
            {
                _GetTime = Time.time;
                HeSO = Random.Range(2, 4);
            }

        }
    }
   
}
