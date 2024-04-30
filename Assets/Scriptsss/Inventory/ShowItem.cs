using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowItem : Select
{
    [SerializeField]
    private Text inforItemText;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ShowInforItem();
    }
    public void ShowInforItem()
    {
        try
        {
            inforItemText.text = this.GetSlotItem().getItemSO().itemName + "\n";
            inforItemText.text += this.GetSlotItem().getItemSO().Description + "\n";

        }
        catch 
        {
            inforItemText.text = "Chọn vật phẩm";
        }
  
    }
}
