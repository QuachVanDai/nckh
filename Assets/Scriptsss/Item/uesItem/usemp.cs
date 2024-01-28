using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class usemp: MonoBehaviour
{
    // Start is called before the first frame update
    public MpSO mpSO;
    public int quanitity = 0;
    public TextMeshProUGUI txt_quanitity;
    public bool flat;
    public Image Fill_time;
    private float getTime;
    public InventoryUpdate inventoryUpdate;
 
    void Start()
    {
     //   inventory = FindObjectOfType<inventoryManager>();
      //  quanitity = inventoryUpdate.updateMP(0);
        txt_quanitity.text = quanitity.ToString();
        flat = true;
    }
    public void useItemmp()
    {
        if(flat) { StartCoroutine(setTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator setTimeUse()
    {
        if(quanitity>0)
        {
            getTime = Time.time;
            flat = false;
            if (Player.Instance.CurrMp == Player.Instance.MaxMp)
            {
                TextTemplate.Instance.SetText(TagScript.fullMP);
                yield return null;
                flat = true;
            }
            else
            {
                Player.Instance.PlayerEffect.UpdateMp(mpSO.MP);
                quanitity = inventoryUpdate.updateMP(-1);
                txt_quanitity.text = quanitity.ToString();
                yield return new WaitForSeconds(0.5f);
                flat = true;
            }
        }
        else
        {
            TextTemplate.Instance.SetText(TagScript.notMp);
        }

    }
    // Update is called once per frame
    void Update()
    {
        quanitity = inventoryUpdate.updateMP(0);
        txt_quanitity.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.R))
        {
            useItemmp();
        }
        if(!flat)
        {
            Fill_time.fillAmount = (Time.time - getTime) / 0.5f;
        }
    }
}
