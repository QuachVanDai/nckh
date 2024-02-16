
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    [SerializeField] private GameObject SlotsHolder;
    [SerializeField] private List<SlotClass> Items ;
    [SerializeField] private TextMeshProUGUI TxtShowInfor;
    private GameObject[] slots;
    public GameObject itemCursor;
    public  void Start()
    {
        slots = new GameObject[SlotsHolder.transform.childCount];
        for (int i = 0; i < SlotsHolder.transform.childCount; i++)
        {
            slots[i] = SlotsHolder.transform.GetChild(i).gameObject;
        }
      //  RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = Items[i].getItemSO().Icon;
                if (Items[i].getItemSO().IsStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = Items[i].getQuantity().ToString();
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
                return Items[i];
            }
        }
        return null;
    }
    public GameObject[] getSlots() { return slots; }
    public List<SlotClass> getItems() { return Items; }

   public void settxtShowInfor(string text)
    {
        TxtShowInfor.text = text;
    }

}
