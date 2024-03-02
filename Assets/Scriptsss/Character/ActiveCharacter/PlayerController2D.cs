using Unity.VisualScripting;
using UnityEngine;

public  class PlayerController2D: Singleton<PlayerController2D>
{
    [SerializeField] private Transform _GroundCheck;
    [SerializeField] private LayerMask _GroundLayer;
    [SerializeField]  private Animator _Animator;
  
    public Animator Animator
    {
        get { return this._Animator; }
        set { this._Animator = value; }
    }
    public bool IsGround()
    {
        return  Physics2D.Linecast(transform.position, _GroundCheck.position, _GroundLayer);
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
