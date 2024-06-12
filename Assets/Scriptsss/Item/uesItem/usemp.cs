using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using QuachDai.NinjaSchool.Character;
using UnityEngine.EventSystems;
using QuachDai.NinjaSchool.Sound;
public class UseMp : MonoBehaviour, IPointerClickHandler
{
    public Slot slotFoodSO;
    private MpSO mpSO;
    public Text quanitityText;
    public bool isUes;
    public Image imageFull;
    private float getTime;
    Player player => Player.Instance;
    InventoryUpdate inventoryUpdate => InventoryUpdate.Instance;
    SoundSystem soundSystem => SoundSystem.Instance;
    ClipSystem clipSystem => ClipSystem.Instance;
    public int quanitity;

    void Start()
    {
        quanitity = inventoryUpdate.UpdateMP(0);
        quanitityText.text = quanitity.ToString();
        isUes = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.IsPlayGame == false) return;
        UseItemMp();
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
        if (player.GetMp() == player.GetMaxMp())
        {
            TextTemplate.Instance.SetText(TagScript.fullMP);
            yield return new WaitForSeconds(0.5f);
        }
        else if (quanitity > 0)
        {
            soundSystem.PlayOneShotSound(clipSystem.useHpMpClip);
            mpSO = (MpSO)slotFoodSO.getItemSO();
            isUes = false;
            player.SetMp(1f * mpSO.mP);
            inventoryUpdate.UpdateMP(-1);
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
        if (Input.GetKeyUp(KeyCode.T))
            UseItemMp();
    }


}
