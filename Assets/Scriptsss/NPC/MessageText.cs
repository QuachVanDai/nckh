using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    [SerializeField] Text messageText;
    public void SetMessageText(string _message)
    {
        messageText.text = _message;
    }
    public void SetActive(bool _values)
    {
        transform.gameObject.SetActive(_values);
    }
    public void ShowMessage()
    {
        SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one/10,0.3f);
    }
    public void HideMessage()
    {
        SetActive(false);
        transform.localScale = Vector3.zero;
    }
}
