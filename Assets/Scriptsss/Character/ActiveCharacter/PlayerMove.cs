
using System.Collections;
using System.ComponentModel;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float runSpeed = 9f;
        [SerializeField] private float jumpForce = 14f;
        [SerializeField] private bool isJump;
        [SerializeField] private float moveInput = 0f;
        [SerializeField] private float jumpInput = 0f;
        [SerializeField] private bool facingRight = true;
        [SerializeField] Rigidbody2D myRigidbidy2D;
        [Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;
        private Vector3 velocity = Vector3.zero;

        private void Update()
        {
            //if (GameManager.Instance.IsPlaygame == false) return;

            moveInput = PlayerController2D.Instance.getInputHorizontal();
            jumpInput = PlayerController2D.Instance.getInputVertical();

            if (!PlayerController2D.Instance.IsGround() && jumpInput == 0 || myRigidbidy2D.velocity.y < 0)
            {
                PlayerController2D.Instance.animator.SetBool("IsIdleToDown", true);
            }
            Move(runSpeed * moveInput);
            if (PlayerController2D.Instance.IsGround())
            {
                PlayerController2D.Instance.animator.SetBool("IsIdleToJump", false);
                PlayerController2D.Instance.animator.SetBool("IsIdleToDown", false);
                if (jumpInput > 0)
                {
                    if (isJump)
                        StartCoroutine(nameof(Jump));
                }
                PlayerController2D.Instance.animator.SetFloat("Speed", Mathf.Abs(moveInput));
            }
            PlayerController2D.Instance.animator.SetFloat("Jumping", myRigidbidy2D.velocity.y);
        }
        public IEnumerator Jump()
        {
            isJump = false;
            myRigidbidy2D.velocity = new Vector2(myRigidbidy2D.velocity.x, jumpForce);
            PlayerController2D.Instance.animator.SetBool("IsIdleToJump", true);
            yield return new WaitForSeconds(0.6f);
            isJump = true;
        }
        public void Move(float move)
        {
            Vector3 targetVelocity = new Vector2(move, myRigidbidy2D.velocity.y);
            myRigidbidy2D.velocity = Vector3.SmoothDamp(myRigidbidy2D.velocity, targetVelocity, ref velocity, movementSmoothing);
            //Rigidbody2D.velocity = new Vector2(move, Rigidbody2D.velocity.y);
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }

        }

        public void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }
}
