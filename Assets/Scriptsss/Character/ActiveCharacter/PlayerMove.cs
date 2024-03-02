
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Character")]
    [Space]
    public float RunSpeed = 0f;
    public bool FacingRight = true;
    private Rigidbody2D Rigidbody2D;
    [SerializeField]  private float _MoveInput = 0f;
    [SerializeField]  private float  _JumpInput=0f;
    [Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float _JumpForce;
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public bool IsJump;
    private void Update()
    {
        //if (GameManager.Instance.IsPlaygame == false) return;

        _MoveInput = PlayerController2D.Instance.getInputHorizontal();
        _JumpInput = PlayerController2D.Instance.getInputVertical();

        if (!PlayerController2D.Instance.IsGround() && _JumpInput == 0|| Rigidbody2D.velocity.y<0 )
        {
            PlayerController2D.Instance.Animator.SetBool("IsIdleToDown", true);
        }
        Move(RunSpeed*_MoveInput);
        if (PlayerController2D.Instance.IsGround())
        {
            PlayerController2D.Instance.Animator.SetBool("IsIdleToJump", false);
            PlayerController2D.Instance.Animator.SetBool("IsIdleToDown", false);
            if(_JumpInput > 0)
            {
                if(IsJump) 
                    StartCoroutine(nameof(Jump));
            }
            PlayerController2D.Instance.Animator.SetFloat("Speed", Mathf.Abs(_MoveInput));
        }
        PlayerController2D.Instance.Animator.SetFloat("Jumping", Rigidbody2D.velocity.y);
    }
    public IEnumerator Jump()
    {
        IsJump = false;
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _JumpForce);
        PlayerController2D.Instance.Animator.SetBool("IsIdleToJump", true);
        yield return new WaitForSeconds(0.6f);
        IsJump = true;
    }
    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity,ref velocity, _MovementSmoothing);
        //Rigidbody2D.velocity = new Vector2(move, Rigidbody2D.velocity.y);
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
