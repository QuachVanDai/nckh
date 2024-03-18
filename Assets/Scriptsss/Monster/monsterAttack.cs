
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterAttack : MonoBehaviour
    {

        private const float radiusAttack = 4f;
        [SerializeField] private LayerMask target;
        [SerializeField] MonsterWeapons monWeapons;
        public MonsterAttacked monAttacked;
        public Monster monCurrent;

        private void Reset()
        {
            monAttacked = GetComponent<MonsterAttacked>();
            monCurrent = GetComponent<Monster>();
        }
        private void Update()
        {
            FindPlayer();
        }
        void Shoot()
        {
            // Tạo ra một đạn từ prefab
            Instantiate(monWeapons, transform.localPosition, Quaternion.identity);
            monWeapons.Damage = Random.Range(monCurrent.SetMonster.getDameMonsterDictionary(monCurrent.level).Item1,
                monCurrent.SetMonster.getDameMonsterDictionary(monCurrent.level).Item2);
            CancelInvoke(nameof(Shoot));
        }
        public void FindPlayer()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radiusAttack, Vector2.zero, 0.0f, target);
            foreach (RaycastHit2D hit in hits)
            {
                // Kiểm tra xem đối tượng va chạm có phải là quái vật hay không
                if (hit.collider.CompareTag("player"))
                {
                    if (monWeapons == null && monAttacked.monCurrent.currHp < monAttacked.monCurrent.maxHp)
                        Invoke(nameof(Shoot), 1.8f);
                    // Debug.Log("Quái vật đã bị phát hiện!");
                }
            }
        }
        void OnDrawGizmos()
        {
            // Đặt màu của gizmo
            Gizmos.color = Color.yellow;

            // Vẽ hình tròn tại vị trí của đối tượng với bán kính được thiết lập
            Gizmos.DrawWireSphere(transform.position, radiusAttack);
        }
    }
}
