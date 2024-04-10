using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttacked : MonoBehaviour
    {
        public GameObject AniAttacked;
        public Text[] damagedText;
        private void Start()
        {
            posStartText = damagedText[0].rectTransform.anchoredPosition;

        }
        public void Attacked(int damage)
        {
            TextMove(damage.ToString());
            //StartCoroutine(aniAcctacked());
           /* if (Player.Instance.GetHp() < 0)
            {
                //CharacterController2D.Instance.Animator.SetBool("isDeath",true);
                Destroy(gameObject, 0.5f);
            }*/
            Player.Instance.SetHp(-damage);
        }
        IEnumerator aniAcctacked()
        {
            AniAttacked.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            AniAttacked.SetActive(false);
        }
        public Vector3 posStartText;

        public void TextMove(string _damage)
        {
            for (int i = 0; i < damagedText.Length; i++)
            {
                if (!damagedText[i].gameObject.activeSelf)
                {
                    damagedText[i].text = _damage;
                    damagedText[i].rectTransform.anchoredPosition = posStartText;
                    damagedText[i].gameObject.SetActive(true);
                    var t = damagedText[i].rectTransform.DOAnchorPosY(damagedText[i].rectTransform.localPosition.y + 2.5f, 0.5f)
               .OnComplete(() =>
               {
                   damagedText[i].gameObject.SetActive(false);
               });
                    return;
                }
            }

        }
    }
}
