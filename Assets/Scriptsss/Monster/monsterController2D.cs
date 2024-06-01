
using DG.Tweening;
using UnityEngine;
public enum Status { idle, move, attack, death }
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterController2D : MonoBehaviour
    {
        public Status monStatus;
        [SerializeField] MonsterMove monsterMove;
        [SerializeField] private Animator animator;
        public Tween tweenMonsterMove;
        public Tween tweenTextMove;
       
        private void OnDisable()
        {
            tweenMonsterMove.Kill();
            tweenTextMove.Kill();
        }
        public void PlayAnimation(Status _status)
        {
            if (gameObject == null) return;
            switch (_status)
            {
                case Status.idle:
                    _status = Status.idle;
                    animator.SetBool("isMove", false);
                    break;
                case Status.move:
                    _status = Status.move;
                    animator.SetBool("isMove", true);
                    monsterMove.MonterMove();
                    break;
                case Status.attack:
                    _status = Status.attack;
                    break;
                case Status.death:
                    tweenMonsterMove.Kill();
                    tweenTextMove.Kill();
                    _status = Status.death;
                    animator.SetBool("isDeath", true);
                    break;
            }
        }
    }
}
