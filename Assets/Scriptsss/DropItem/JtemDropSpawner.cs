using System.Collections.Generic;
using UnityEngine;

public class JtemDropSpawner : Spawner
{
    private static JtemDropSpawner instance;
    public static JtemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (JtemDropSpawner.instance != null) Debug.LogError("Only 1 itemDropSpawner allow to exist");
        JtemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        int index = Random.Range(0, dropList.Count  );
        Transform itemDrop = this.spawn(dropList[index].itemSO.name, pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
