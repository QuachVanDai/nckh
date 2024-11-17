using UnityEngine;
[CreateAssetMenu(fileName = "New food", menuName = "GameData/Items/Potion/Food")]

public class FoodSO : PotionSO
{
    [Space]
    [Header("Uses")]
    public int Hp;
    public int Mp;
  
}
