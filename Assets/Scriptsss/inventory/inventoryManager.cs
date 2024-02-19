
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    [SerializeField] private List<Slot> Items = new List<Slot>(15);
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private TextMeshProUGUI TxtShowInfor;
    public  void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            try
            {
                Slots[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                Slots[i].transform.GetChild(1).GetComponent<Image>().sprite = Items[i].getItemSO().Icon;
                if (Items[i].getItemSO().IsStackable)
                {
                    Slots[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = Items[i].getQuantity().ToString();
                }
                else
                {
                    Slots[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                Slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                Slots[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                Slots[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "";
            }
        }
    }
  
    public Slot GetClosestSLot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Vector2.Distance(Slots[i].transform.position, Input.mousePosition) <= 64)
            {
                return Items[i];
            }
        }
        return null;
    }
    public GameObject[] getSlots() { return Slots; }
    public List<Slot> getItems() { return Items; }
    public void setItem(Slot slot,int i) {  Items[i]=slot; }
    
   public void settxtShowInfor(string text)
    {
        TxtShowInfor.text = text;
    }

   
}
