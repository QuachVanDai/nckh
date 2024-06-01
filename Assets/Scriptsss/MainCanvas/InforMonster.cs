using UnityEngine.UI;

public class InforMonster : Singleton<InforMonster>
{
    private void Start()
    {
        SetActive(false);
    }
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
