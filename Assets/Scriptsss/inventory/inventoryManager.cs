
using QuachDai.NinjaSchool.Character;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private List<Slot> SlotItems = new List<Slot>(15);
    [SerializeField] SlotData currSlotData;
    [SerializeField] SlotData firstSlotData;
    [SerializeField]  SlotData loadedData;
    [SerializeField] private GameObject[] SlotsGameObject;

    public Text xuText;
    [SerializeField] bool isLoadData;

    string filePath;
    public void Awake()
    {
        filePath = Application.persistentDataPath + "/data.json";
        if (isLoadData)
            LoadData();
    }
    public void Start()
    {
        RefreshUI();
        SetXuText();
    }
    #region  Save Data
    public void SetData(Slot slot, int i)
    {
        currSlotData.listSlot[i] = new Slot(slot);
        SaveData();
    }
    public void SaveData()
    {
        Debug.Log("Save Data Inventory");
        string data = JsonUtility.ToJson(currSlotData);
        File.WriteAllText(filePath, data);
    }
    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string data;

            if (PlayerPrefs.GetInt(TagScript.firstPlay) == 0)
            {
                Debug.Log("First Data");
                loadedData = firstSlotData;
            }
            else
            {
                data = File.ReadAllText(filePath);
                Debug.Log(data);
                JsonUtility.FromJsonOverwrite(data, loadedData);
            }
           
        }
        for (int i = 0; i < currSlotData.listSlot.Count; i++)
        {
            SlotItems[i] = new Slot(loadedData.listSlot[i]);
            currSlotData.listSlot[i] = new Slot(loadedData.listSlot[i]);
        }
        SaveData();
    }
    #endregion
    public void SetXuText()
    {
        xuText.text = Player.Instance.GetXu().ToString();
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
    public void setSlotItem(Slot slot, int i) { SlotItems[i] = slot; }
}
