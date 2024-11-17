
using UnityEngine;

[CreateAssetMenu(fileName = "New Cloth", menuName = "GameData/Items/Equipment/Cloth")]
public class ClothSO : EquipmentSO
{
    [Header("Increase Armor")]
    public int armorValue;

    [Space]
    [Header("Animation")]
    public Sprite[] bodyIdle;
    public Sprite[] bodyRun;
    public Sprite[] bodyAttack;
    public Sprite[] bodyDown;
 
}
