using QuachDai.NinjaSchool.Character;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterWeapons : MonoBehaviour
    {
        [SerializeField]  float speed = 7f;
        [SerializeField] Rigidbody2D rb;
        public Player player=>Player.Instance;

        public float Damage;
        Vector2 direction;
        private void FixedUpdate()
        {
            //if (bullet != null) return;
            direction = (player.GetPosition() - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "player")
            {
                player.playerAttacked.Attacked((int)Damage);
            }
        }
    }
}
