 
using UnityEngine;

public class toggleSwitch : NCKHMonoBehaviour
{
    public GameObject[] hiddenObject;
    public void Switch()
    {
        if(!gameManager.Instance.IsPlaygame) { return; }
        for(int i = 0; i < hiddenObject.Length; i++)
        {
            hiddenObject[i].SetActive(false);
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
