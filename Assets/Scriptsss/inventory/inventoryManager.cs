
using JetBrains.Annotations;
using QuachDai.NinjaSchool.Character;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryManager : MonoBehaviour
{
    [SerializeField] Transform Inventory;
    [SerializeField] List<ItemSlot> itemSlots;
    [SerializeField] SlotData currSlotData;
    [SerializeField] SlotData firstSlotData;
    [SerializeField] SlotData loadedData;
    [SerializeField] Slot[] Slots;

    [SerializeField] Text InforItem;
    private ItemSlot itemClick;

    public Text xuText;

    #region Set Get
    public ItemSlot ItemClick { get { return itemClick; } set { itemClick = value; } }
    public List<ItemSlot> ItemSlots { get { return itemSlots; }}
    #endregion
    #region index 
    int i = 0;
    public int SizeInventory => Inventory.childCount;
    #endregion
    [SerializeField] bool isLoadData;

    string filePath;
    public void Awake()
    {
        filePath = Application.persistentDataPath + "/data.json";
        if (isLoadData)
            LoadData();
    }
    private void OnEnable()
    {
        Init();
        Refresh();
    }
    
    private void Init()
    {
        Slots = new Slot[SizeInventory];
        int i = 0;
        foreach (Transform t in Inventory)
        {
            Slots[i++] = t.GetComponent<Slot>();
        }
    }
    #region  Save Data
    public void SetData(ItemSlot slot, int i)
    {
        currSlotData.listSlot[i] = new ItemSlot(slot);
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
            itemSlots[i] = new ItemSlot(loadedData.listSlot[i]);
            currSlotData.listSlot[i] = new ItemSlot(loadedData.listSlot[i]);
        }
        SaveData();
    }
    #endregion
    public void SetXuText()
    {
        xuText.text = Player.Instance.GetXu().ToString();
    }
    #region UPDATE ITEMS
    public void SetInforItem(ItemSlot _item)
    {
        try
        {
            InforItem.text = _item.GetItemSO().Name + "\n";
            InforItem.text += _item.GetItemSO().Description + "\n";

        }
        catch
        {
            InforItem.text = "Chọn vật phẩm";
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < SizeInventory; i++)
        {
            try
            {
                Slots[i].SetSlot(itemSlots[i]);

            }
            catch
            {
                Slots[i].SetSlot(null);
            }
        }
    }

   
   

    #endregion



    public Slot[] getSlotGameObject() { return Slots; }
    public List<ItemSlot> getSlotItems() { return itemSlots; }
    public void SetSlotItem(ItemSlot slot, int i) { itemSlots[i] = slot; }
}
