using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Resident : MonoBehaviour
{
    [SerializeField] float timeMove;
    [SerializeField] Vector3 scale;
    [SerializeField] Vector3[] posTarget;
    [SerializeField] int i;
    [SerializeField] Animator animator;
    private void Start()
    {
        scale = transform.localScale;
        CurrentStatus = StatusResident.Idle;
    }
    StatusResident status;
    public StatusResident CurrentStatus
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
            switch (value)
            {
                case StatusResident.Idle:
                    Idle();
                    break;
                case StatusResident.Move:
                    Flip();
                    Move();
                    break;
                case StatusResident.None:
                    break;
            }
        }
    }
    public void Idle()
    {
        StartCoroutine(_Idle());
        IEnumerator _Idle()
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            CurrentStatus = StatusResident.Move;
        }
    }
    public void Move()
    {
        transform.DOMove(posTarget[i], timeMove).OnComplete(() =>
        {
            animator.SetBool("isSpeed", false);
            CurrentStatus = StatusResident.Idle;
        });
        animator.SetBool("isSpeed", true);
        i++;
        i = i > 1 ? 0 : i;
    }
    public void Flip()
    {
        scale.x *= -1;
        transform.localScale = scale;
    }
}
public enum StatusResident
{
    None = 0,
    Idle = 1,
    Move = 2,
}