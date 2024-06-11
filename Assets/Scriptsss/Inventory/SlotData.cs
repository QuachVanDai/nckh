using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New SlotData", menuName = "GameData/SlotData")]

public class SlotData : ScriptableObject
{
    public List<Slot> listSlot;
}
