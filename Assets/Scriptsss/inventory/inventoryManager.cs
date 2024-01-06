
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventoryManager : NCKHMonoBehaviour
{
    
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private slotClass[] items ;
    [SerializeField] private slotClass[] startingItems;
    [SerializeField] private TextMeshProUGUI txtShowInfor;
    private GameObject[] slots;
    public GameObject itemCursor;


    protected override void Awake()
    {
        base.Awake();
    }
    public virtual void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];

        items = new slotClass[slots.Length];
        for (int i = 0; i < items.Length; i++)
            items[i] = new slotClass();

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
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = items[i].getItemSO().icon;
                if (items[i].getItemSO().isStackable)
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
    public slotClass GetClosestSLot()
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
    public slotClass[] getstartingItems() { return startingItems; }
    public slotClass[] getItems() { return items; }

   public void settxtShowInfor(string text)
    {
        txtShowInfor.text = text;
    }

}
