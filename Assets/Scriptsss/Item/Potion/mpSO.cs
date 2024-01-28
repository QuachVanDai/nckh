
using UnityEngine;

[CreateAssetMenu(fileName = "New mp", menuName = "GameData/Items/Potion/Mp")]
public class MpSO : PotionSO
{
    [Space]
    [Header("Uses")]
    public int mP;
    public override void Update()
    {
        base.Update();
        this.PotionType = PotionType.mp;
        this.Description = "Dùng để tăng lượng mp cho bản thân";
        this.MP = mP;
    }
}
