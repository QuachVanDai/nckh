
using UnityEngine;
public enum monsterStatus { idle, move, attack, death }
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterController2D : MonoBehaviour
    {

        public monsterStatus monStatus;
        [SerializeField] private Animator animator;
        [Range(1, 3)]
        [SerializeField] private float monSpeed = 1;
        [SerializeField] private bool facingRight = true;
         Vector3[] point;
         int currentWaypointIndex = 0;
        private void Reset()
        {
            monStatus = monsterStatus.idle;
            animator = GetComponent<Animator>();

        }
        private void Start()
        {
            point = new Vector3[3];
            point[0] = transform.position;
            point[0].x = transform.position.x + 1;
            point[1] = transform.position;
            point[1].x = transform.position.x - 1;
        }
        public void MonterMove()
        {

            if (Vector2.Distance(point[currentWaypointIndex], transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= 2)
                {
                    currentWaypointIndex = 0;

                }
                Flip();
            }
            transform.position = Vector2.MoveTowards(transform.position, point[currentWaypointIndex], Time.deltaTime * monSpeed);
        }
        public void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
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
                    MonterMove();
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
