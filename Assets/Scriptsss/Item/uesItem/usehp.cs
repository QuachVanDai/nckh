using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;
using UnityEngine.EventSystems;
using QuachDai.NinjaSchool.Sound;
public class UseHp : MonoBehaviour, IPointerClickHandler
{
    public Slot slotFoodSO;
    private HpSO hpSO;
    public Text quanitityText;
    public bool isUes;
    public Image imageFull;
    private float getTime;
    Player player => Player.Instance;
    SoundSystem soundSystem => SoundSystem.Instance;
    ClipSystem clipSystem => ClipSystem.Instance;
    public int quanitity => inventoryUpdate.UpdateHP(0);

    InventoryUpdate inventoryUpdate => InventoryUpdate.Instance;
    void Start()
    {
        quanitityText.text = quanitity.ToString();
        isUes = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.IsPlayGame == false) return;
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
            soundSystem.PlayOneShotSound(clipSystem.useHpMpClip);
            hpSO = (HpSO)slotFoodSO.getItemSO();
            isUes = false;
            player.SetHp(1f * hpSO.hP);
            inventoryUpdate.UpdateHP(-1);
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
        if (Input.GetKeyUp(KeyCode.R))
            UseItemHp();
    }


}
