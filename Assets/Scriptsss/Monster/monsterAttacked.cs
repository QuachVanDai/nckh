using System.Collections;
using UnityEngine;

public class MonsterAttacked : MonoBehaviour
{

    [SerializeField] private Transform _PosSelected;
    [SerializeField] private Transform _PosEffect;

    public PlayerAttack PlayerAttack;
    public MonsterController2D _MonsterController2D;
    public JunkSO JunkSO;
    public Monster MonCurrent;
    public MonsterEffect MonEffect;
    private void Reset()
    {
        _MonsterController2D = GetComponent<MonsterController2D>();
        MonCurrent = GetComponent<Monster>();
        MonEffect = GetComponent<MonsterEffect>();
        _PosSelected = transform.Find("Selected");
        _PosEffect = transform.Find("Ani_Attacked");
        GameObject player = GameObject.FindWithTag("player");
        PlayerAttack = player.GetComponent<PlayerAttack>();
    }
  
  
    public void Update()
    {
        if (PlayerAttack.MonsterAttacted == this) 
        { 
            _PosSelected.gameObject.SetActive(true);
        }
        else 
        {
            _PosSelected.gameObject.SetActive(false);
        }
    }
   
    private void OnMouseDown()
    {
        PlayerAttack.FindMonster(this);
        MonEffect.UpdateHp(MonCurrent.CurrHp, MonCurrent.MaxHp,MonCurrent.Name, MonCurrent.Level);
    }
    public void Attacked(int damage)
    {
        MonCurrent.CurrHp -= damage;
        StartCoroutine(EffectAcctacked());
        MonEffect.TexTGui( damage*(-1), Color.red);
        if (MonCurrent.CurrHp < 0)
        {
            MonEffect.UpdateHp(MonCurrent.CurrHp, MonCurrent.MaxHp, MonCurrent.Name, MonCurrent.Level);
            if (this.PlayerAttack.MissionUi._mission.getMonster())
            {
                if (this.PlayerAttack.MissionUi._mission.getMonster().ID == MonCurrent.ID)
                {
                    this.PlayerAttack.MissionUi.aa90();
                }
            }
                // ItemDropSpawner.Instance.Drop(junkSO.dropRateList, transform.position, Quaternion.identity);

                // i.Die(transform.position,Quaternion.identity);
                SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
            _MonsterController2D.PlayAnimation(monsterStatus.death);
            Destroy(gameObject,0.5f);
            return;
        }
        MonEffect.UpdateHp(MonCurrent.CurrHp, MonCurrent.MaxHp, MonCurrent.Name, MonCurrent.Level);
    }

    public IEnumerator EffectAcctacked()
    {
        _PosEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _PosEffect.gameObject.SetActive(false);
    }
}
