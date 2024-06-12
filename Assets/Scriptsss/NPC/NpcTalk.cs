using DG.Tweening;
using UnityEngine;

public class NpcTalk : MonoBehaviour
{
    [SerializeField] MessageText messageText;
    [SerializeField] bool isShowMessage=false;
    [SerializeField] Tween tween;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (!isShowMessage)
            {
                messageText.ShowMessage();
                isShowMessage = true;
            }
        }
    }
    private void OnDisable()
    {
        if(tween != null) tween.Kill();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       tween = DOVirtual.DelayedCall(1f, () => 
        { 
            messageText.HideMessage();
            isShowMessage = false;
        });
    }

}
