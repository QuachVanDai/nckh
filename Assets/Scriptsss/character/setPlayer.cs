using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SetPlayer
{
  
    private Dictionary<int, int> ExpPlayer
        = new Dictionary<int, int>();
    private Dictionary<int, int> HpPlayer
    = new Dictionary<int, int>();
    private Dictionary<int, int> MpPlayer
    = new Dictionary<int, int>();
    private Dictionary<int, Tuple<int, int>> DamePlayer
    = new Dictionary<int, Tuple<int, int>>();
  
    public SetPlayer()
    {
        setExpPlayerDictionary();
        setHPPlayerDictionary();
        setMPPlayerDictionary();
        setDamePlayerDictionary();
    }

    public Dictionary<int, int> getExpPlayerDictionary()
    {
        return ExpPlayer;
    }
  
    public void setExpPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(1500 * Math.Pow(i, 1.5f));
            ExpPlayer.Add(i, (int)v);
        }

    }
    public Dictionary<int, int> getHPPlayerDictionary()
    {
        return HpPlayer;
    }
    public void setHPPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(2000 * Math.Pow(i, 0.6f));
            HpPlayer.Add(i, (int)v);
        }

    }
    public Dictionary<int, int> getMPPlayerDictionary()
    {
        return MpPlayer;
    }
    public void setMPPlayerDictionary()
    {
        for (int i = 1; i <= 20; i++)
        {
            double v = Math.Round(2000 * Math.Pow(i, 0.6f));
            MpPlayer.Add(i, (int)v);
        }
    }
    public Tuple<int, int> getDamePlayerDictionary(int index)
    {
        Tuple<int, int> g = DamePlayer[index];
        return g;
    }
    public void setDamePlayerDictionary()
    {
        int min_d = 110, max_d = 120;
        for (int i = 1; i <= 20; i++)
        {
            DamePlayer.Add(i, new Tuple<int, int>(min_d, max_d));
            min_d += 30;
            max_d += 30;
        }
    }
}
