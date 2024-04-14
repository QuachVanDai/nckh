
using DG.Tweening;
using System.Collections;
using System.Drawing;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterMove : MonoBehaviour
    {
        [SerializeField] private MonsterController2D monsterController2D;
        [SerializeField] private bool facingRight = true;
        [Range(1f, 3f)]
        private float timeMove = 1;
        Vector3[] point;
        int currentWaypointIndex = 0;

        private void Start()
        {
            timeMove = Random.Range(2f, 5f);
            point = new Vector3[3];
            point[0].x = transform.position.x + 1;
            point[1].x = transform.position.x - 1;
            Invoke("MonterMove", 1f);
        }
        public void MonterMove()
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= 2)
                currentWaypointIndex = 0;
            Flip();
            point[0].y = transform.position.y;
            point[1].y = transform.position.y;
            transform.DOMove(point[currentWaypointIndex], timeMove).OnComplete(() =>
            {
                monsterController2D.PlayAnimation(monsterStatus.idle);
                StartCoroutine(_MonterMove());
            });
            IEnumerator _MonterMove()
            {
                yield return new WaitForSeconds(Random.Range(1f, 2f));
                monsterController2D.PlayAnimation(monsterStatus.move);
            }
        }
        Vector3 theScale;
        public void Flip()
        {
            facingRight = !facingRight;
            theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
