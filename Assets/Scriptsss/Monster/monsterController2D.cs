
using UnityEngine;
public enum monsterStatus { idle, move, attack, death }
public class MonsterController2D : MonoBehaviour
{

    public  monsterStatus _Status;
    [SerializeField] private Animator _Animator;
    [Range(1,3)]
    [SerializeField] private float _Speed=1;
    [SerializeField] private bool _FacingRight = true;
    private Vector3[] _Point;
    private int _CurrentWaypointIndex=0;
    private void Reset()
    {
        _Status = monsterStatus.idle;
        _Animator = GetComponent<Animator>();
       
    }
    private void Start()
    {
        _Point = new Vector3[3];
        _Point[0] = transform.position;
        _Point[0].x = transform.position.x + 1;
        _Point[1] = transform.position;
        _Point[1].x = transform.position.x - 1;
    }
    public void MonterMove()
    {
      
        if (Vector2.Distance(_Point[_CurrentWaypointIndex], transform.position) < .1f)
        {
            _CurrentWaypointIndex++;
            if (_CurrentWaypointIndex >= 2)
            {
                _CurrentWaypointIndex = 0;
                
            }
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, _Point[_CurrentWaypointIndex], Time.deltaTime * _Speed);
    }
    public void Flip()
    {
        _FacingRight = !_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void monsterIsDeath()
    {

    }
    public void PlayAnimation(monsterStatus Status)
    {
        if(gameObject==null) return;
       switch (Status)
        {
            case monsterStatus.idle:
                Status = monsterStatus.idle;
                _Animator.SetBool("isMove", false);
                break;
            case monsterStatus.move:
                Status = monsterStatus.move;
                _Animator.SetBool("isMove", true);
                MonterMove();
                break;
            case monsterStatus.attack:
                Status = monsterStatus.attack; 
                break;
            case monsterStatus.death:
                Status = monsterStatus.death;
                _Animator.SetBool("isDeath", true);
                break;
        }
    }
}
