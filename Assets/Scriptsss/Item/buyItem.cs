using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Slot == null || Slot.getItemSO()==null) return;
        Cost = Slot.getItemSO().Cost;
        if (Player.Instance.Gold<100) return;
        if (Slot.getItemSO().ItemName == "HP" && SumMoney>= Cost)
        {
            InventoryUpdate.Instance.UpdateHP(Slot, 1);
            Player.Instance.Gold -= Cost;
        }
        else if (Slot.getItemSO().ItemName == "MP" && SumMoney >= Cost)
        {
            InventoryUpdate.Instance.UpdateMP(Slot, 1);
            Player.Instance.Gold -= Cost;
        }
        else if( SumMoney >= Cost)
        {
            InventoryUpdate.Instance.AddItem(Slot);
            Player.Instance.Gold -= Cost;
        }
        SumMoney = Player.Instance.Gold;
        InventoryUpdate.Instance.UpdateGold(SumMoney);
    }
}
