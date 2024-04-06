using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemUi : Singleton<SystemUi>
{
    public Text InfoMonster;
    public void SetInfoMonsterText(string text)
    {
        InfoMonster.text = text;
    }
    public void SetActive(bool values)
    {
        gameObject.SetActive(values);   
    }
}
