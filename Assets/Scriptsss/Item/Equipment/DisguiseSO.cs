using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Disguise", menuName = "GameData/DisguiseSO")]

public class DisguiseSO : ScriptableObject
{
    public Disguise disguiseSO;

}
[Serializable]
public class Disguise
{
    public AvatarSO Head;
    public ClothSO Body;
    public PantSO Leg;
}