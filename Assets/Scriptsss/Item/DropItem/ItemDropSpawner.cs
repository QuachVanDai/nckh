using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected  void Awake()
    {
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 itemDropSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        int index = Random.Range(0, dropList.Count  );
        Transform itemDrop = this.spawn(dropList[index].itemSO.name, pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
