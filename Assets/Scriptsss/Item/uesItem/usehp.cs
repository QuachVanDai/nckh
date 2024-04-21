using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;
using UnityEngine.EventSystems;
public class UseHp : MonoBehaviour, IPointerClickHandler
{
    public Slot slotFoodSO;
    private HpSO hpSO;
    public int quanitity = 0;
    public Text quanitityText;
    public bool isUes;
    public Image imageFull;
    private float getTime;
    Player player => Player.Instance;
    InventoryUpdate inventoryUpdate => InventoryUpdate.Instance;
    void Start()
    {
        quanitity = inventoryUpdate.UpdateHP(0);
        quanitityText.text = quanitity.ToString();
        isUes = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItemHp();
        Debug.Log("using item Hp");
    }
    public void UseItemHp()
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
            hpSO = (HpSO)slotFoodSO.getItemSO();
            isUes = false;
            player.SetHp(1f * hpSO.hP);
            //quanitity = inventoryUpdate.UpdateHP(-1);
            quanitityText.text = quanitity.ToString();
            getTime = Time.time;
            imageFull.fillAmount = 0;
            while (imageFull.fillAmount <1)
            {
                imageFull.fillAmount = (Time.time - getTime) / 0.5f;
                yield return null;
            }
        }
        else
            TextTemplate.Instance.SetText(TagScript.notHp);
        isUes = true;

    }
    // Update is called once per frame
    void Update()
    {
        quanitity = inventoryUpdate.UpdateHP(0);
        quanitityText.text = quanitity.ToString();
        if (Input.GetKeyUp(KeyCode.R))
            UseItemHp();
    }


}
