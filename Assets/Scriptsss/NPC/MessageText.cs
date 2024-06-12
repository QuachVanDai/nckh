using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] Tween tween;
    public void SetMessageText(string _message)
    {
        messageText.text = _message;
    }
  
    
    public void ShowMessage()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        tween = transform.DOScale(Vector3.one/10,0.3f);
    }
    public void HideMessage()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.zero;
    }
    private void OnDisable()
    {
        if (tween != null)
        {
            Debug.Log(transform.name);
            tween.Kill();
        }
    }
}
