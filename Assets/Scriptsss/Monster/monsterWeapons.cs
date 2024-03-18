using QuachDai.NinjaSchool.Character;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterWeapons : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float damage;

        public Player player=>Player.Instance;
        public PlayerAttacked playerAttacked;

        public float Damage { get { return damage; } set { damage = value; } }
        private void FixedUpdate()
        {
            //if (bullet != null) return;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "player")
            {
                playerAttacked.Attacked((int)damage);
            }
        }
    }
}
