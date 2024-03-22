using QuachDai.NinjaSchool.Character;
using UnityEngine;
public class BuyItem : MonoBehaviour
{
    public Slot Slot;
    public int SumMoney;
    public int Cost;
    Player player => Player.Instance;
    private void Start()
    {
        SumMoney = player.GetGold();
    }
    public void ConfirmBuy()
    {
        if (Slot == null || Slot.getItemSO() == null) return;
        if (InventoryUpdate.Instance.IsHaveBox() == false)
        {
            TextTemplate.Instance.SetText(TagScript.fullBox);
            return;
        }
        Cost = Slot.getItemSO().Cost;
        if (SumMoney < Cost) { TextTemplate.Instance.SetText(TagScript.notMoney); return;  }
      
        if (Slot.getItemSO().ItemName == "HP" )
        {
            InventoryUpdate.Instance.UpdateHP(Slot, 1);
            player.SetGold(-Cost);

        }
        else if (Slot.getItemSO().ItemName == "MP")
        {
            InventoryUpdate.Instance.UpdateMP(Slot, 1);
            player.SetGold(-Cost);
        }
        else 
        {
            InventoryUpdate.Instance.AddItem(Slot);
            player.SetGold(-Cost);
        }
        SumMoney = player.GetGold();
    }
}
