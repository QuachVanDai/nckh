using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Iteam", menuName = "SO/junkSO")]

public class JunkSO: ScriptableObject
{
    public string _name = "Cac loai item";
    public List<DropRate> dropRateList;
}
