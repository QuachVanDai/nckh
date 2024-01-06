
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Character")]
    [Space]
    //[Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    public float RunSpeed = 0f;
    public bool FacingRight = true;
    private Rigidbody2D Rigidbody2D;
    private float _moveInput = 0f;
    private float  _jumpInput=0f;

    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (gameManager.Instance.IsPlaygame == false) return;

        _moveInput = PlayerController2D.Instance.getInputHorizontal();
        _jumpInput = PlayerController2D.Instance.getInputVertical();

        if (!PlayerController2D.Instance.isGround() && _jumpInput == 0)
        {
            PlayerController2D.Instance.Animator.SetBool("IsIdleToDown", true);
        }
        Move(RunSpeed*_moveInput);
        if (PlayerController2D.Instance.isGround())
        {
            PlayerController2D.Instance.Animator.SetBool("IsIdleToJump", false);
            PlayerController2D.Instance.Animator.SetBool("IsIdleToDown", false);

            if (_jumpInput > 0 && Rigidbody2D.velocity.y == 0)
            {
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _jumpForce);
                PlayerController2D.Instance.Animator.SetBool("IsIdleToJump", true);
                PlayerController2D.Instance.Animator.SetBool("IsIdleToDown", true);
            }
            PlayerController2D.Instance.Animator.SetFloat("Speed", Mathf.Abs(_moveInput));

        }
        PlayerController2D.Instance.Animator.SetFloat("Jumping", Rigidbody2D.velocity.y);
    }

    public void Move(float move)
    {
        Rigidbody2D.velocity = new Vector2(move, Rigidbody2D.velocity.y);
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }

    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
