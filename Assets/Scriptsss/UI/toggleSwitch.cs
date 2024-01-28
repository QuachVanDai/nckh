
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public GameObject[] hiddenObject;
    public void Switch()
    {
        if(!GameManager.Instance.IsPlaygame) { return; }
        for(int i = 0; i < hiddenObject.Length; i++)
        {
            hiddenObject[i].SetActive(false);
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
