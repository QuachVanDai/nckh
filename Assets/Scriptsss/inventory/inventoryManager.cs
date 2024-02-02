
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private SlotClass[] items ;
    [SerializeField] private SlotClass[] startingItems;
    [SerializeField] private TextMeshProUGUI txtShowInfor;
    private GameObject[] slots;
    public GameObject itemCursor;
    public virtual void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];

        items = new SlotClass[slots.Length];
        for (int i = 0; i < items.Length; i++)
            items[i] = new SlotClass();

        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = items[i].getItemSO().Icon;
                if (items[i].getItemSO().IsStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = items[i].getQuantity().ToString();
                }
                else
                {
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
            }
        }
    }
    public void setSelect(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        slots[index].transform.GetChild(0).gameObject.SetActive(true);
    }
    public SlotClass GetClosestSLot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 64)
            {
                setSelect(i);
                return items[i];
            }
        }
        return null;
    }
    public GameObject[] getSlots() { return slots; }
    public SlotClass[] getstartingItems() { return startingItems; }
    public SlotClass[] getItems() { return items; }

   public void settxtShowInfor(string text)
    {
        txtShowInfor.text = text;
    }

}
