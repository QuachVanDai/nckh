
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    [SerializeField] private List<Slot> SlotItems = new List<Slot>(15);
    [SerializeField] private GameObject[] SlotsGameObject;
    public  void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < SlotsGameObject.Length; i++)
        {
            try
            {
                SlotsGameObject[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                SlotsGameObject[i].transform.GetChild(1).GetComponent<Image>().sprite = SlotItems[i].getItemSO().Icon;
                if (SlotItems[i].getItemSO().IsStackable)
                {
                    SlotsGameObject[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = SlotItems[i].getQuantity().ToString();
                }
                else
                {
                    SlotsGameObject[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                SlotsGameObject[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                SlotsGameObject[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                SlotsGameObject[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "";
            }
        }
    }

    public GameObject[] getSlotGameObject() { return SlotsGameObject; }
    public List<Slot> getSlotItems() { return SlotItems; }
    public void setSlotItem(Slot slot,int i) {  SlotItems[i]=slot; }
}
