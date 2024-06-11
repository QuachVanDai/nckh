using QuachDai.NinjaSchool.Monsters;
using QuachDai.NinjaSchool.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private const float radiusAttack = 5f;
    [SerializeField]  LayerMask target;
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
        if (isShooting && monCurrent.currHp < monCurrent.maxHp)
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
            if (hit.collider.CompareTag("player"))
                Shoot();
        }
    }
}
