using System;
using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    [SerializeField]
    public class SetMonster
    {
        private Dictionary<int, double> expMonster
        = new Dictionary<int, double>();
        private Dictionary<int, int> hPMonster
        = new Dictionary<int, int>();
        private Dictionary<int, Tuple<int, int>> dameMonster
        = new Dictionary<int, Tuple<int, int>>();
        public SetMonster()
        {
            setExpMonsterDictionary();
            setHPMonsterDictionary();
            setDameMonsterDictionary();
        }
        public double getExpMonsterDictionary(int i)
        {
            return expMonster[i];
        }
        public void setExpMonsterDictionary()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i == 100)
                    expMonster.Add(i, 0);
                else
                    expMonster.Add(i, 1.7f * Math.Pow(i, 0.8f));
            }
        }

        public Dictionary<int, int> getHPMonsterDictionary()
        {
            return hPMonster;
        }
        public void setHPMonsterDictionary()
        {
            for (int i = 1; i <= 100; i++)
            {
                double v = Math.Round(620 * Math.Pow(i, 0.6f));
                if(i==100) v = Math.Round(5000 * Math.Pow(i, 0.6f));
                hPMonster.Add(i, (int)v);
            }

        }
        public Tuple<int, int> getDameMonsterDictionary(int index)
        {
            Tuple<int, int> g = dameMonster[index];
            return g;
        }
        public void setDameMonsterDictionary()
        {
            int min_d = 40, max_d = 50;
            for (int i = 1; i <= 100; i++)
            {
                dameMonster.Add(i, new Tuple<int, int>(min_d, max_d));
                min_d += 20;
                max_d += 20;
            }
        }
    }
}
