using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.ObjectPooling;
using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.Monsters
{
    public class MonsterWeapons : MonoBehaviour
    {
        public Monster monster; 
        public Player player=>Player.Instance;

        [SerializeField] ObjectPool objectPool;
        [SerializeField] KeyOjectPool keyPool;
        [SerializeField] List<GameObject> objectsList;
       
     
        void SnowSpawm()
        {
            foreach (GameObject obj in objectsList)
            {
                if (!obj.gameObject.activeSelf)
                {
                    obj.gameObject.SetActive(true);
                    break;
                }

            }
        }
    }
}
