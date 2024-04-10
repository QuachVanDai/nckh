
using QuachDai.NinjaSchool.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterAttack : MonoBehaviour
    {
        private const float radiusAttack = 4f;
        [SerializeField] private LayerMask target;
        public Monster monCurrent;
        ObjectPool objectPool => ObjectPool.Instance;
        [SerializeField] KeyOjectPool keyPool;
        [SerializeField] List<GameObject> objectsList;
        [SerializeField] bool isShooting = true;
        private void Start()
        {
            objectsList = new List<GameObject>();
            objectsList = objectPool.GetObjectList(keyPool);
        }
        private void Update()
        {
            FindPlayer();
        }
        [SerializeField] BulletMove bullet;
        void Shoot()
        {
            foreach (GameObject obj in objectsList)
            {
                if (!obj.gameObject.activeSelf)
                {
                    bullet = obj.GetComponent<BulletMove>();
                    bullet.SetPosition(this.transform.position);
                    bullet.Damage = monCurrent.GetDamage();
                    bullet.SetActive(true);
                    break;
                }
            }
            StartCoroutine(_Shoot());
            IEnumerator _Shoot()
            {
                isShooting = false;
                yield return new WaitForSeconds(1.8f);
                bullet = null;
                isShooting = true;
            }
        }

        RaycastHit2D[] hits;
        public void FindPlayer()
        {
            hits = Physics2D.CircleCastAll(transform.position, radiusAttack, Vector2.zero, 0.0f, target);
            foreach (RaycastHit2D hit in hits)
            {
                // Kiểm tra xem đối tượng va chạm có phải là quái vật hay không
                if (hit.collider.CompareTag("player"))
                {
                    if (isShooting && monCurrent.currHp < monCurrent.maxHp) 
                    Shoot();
                    //  if (monWeapons == null && )
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
