using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Monsters;
using QuachDai.NinjaSchool.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    [SerializeField] float radiusAttack = 4f;
    [SerializeField] private LayerMask target;
    [SerializeField] bool isAttack;
    [SerializeField] Animator animator;
    [SerializeField] Vector3 flipRight;
    [SerializeField] Vector3 flipLeft;

    ObjectPool objectPool => ObjectPool.Instance;
    [SerializeField] KeyOjectPool keyPool;
    [SerializeField] List<GameObject> objectsList;
    [SerializeField] bool isShooting = true;
    Robot Robot => GetComponent<Robot>();
    Player Player => Player.Instance;

    public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
    private void Start()
    {
        objectsList = new List<GameObject>();
        objectsList = objectPool.GetObjectList(keyPool);
    }
    void Update()
    {
        if (!Robot.IsDeath)
            FindPlayer();
    }
    public void Flip()
    {
        if (Player.GetPosition().x > transform.position.x) transform.localScale = flipRight;
        else if (Player.GetPosition().x < transform.position.x) transform.localScale = flipLeft;
    }
    [SerializeField] BulletMove bullet;

    void Shoot()
    {
        IsAttack = true;
        Flip();
        foreach (GameObject obj in objectsList)
        {
            if (!obj.gameObject.activeSelf)
            {
                bullet = obj.GetComponent<BulletMove>();
                bullet.SetPosition(this.transform.position);
                bullet.Damage = Robot.GetDamage();
                bullet.SetActive(true);
                break;
            }
        }
        StartCoroutine(_Shoot());
        IEnumerator _Shoot()
        {
            isShooting = false;
            animator.SetBool("IsAttack", true);
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("IsAttack", false);
            yield return new WaitForSeconds(0.3f);
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
            {
                if (isShooting)
                    Shoot();
                return;
            }
        }
        animator.SetBool("IsAttack", false);
        IsAttack = false;
    }
}
