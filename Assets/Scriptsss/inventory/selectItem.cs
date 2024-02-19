using UnityEngine.EventSystems;
using UnityEngine;
public abstract class SelectItem : MonoBehaviour, IPointerClickHandler
{
    public InventoryManager InventoryManager;
    public Transform HolderSlots;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        SetSelect();
    }
    public void SetSelect()
    {
        foreach (Transform t in HolderSlots)
        {
            if(t.GetChild(0).gameObject.activeSelf ==true)
            t.GetChild(0).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);

    }
    public int  PosItem()
    {
        for (int i = 0; i < InventoryManager.getItems().Count; i++)
        {
            if (gameObject.name == InventoryManager.getSlots()[i].name)
            {
                return i;
            }
        }
        return -1;
    }
}
