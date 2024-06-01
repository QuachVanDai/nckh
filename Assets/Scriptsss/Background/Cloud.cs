using DG.Tweening;
using UnityEngine;

namespace QuachDai.NinjaSchool.BackGround
{
    public class Cloud : MonoBehaviour
    {
        private void Start()
        {
            tweenCloudMove = transform.DOMoveX(transform.position.x - 6, 12f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        public Tween tweenCloudMove;

        private void OnDisable()
        {
            tweenCloudMove.Kill();
        }
    }

}
