using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowItem : Select
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
            TxtInformation.text = this.GetSlotItem().getItemSO().ItemName + "\n";
            TxtInformation.text += this.GetSlotItem().getItemSO().Description + "\n";

        }
        catch 
        {
            TxtInformation.text = "Chọn vật phẩm";
        }
  
    }
}
