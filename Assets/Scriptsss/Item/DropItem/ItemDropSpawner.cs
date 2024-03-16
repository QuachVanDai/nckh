using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.Spawn
{
    public class ItemDropSpawner : Spawner
    {
        public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
        {
            int index = Random.Range(0, dropList.Count);
           // Transform itemDrop = this.spawn(dropList[index].itemSO.name, pos, rot);
           // if (itemDrop == null) return;
         //   itemDrop.gameObject.SetActive(true);
        }
    }
}
