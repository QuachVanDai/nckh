
using UnityEngine;
using DG.Tweening;

public class AnimationNPC :MonoBehaviour
{
    public GameObject head, body;
    public float target_position, time;
    [SerializeField] Tween tweenHead;
    [SerializeField] Tween tweenBody;

    private void OnDisable()
    {
        tweenHead.Kill();
        tweenBody.Kill();
    }
    // Start is called before the first frame update
    void Start()
    {
        tweenHead =  head.transform.DOMoveY(head.transform.position.y + target_position, time).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        tweenBody = body.transform.DOMoveY(body.transform.position.y + target_position, time).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
