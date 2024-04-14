using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;

public class Usehp: MonoBehaviour
{
    public Slot SlotFoodSO;
    private HpSO HpSO;
    public int Quanitity = 0;
    public TextMeshProUGUI TxtQuanitity;
    public bool IsUes;
    public Image ImgFillTime;
    private float _GetTime;
    Player player => Player.Instance;
    void Start()
    {
        Quanitity = InventoryUpdate.Instance.UpdateHP(0);
        TxtQuanitity.text = Quanitity.ToString();
        IsUes = true;
    }
    public void UseItemHp()
    {
        if(IsUes) { StartCoroutine(SetTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator SetTimeUse()
    {
        if (player.GetHp() == player.GetMaxHp())
        {
            TextTemplate.Instance.SetText(TagScript.fullHP);
            yield return new WaitForSeconds(0.5f);
        }
        else if (Quanitity > 0)
        {
            HpSO = (HpSO)SlotFoodSO.getItemSO();
            _GetTime = Time.time;
            IsUes = false;
           // Player.Instance.PlayerEffect.UpdateHp(HpSO.hP);
            Quanitity = InventoryUpdate.Instance.UpdateHP(-1);
            TxtQuanitity.text = Quanitity.ToString();
            yield return new WaitForSeconds(0.5f);
            IsUes = true;
        }
        else { TextTemplate.Instance.SetText(TagScript.notHp); }
    }
    // Update is called once per frame
    void Update()
    {
       Quanitity = InventoryUpdate.Instance.UpdateHP(0);
        TxtQuanitity.text = Quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.E))
        {
            UseItemHp();
        }
        if(!IsUes)
        {
            ImgFillTime.fillAmount = (Time.time - _GetTime) / 0.5f;
        }
    }
}
