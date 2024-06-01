using UnityEngine;
using DG.Tweening;
using Unity.Collections;
namespace QuachDai.NinjaSchool.Animations
{
    public class Doll : MonoBehaviour
    {
        [SerializeField] private int angle;
        [SerializeField, ReadOnly] private Vector3 newRotation = Vector3.zero;
        [SerializeField] Tween tween;

        void Start()
        {
            DoShaking();
        }
        private void OnDisable()
        {
            tween.Kill();
        }
        void DoShaking()
        {
            newRotation.z = angle;
            tween = transform.DORotate(newRotation, 2).OnComplete(() =>
            {
                angle *= -1;
                DoShaking();
            });
        }
    }
}
