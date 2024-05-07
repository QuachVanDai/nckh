using QuachDai.NinjaSchool.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButon : MonoBehaviour
{
    Player player => Player.Instance;

    public void AddLevel()
    {
        if (player.GetLevel() == 20) return;
        player.AddLevel();
        player.SetHp(player.GetMaxHp());
        player.SetMp(player.GetMaxMp());
        player.GetLevelText();
    }
    public void AddXu()
    {
        player.SetXu(1000);
    }
}
