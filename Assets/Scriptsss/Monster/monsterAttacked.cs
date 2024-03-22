using QuachDai.NinjaSchool.Character;
using System.Collections;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterAttacked : MonoBehaviour
    {

        [SerializeField] private Transform posSelected;
        [SerializeField] private Transform posEffect;

        public PlayerAttack playerAttack;
        public MonsterController2D monsterController2D;
        public JunkSO JunkSO;
        public Monster monCurrent;
        public MonsterEffect monEffect;
        private void Start()
        {
            GameObject player = GameObject.FindWithTag("player");
            playerAttack = FindAnyObjectByType<PlayerAttack>();
        }

       /* public void Update()
        {
            if (playerAttack.monsterAttacted == this)
            {
                posSelected.gameObject.SetActive(true);
            }
            else
            {
                posSelected.gameObject.SetActive(false);
            }
        }*/

        private void OnMouseDown()
        {
            playerAttack.FindMonster(monCurrent);
            monEffect.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
        }
        public void Attacked(int damage)
        {
            monCurrent.currHp -= damage;
            StartCoroutine(EffectAcctacked());
            monEffect.TexTGui(damage * (-1), Color.red);
            if (monCurrent.currHp < 0)
            {
                monEffect.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
                if (this.playerAttack.missionUi._mission.getMonster())
                {
                    if (this.playerAttack.missionUi._mission.getMonster().ID == monCurrent.ID)
                    {
                        this.playerAttack.missionUi.GiaoNhiemVu();
                    }
                }
                //ItemDropSpawner.Instance.Drop(JunkSO.dropRateList, transform.position, Quaternion.identity);

                // i.Die(transform.position,Quaternion.identity);
                SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                monsterController2D.PlayAnimation(monsterStatus.death);
                Destroy(gameObject, 0.5f);
                return;
            }
            monEffect.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
        }

        public IEnumerator EffectAcctacked()
        {
            posEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            posEffect.gameObject.SetActive(false);
        }
    }
}
