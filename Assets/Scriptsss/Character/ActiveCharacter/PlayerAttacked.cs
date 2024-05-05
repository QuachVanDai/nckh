using DG.Tweening;
using QuachDai.NinjaSchool.Animations;
using QuachDai.NinjaSchool.MainCanvas;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerAttacked : MonoBehaviour
    {
        [SerializeField] RegenerativePanel regenerativePanel;
        [SerializeField] GameObject animationActacked;
        AnimatorSystem animatorSystem => AnimatorSystem.Instance;
        Player player => Player.Instance;
        public Text[] damagedText;
        private void Start()
        {
            posStartText = damagedText[0].rectTransform.anchoredPosition;
        }
        public void Attacked(int damage)
        {
            TextMove(damage.ToString());
            StartCoroutine(aniAcctacked());
            if (Player.Instance.GetHp() <= 0)
            {
                animatorSystem.SetBool(player.GetAnimator(), "IsDeath", true);
                regenerativePanel.SetActive(true);
                GameManager.Instance.IsPlayGame = false;
            }
            else Player.Instance.SetHp(-damage);
        }
        IEnumerator aniAcctacked()
        {
            animationActacked.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            animationActacked.gameObject.SetActive(false);
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
