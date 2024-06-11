using QuachDai.NinjaSchool.MainCanvas;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    [Serializable]
    public class Fashion
    {
        public GameObject gameObject;
        public KeyShowOpion keyShowOpion;
    }
    public class FashionPlayer : Singleton<FashionPlayer>
    {
        [SerializeField] bool isOption;
        public List<Fashion> fashionList;
        private void Start()
        {
            for (int i = 0; i < fashionList.Count; i++)
                fashionList[i].gameObject.SetActive(IsActive(fashionList[i].keyShowOpion));
        }
        bool IsActive(KeyShowOpion keyShowOpion)
        {
            isOption = PlayerPrefs.GetInt(keyShowOpion.ToString()) == 1 ? true : false;
            return isOption;
        }
        public void SetActive(KeyShowOpion keyShowOpion)
        {
            for (int i = 0; i < fashionList.Count; i++)
            {
                if (keyShowOpion == fashionList[i].keyShowOpion)
                {
                    fashionList[i].gameObject.SetActive(IsActive(fashionList[i].keyShowOpion));
                }
            }

        }
    }

}
public enum KeyShowOpion
{
    None = 0,
    ShowHalo = 1,
    ShowLogo = 2,
    ShowPet = 3,
    ShowShadow = 4,
}