
using UnityEngine;

[CreateAssetMenu(fileName = "New Avatar", menuName = "GameData/Items/Equipment/Avatar")]
public class AvatarSO : EquipmentSO
{
    [Space]
    [Header("Animation")]
    public Sprite[] headIdle;
    public Sprite[] headRun;
    public Sprite[] headAttack;
    public Sprite[] headDown;
 
}
