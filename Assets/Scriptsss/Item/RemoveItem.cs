
using UnityEngine;

public  class RemoveItem : MonoBehaviour
{
    public int index=-1;
    public void ConfirmRemove()
    {
        InventoryUpdate.Instance.RemoveItem(index);
    }
}
