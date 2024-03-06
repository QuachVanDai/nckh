using DG.Tweening;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 endRotation;
    [SerializeField] private float time = 1f;
    void Start()
    {
        DoShaking();
    }

    void DoShaking()
    {
        transform.DOLocalRotate(endRotation, time).OnComplete(() =>
        {
            transform.DOLocalRotate(startRotation, time).OnComplete(() =>
            {
                DoShaking();
            });
        });
    }
}
