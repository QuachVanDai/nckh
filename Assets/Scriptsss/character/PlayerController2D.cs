using UnityEngine;

public  class PlayerController2D:NCKHMonoBehaviour
{
    private static PlayerController2D _instance;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    private Animator _animator;

    public static PlayerController2D Instance { get => _instance; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Awake()
    {
        base.Awake();
        if(PlayerController2D._instance != null) { Debug.LogError("chi cho phep 1 PlayerController2D"); }
        PlayerController2D._instance = this;
    }
    public Animator Animator
    {
        get { return this._animator; }
        set { this._animator = value; }
    }
    public bool isGround()
    {
        return  Physics2D.Linecast(transform.position, _groundCheck.position, _groundLayer);
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
