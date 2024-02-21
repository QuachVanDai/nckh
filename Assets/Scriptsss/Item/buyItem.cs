using UnityEngine;
public class BuyItem : MonoBehaviour
{
    public Slot Slot;
    public Player Player;
    public int SumMoney;
    public int Cost;
    private void Start()
    {
        SumMoney = Player.Instance.Gold;
    }
    public void ConfirmBuy()
    {
        if (Slot == null || Slot.getItemSO() == null) return;
        Cost = Slot.getItemSO().Cost;
        if (SumMoney < Cost) { TextTemplate.Instance.SetText(TagScript.notMoney); return;  }
      
        if (Slot.getItemSO().ItemName == "HP" )
        {
            InventoryUpdate.Instance.UpdateHP(Slot, 1);
            Player.Instance.Gold -= Cost;
        }
        else if (Slot.getItemSO().ItemName == "MP")
        {
            InventoryUpdate.Instance.UpdateMP(Slot, 1);
            Player.Instance.Gold -= Cost;
        }
        else 
        {
            InventoryUpdate.Instance.AddItem(Slot);
            Player.Instance.Gold -= Cost;
        }
        SumMoney = Player.Instance.Gold;
        InventoryUpdate.Instance.UpdateGold(SumMoney);
    }
}
