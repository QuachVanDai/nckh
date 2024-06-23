using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    // Start is called before the first frame update
   public void DeleteAll()
    {
        Debug.Log("DeleteAll");
        PlayerPrefs.DeleteAll();
    }
}
/*
 * public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        string[] filePaths = {
            Path.Combine(Application.persistentDataPath, "PlayerLife.json"),
            Path.Combine(Application.persistentDataPath, "Mission.json"),
            Path.Combine(Application.persistentDataPath, "SkinManager.json"),
            Path.Combine(Application.persistentDataPath, "BackPackManager.json"),
            Path.Combine(Application.persistentDataPath, "ClotherManager.json"),
            Path.Combine(Application.persistentDataPath, "Itemcontroller.json"),
    };

        foreach (string filePath in filePaths)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Xóa tệp JSON
            }
        }
    }
 */