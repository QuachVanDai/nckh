
using UnityEngine;
public enum monsterStatus { idle, move, attack, death }
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterController2D : MonoBehaviour
    {

        public monsterStatus monStatus;
        [SerializeField] MonsterMove monsterMove;
        [SerializeField] private Animator animator;
        public void monsterIsDeath()
        {

        }
        public void PlayAnimation(monsterStatus Status)
        {
            if (gameObject == null) return;
            switch (Status)
            {
                case monsterStatus.idle:
                    Status = monsterStatus.idle;
                    animator.SetBool("isMove", false);
                    break;
                case monsterStatus.move:
                    Status = monsterStatus.move;
                    animator.SetBool("isMove", true);
                    monsterMove.MonterMove();
                    break;
                case monsterStatus.attack:
                    Status = monsterStatus.attack;
                    break;
                case monsterStatus.death:
                    Status = monsterStatus.death;
                    animator.SetBool("isDeath", true);
                    break;
            }
        }
    }
}
