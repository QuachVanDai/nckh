using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    [SerializeField] Text nameNinja;
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;
    [SerializeField] Image fillBarHP;
    [SerializeField] bool isDeath;
    public bool IsDeath { get { return isDeath; } set { isDeath = value; } }

    public SpriteRenderer spriteRobotAttacked;
    private void Start()
    {
        IsDeath = false;
        maxHp = hp;
    }
    public float GetDamage()
    {
        return Random.Range(minDamage,maxDamage);
    }
    public float GetHp()
    {
        return hp;
    }
    public void SetHp(float _hp)
    {
        if (GameManager.Instance.IsPlayGame == false) return;

        this.hp += _hp;
        if (hp > maxHp) hp = maxHp;
        else if (hp <= 0) hp = 0;
        fillBarHP.fillAmount = this.hp / maxHp;
    }

}
