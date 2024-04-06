using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberTxt:MonoBehaviour
{
    public Text text;
    public void TextMove(RectTransform parent, int number, Vector3 start, float target, float time, Color color)
    {

        text.rectTransform.SetParent(parent.transform,false);
      //  text.transform.localScale = transformScale.localScale;
        text.gameObject.SetActive(true);
        text.text = number.ToString();
        text.rectTransform.anchoredPosition = start;
        text.color = color;
        var t = text.rectTransform.DOAnchorPosY(text.rectTransform.localPosition.y + target, time)
        .OnComplete(() => Destroy(text.gameObject));
    }
}
