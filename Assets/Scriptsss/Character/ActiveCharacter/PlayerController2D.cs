using UnityEngine;

namespace QuachDai.NinjaSchool.Character
{
    public class PlayerController2D : Singleton<PlayerController2D>
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        public bool IsGround()
        {
            return Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        }
        public float getInputHorizontal()
        {
            return Input.GetAxisRaw(TagScript.Horizontal);
        }
        public float getInputVertical()
        {
            return Input.GetAxisRaw(TagScript.Vertical);
        }
        public bool getInputSpace()
        {
            return Input.GetKeyUp(KeyCode.Space);
        }
        public bool getInputE()
        {
            return Input.GetKeyUp(KeyCode.E);
        }
        public bool getInputR()
        {
            return Input.GetKeyUp(KeyCode.R);
        }
    }

}