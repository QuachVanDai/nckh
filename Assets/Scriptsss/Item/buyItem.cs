using QuachDai.NinjaSchool.Character;
using UnityEngine;
public class BuyItem : MonoBehaviour
{
    public Slot Slot;
    public int Cost;
    public InventoryManager InventoryManager;

    Player player => Player.Instance;

    public int SumMoney => player.GetXu();

    public void ConfirmBuy()
    {
        if (Slot == null || Slot.getItemSO() == null)
            return;
        else if (InventoryUpdate.Instance.IsHaveBox() == false)
            TextTemplate.Instance.SetText(TagScript.fullBox);
        else
        {
            Cost = Slot.getItemSO().Cost;
            if (SumMoney < Cost)
            {
                TextTemplate.Instance.SetText(TagScript.notMoney);
                return;
            }
            player.SetXu(-Cost);
            InventoryManager.SetXuText();
            if (Slot.getItemSO().itemName == ItemName.Hp)
                InventoryUpdate.Instance.UpdateHP(Slot, 1);
            else if (Slot.getItemSO().itemName == ItemName.Mp)
                InventoryUpdate.Instance.UpdateMP(Slot, 1);
            else
                InventoryUpdate.Instance.AddItem(Slot);
        }
    }
}
