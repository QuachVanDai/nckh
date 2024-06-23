using QuachDai.NinjaSchool.Character;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RobotMove : MonoBehaviour
{
    RobotAttack RobotAttack=>GetComponent<RobotAttack>();
    [SerializeField] float radiusAttack = 4f;
    [SerializeField] private LayerMask target;
    [SerializeField] int speed;
    [SerializeField] Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();
    [SerializeField] Vector3 flipRight;
    [SerializeField] Vector3 flipLeft;
    [SerializeField] bool isFollowPlayer;
    [SerializeField] bool isMove;
    [SerializeField] Animator animator;
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    Player Player => Player.Instance;
    float getTimeCurrent;
    float distance;
    int numberRandom;
    int flat = 1;
    Robot Robot => GetComponent<Robot>();

    void Start()
    {
        isMove = false;
        getTimeCurrent = Time.time;
    }

    void Update()
    {
        if (Robot.IsDeath) return;

            if (!isMove || RobotAttack.IsAttack)
        {
            animator.SetBool("IsMove",false);
            return;
        }
        FindPlayer();
        Move();
    }
    public void Move()
    {
        if (Time.time - getTimeCurrent > 2 && !isFollowPlayer)
        {
            animator.SetBool("IsMove", true);
            numberRandom = Random.Range(0, 99);
            if (numberRandom % 2 == 0)
                SetDirection(true);
            else
                SetDirection(false);
            getTimeCurrent = Time.time;
        }
        Rigidbody2D.velocity = Vector2.right * speed * flat;
        Flip();
    }
    public void Flip()
    {
        if (speed > 0) transform.localScale = flipRight;
        else if (speed < 0) transform.localScale = flipLeft;
    }
    public void SetDirection(bool _values)
    {
        if (_values) speed = System.Math.Abs(speed);
        else speed = System.Math.Abs(speed) * -1;
    }
    void MoveFollowPlayer()
    {
        distance = Vector2.Distance(Player.GetPosition(), transform.position);
        if (distance < 1)
            flat = 0;
        else if (Player.GetPosition().x > transform.position.x)
            SetDirection(true);
        else
            SetDirection(false);
        isFollowPlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderPrLeft")
            speed = System.Math.Abs(speed);
        else if (collision.gameObject.tag == "BorderPrRight")
            speed = System.Math.Abs(speed) * -1;
        flat = 1;
    }
    RaycastHit2D[] hits;
    public void FindPlayer()
    {
        hits = Physics2D.CircleCastAll(transform.position, radiusAttack, Vector2.zero, 0.0f, target);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("player"))
            {
                MoveFollowPlayer();
            }
            return;
        }
        isFollowPlayer = false;
        flat = 1;
    }
}
