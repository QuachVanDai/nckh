using QuachDai.NinjaSchool.Character;
using UnityEngine;
public class MonsterWeapons : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerObject;
    [SerializeField] private float _Speed = 7f;
    [SerializeField] private float _Damage;

    public PlayerAttacked Player;

    public float Damage { get { return _Damage; } set { _Damage = value; } }
    private void Start()
    {
        _PlayerObject = GameObject.FindWithTag("player");
        Player = FindAnyObjectByType<PlayerAttacked>();
    }
    private void FixedUpdate()
    {
        //if (bullet != null) return;
        Vector2 direction = (_PlayerObject.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * _Speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Player.Attacked((int)_Damage);
        }
    }
}
