using UnityEngine;
using DG.Tweening;
using Unity.Collections;
public class Doll : MonoBehaviour
{
    [SerializeField] private int angle;
    [SerializeField,ReadOnly] private Vector3 newRotation=Vector3.zero;
    void Start()
    {
        DoShaking();
    }

    void DoShaking()
    {
        newRotation.z = angle;
        transform.DORotate(newRotation, 2).OnComplete(()=>
        {
            angle *= -1;
            DoShaking();
        });
    }
}
