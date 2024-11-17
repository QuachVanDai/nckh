
using UnityEngine;
[CreateAssetMenu(fileName = "New hp", menuName = "GameData/Items/Potion/Hp")]

public class HpSO : PotionSO
{
    [Space]
    [Header("Uses")]
    public int hP;
}
