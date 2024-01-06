using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class usehp: NCKHMonoBehaviour
{
    // Start is called before the first frame update
    public hpSO hpSO;
    public int quanitity = 0;
    public TextMeshProUGUI txt_quanitity;
    public bool flat;
    public Image Fill_time;
    private float getTime;
    public inventoryUpdate inventoryUpdate;

    void Start()
    {
       // inventory = FindObjectOfType<inventoryManager>();
      //  quanitity = inventoryUpdate.updateHP(0);
        txt_quanitity.text = quanitity.ToString();
        flat = true;
    }
    public void useItemhp()
    {
        if(flat) { StartCoroutine(setTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator setTimeUse()
    {
        if (quanitity > 0)
        {
            getTime = Time.time;
            flat = false;
            if(Player.Instance.Currhp== Player.Instance.HP)
            {
                TextTemplate.Instance.SetText(TagScript.fullHP);
                yield return null;
                flat = true;
            }
            else
            {
                Player.Instance.update_hp(hpSO.hP);
                quanitity = inventoryUpdate.updateHP(-1);
                txt_quanitity.text = quanitity.ToString();
               // inventoryUpdate.RefreshUI();
                yield return new WaitForSeconds(0.5f);
                flat = true;
            }
           
        }
        else { TextTemplate.Instance.SetText(TagScript.notHp); }
    }
    // Update is called once per frame
    void Update()
    {
        quanitity = inventoryUpdate.updateHP(0);
        txt_quanitity.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.E))
        {
            useItemhp();
        }
        if(!flat)
        {
            Fill_time.fillAmount = (Time.time - getTime) / 0.5f;
        }
    }
}
