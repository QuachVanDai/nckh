using DG.Tweening;
using QuachDai.NinjaSchool.Character;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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

        public Text[] damagedText;
        Player player => Player.Instance;
        private void Start()
        {
            playerAttack = player.playerAttack;
            posStartText = damagedText[0].rectTransform.anchoredPosition;
        }

        public void Update()
        {
            posSelected.gameObject.SetActive(IsSelectMonter());
        }
        public Vector3 posStartText;
        Vector3 monsterScale;
        public void TextMove(string _damage)
        {
            for (int i = 0; i < damagedText.Length; i++)
            {
                if (!damagedText[i].gameObject.activeSelf)
                {
                    damagedText[i].text = _damage;
                    damagedText[i].rectTransform.anchoredPosition = posStartText;
                    monsterScale = monCurrent.gameObject.transform.localScale;
                    damagedText[i].rectTransform.localScale = monsterScale;
                    damagedText[i].gameObject.SetActive(true);
                    var t = damagedText[i].rectTransform.DOAnchorPosY(damagedText[i].rectTransform.localPosition.y + 50, 0.8f)
               .OnComplete(() => 
               { 
                   damagedText[i].gameObject.SetActive(false);
               });
                    return;
                }
            }

        }
        public bool IsSelectMonter()
        {
            return playerAttack.monster == monCurrent;
        }
        private void OnMouseDown()
        {
            playerAttack.FindMonster(monCurrent);
            monCurrent.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
        }
        public void Attacked(int damage)
        {
            monCurrent.currHp -= damage;
            StartCoroutine(EffectAcctacked());
            TextMove(damage.ToString());
            if (monCurrent.currHp < 0)
            {
                monCurrent.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
                /*if (this.playerAttack.missionUi._mission.getMonster())
                {
                    if (this.playerAttack.missionUi._mission.getMonster().ID == monCurrent.ID)
                    {
                        this.playerAttack.missionUi.GiaoNhiemVu();
                    }
                }*/
                //ItemDropSpawner.Instance.Drop(JunkSO.dropRateList, transform.position, Quaternion.identity);

                // i.Die(transform.position,Quaternion.identity);
                SystemUi.Instance.InfoMonster.gameObject.SetActive(false);
                monsterController2D.PlayAnimation(monsterStatus.death);
                Destroy(gameObject, 0.5f);
                return;
            }
            monCurrent.UpdateHp(monCurrent.currHp, monCurrent.maxHp, monCurrent.nameMonster, monCurrent.level);
        }

        public IEnumerator EffectAcctacked()
        {
            posEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            posEffect.gameObject.SetActive(false);
        }
    }
}
