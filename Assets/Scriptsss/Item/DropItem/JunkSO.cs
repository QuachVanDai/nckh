using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewJung", menuName = "JungSO")]

public class JunkSO: ScriptableObject
{
    public string _name = "Cac loai item";
    public List<ItemSO> itemList;
}
