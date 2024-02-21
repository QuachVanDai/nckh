using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Usemp : MonoBehaviour
{
    public Slot SlotFoodSO;
    private MpSO MpSO;
    public int Quanitity = 0;
    public TextMeshProUGUI TxtQuanitity;
    public bool IsUse;
    public Image ImgFillTime;
    private float getTime;

    void Start()
    {
        Quanitity = InventoryUpdate.Instance.UpdateMP(0);
        TxtQuanitity.text = Quanitity.ToString();
        IsUse = true;
    }
    public void UseItemMp()
    {
        if (IsUse) { StartCoroutine(SetTimeUse()); }
        else { TextTemplate.Instance.SetText(TagScript.hoiChieu); }
    }
    public IEnumerator SetTimeUse()
    {
        if (Player.Instance.CurrMp == Player.Instance.MaxMp)
        {
            TextTemplate.Instance.SetText(TagScript.fullMP);
            yield return new WaitForSeconds(0.5f);
        }
        else if (Quanitity > 0)
        {
            MpSO = (MpSO)SlotFoodSO.getItemSO();
            getTime = Time.time;
            IsUse = false;
            Player.Instance.PlayerEffect.UpdateMp(MpSO.mP);
            Quanitity = InventoryUpdate.Instance.UpdateMP(-1);
            TxtQuanitity.text = Quanitity.ToString();
            yield return new WaitForSeconds(0.5f);
            IsUse = true;
        }
        else { TextTemplate.Instance.SetText(TagScript.notHp); }
    }
    void Update()
    {
        Quanitity = InventoryUpdate.Instance.UpdateMP(0);
        TxtQuanitity.text = Quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.R))
        {
            UseItemMp();
        }
        if (!IsUse)
        {
            ImgFillTime.fillAmount = (Time.time - getTime) / 0.5f;
        }
    }
}
