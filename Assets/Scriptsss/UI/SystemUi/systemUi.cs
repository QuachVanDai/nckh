using TMPro;
using UnityEngine;

public class SystemUi : MonoBehaviour
{
    private static SystemUi _Instance;

    public TextMeshProUGUI InfoMonster;
    public static SystemUi Instance { get => _Instance; }
    protected void Awake()
    {
        SystemUi._Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InfoMonster.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
