
using UnityEngine;

public class MonsterAttack :MonoBehaviour
{

    [SerializeField] private float _RadiusAttack = 1.0f;
    [SerializeField] private LayerMask _Target;
    [SerializeField] private GameObject _BulletPrefab;

    private MonsterWeapons MonWeapons;
    public MonsterAttacked MonAttacked;
    public Monster MonCurrent;

    private void Reset()
    {
        MonAttacked = GetComponent<MonsterAttacked>();
        MonCurrent = GetComponent<Monster>();
    }
    // Khi nhấn nút bắn (ví dụ nút space)
 
    private void Update()
    {
        FindPlayer();
    }
    void Shoot()
    {
        // Tạo ra một đạn từ prefab
       GameObject g = Instantiate(_BulletPrefab, transform.localPosition, Quaternion.identity);
       MonWeapons = g.GetComponent<MonsterWeapons>();
       MonWeapons.Damage = Random.Range(MonCurrent.SetMonster.getDameMonsterDictionary(MonCurrent.Level).Item1,
           MonCurrent.SetMonster.getDameMonsterDictionary(MonCurrent.Level).Item2);
        CancelInvoke(nameof(Shoot));
    }
    public void FindPlayer()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _RadiusAttack, Vector2.zero, 0.0f, _Target);
        foreach (RaycastHit2D hit in hits)
        {
            // Kiểm tra xem đối tượng va chạm có phải là quái vật hay không
            if (hit.collider.CompareTag("player"))
            {
                if (MonWeapons == null && MonAttacked.MonCurrent.CurrHp < MonAttacked.MonCurrent.MaxHp)
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
        Gizmos.DrawWireSphere(transform.position, _RadiusAttack);
    }
}
