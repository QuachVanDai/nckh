using DG.Tweening;
using UnityEngine;
namespace QuachDai.NinjaSchool.Animations
{
    public class BlackBird : MonoBehaviour
    {
        [SerializeField] private Vector3 posEnd;
        [SerializeField] private Vector3 posStart;
        [SerializeField] private Vector3 vectorScale;
        private float timeDelay;
        void Start()
        {
            Fly();
        }
        private void FixedUpdate()
        {

        }
        void Fly()
        {
            Flip();
            timeDelay = Random.Range(0.5f, 1.5f);
            transform.DOLocalMove(posEnd, 3f).SetEase(Ease.Linear).SetDelay(timeDelay).OnComplete(() =>
            {
                Flip();
                transform.DOLocalMove(posStart, 3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Fly();
                }).SetDelay(timeDelay);
            });
        }
        void Flip()
        {
            vectorScale.x *= -1;
            transform.localScale = vectorScale;
        }
    }
}
