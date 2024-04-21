using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;
using UnityEngine.EventSystems;
public class UseMp : MonoBehaviour, IPointerClickHandler
{
    public Slot slotFoodSO;
    private MpSO mpSO;
    public int quanitity = 0;
    public Text quanitityText;
    public bool isUes;
    public Image imageFull;
    private float getTime;
    Player player => Player.Instance;
    InventoryUpdate inventoryUpdate => InventoryUpdate.Instance;
    void Start()
    {
        quanitity = inventoryUpdate.UpdateMP(0);
        quanitityText.text = quanitity.ToString();
        isUes = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItemMp();
        Debug.Log("using item Mp");
    }
    public void UseItemMp()
    {
        if (isUes)
            StartCoroutine(SetTimeUse());
        else
            TextTemplate.Instance.SetText(TagScript.hoiChieu);
    }
    public IEnumerator SetTimeUse()
    {
        if (player.GetHp() == player.GetMaxHp())
        {
            TextTemplate.Instance.SetText(TagScript.fullHP);
            yield return new WaitForSeconds(0.5f);
        }
        else if (quanitity > 0)
        {
            mpSO = (MpSO)slotFoodSO.getItemSO();
            isUes = false;
            player.SetHp(1f * mpSO.mP);
            //quanitity = inventoryUpdate.UpdateHP(-1);
            quanitityText.text = quanitity.ToString();
            getTime = Time.time;
            imageFull.fillAmount = 0;
            while (imageFull.fillAmount < 1)
            {
                imageFull.fillAmount = (Time.time - getTime) / 0.5f;
                yield return null;
            }
        }
        else
            TextTemplate.Instance.SetText(TagScript.notMp);
        isUes = true;

    }
    // Update is called once per frame
    void Update()
    {
       // quanitity = inventoryUpdate.UpdateMP(0);
      //  quanitityText.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.T))
            UseItemMp();
    }


}
