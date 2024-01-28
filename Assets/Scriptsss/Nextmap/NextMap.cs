
using UnityEngine;

public class NextMap : MonoBehaviour
{
    private int _index;
    public CAMERAMOVE Camera;
    public GameObject LoadAnnimation;
    public GameObject[] quanitityMap;
    public void setIndexEndMap(int number)
    {
        Camera.setEndTranForm(number);
        this.LoadAnnimation.SetActive(true);
        LoadAnimation.Instance.getLoadmap();
        Invoke(nameof(callMap), 2.2f);
    }
    public void setIndexTopMap(int number)
    {
        Camera.setTopTranForm(number);
        this.LoadAnnimation.SetActive(true);
        LoadAnimation.Instance.getLoadmap();
        Invoke(nameof(callMap), 2.2f);

    }
    public void callMap()
    {
        Camera.flat = true;
        for(int i=0; i<quanitityMap.Length; i++)
        {
            quanitityMap[i].SetActive(false);
        }
        quanitityMap[Camera.index].SetActive(true);
        Camera.playerObject.GetComponent<Rigidbody2D>().gravityScale = 1.09f;
        LoadAnimation.Instance.number = 0;
        this.LoadAnnimation.SetActive(false);

    }
}
