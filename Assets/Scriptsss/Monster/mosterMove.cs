
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MosterMove : MonoBehaviour
{
    [SerializeField] private MonsterController2D monsterController2D;
    private float getTime;
    private float heSO;
    private void Reset()
    {
        monsterController2D = GetComponent<MonsterController2D>();
        heSO = 2;
    }
    private void Start()
    {
        getTime = Time.time;
    }
        private void Update()
        {
            if (gameObject == null)
            {
                return;
            }
            if (Time.time - getTime <= heSO)
            {
                monsterController2D.PlayAnimation(monsterStatus.idle);
            }
            else
            {
                monsterController2D.PlayAnimation(monsterStatus.move);
                if (Time.time - getTime > heSO * 3)
                {
                    getTime = Time.time;
                    heSO = Random.Range(2, 4);
                }
            }
        }
    }
   
}
