
using UnityEngine;

[CreateAssetMenu(fileName = "New Pant", menuName = "GameData/Items/Equipment/Pant")]
public class PantSO : EquipmentSO
{
    [Header("Increase HP")]
    public int HpValue;

    [Space]
    [Header("Animation")]
    public Sprite[] legIdle;
    public Sprite[] legRun;
    public Sprite[] legAttack;
    public Sprite[] legDown;
 
}
