using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextTemplate : Singleton<TextTemplate>

{
    public Text textTemplate;
    public bool Flat = true;
    public GameObject panel;
    void Start()
    {
        panel.SetActive(true);
        panel.SetActive(false);
        Flat = true;
    }

    public void SetText(string text)
    {
        if (Flat)
        {
            textTemplate.text = text;
            panel.SetActive(true);
            textTemplate.rectTransform.DOAnchorPosX(210, 0.5f).SetEase(Ease.Linear).
                OnComplete(() =>
                textTemplate.rectTransform.DOAnchorPosX(-220, 0.4f).SetDelay(0.6f).
                OnComplete(() =>
                StartCoroutine(ClosePanel())
                
                ));
            Flat = false;
        }
    }
    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(0.2f);
        Flat = true;
        textTemplate.rectTransform.anchoredPosition = new Vector2(630, 0);
        panel.SetActive(false);
    }
}
