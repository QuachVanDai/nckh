using DG.Tweening;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 endRotation;
    [SerializeField] private float time = 1f;
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
        tween = transform.DOLocalRotate(endRotation, time).OnComplete(() =>
        {
            transform.DOLocalRotate(startRotation, time).OnComplete(() =>
            {
                DoShaking();
            });
        });
    }
}
