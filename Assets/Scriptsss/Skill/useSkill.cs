using System;

using UnityEngine;
using QuachDai.NinjaSchool.Character;

public class UseSkill : MonoBehaviour
{
    private static UseSkill instance;
    private int currKeySkill;
    private int lastKeySkill;
    [SerializeField] protected bool[] isUseSkill;

    public static UseSkill Instance {  get { return instance; } }
    Player player => Player.Instance;
    protected  void Awake()
    {
        UseSkill.instance = this;
    }
    private void Reset()
    {
        isUseSkill =  new bool[5];
        Array.Fill(isUseSkill, false);
        // currLevel = Player.Instance._level;
    }

    public void use()
    {
        if (player.GetLevel() < 5) { setIsUseSkill(0);  return; }
        if (player.GetLevel() < 10) { setIsUseSkill(1);  return; }
        if (player.GetLevel() < 15) { setIsUseSkill(2);  return; }
        if (player.GetLevel() < 20) { setIsUseSkill(3);  return; }
        if (player.GetLevel() < 25) { setIsUseSkill(4);  return; }
    }
    public bool getIsUseSkill(int index)
    {
        return isUseSkill[index];
    }
    public void setIsUseSkill(int z)
    {
        for (int i = 0; i<=z; i++)
        {
            isUseSkill[i] = true;
        }
    }
    public int getCurrKeySkill()
    {
        return currKeySkill;
    }
    public void SetCurrKeySkill(int key)
    {
        if (!isUseSkill[key/5]) { return; }
        this.currKeySkill = key / 5;
    }
    public int getLastKeySkill()
    {
        return lastKeySkill;
    }
    public void SetLastKeySkill(int key)
    {
        this.lastKeySkill = this.currKeySkill;
    }
 
}
