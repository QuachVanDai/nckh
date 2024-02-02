using UnityEngine;
[CreateAssetMenu(fileName = "New xu", menuName = "GameData/Items/Potion/Xu")]
public class XuSO : MoneySO
{
    [Space]
    [Header("Uses")]
    public int xu;
    public string Description;
    public override void Update()
    {
        base.Update();

        this.MoneyType = MoneyType.xu;
        Description = "Dùng xu để mua các vật phẩm";

        this.Xu = xu;
    }
}
