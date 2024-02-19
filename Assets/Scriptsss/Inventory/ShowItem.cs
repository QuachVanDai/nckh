using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowItem : SelectItem
{
    [SerializeField]
    private TextMeshProUGUI TxtInformation;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ShowInforItem();
    }
    public void ShowInforItem()
    {
        try
        {
            TxtInformation.text = this.InventoryManager.getItems()[this.PosItem()].getItemSO().ItemName + "\n";
        }
        catch 
        {
            TxtInformation.text = "Chọn vật phẩm";
        }
  
    }
}
