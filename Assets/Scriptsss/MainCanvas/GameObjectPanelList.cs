using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.MainCanvas
{
    public class GameObjectPanelList : MonoBehaviour
    {
        public List<GameObject>  gameObjectPanelList;
        public void Hidden()
        {
            foreach(GameObject objPanel in gameObjectPanelList)
            {
                objPanel.SetActive(false);
            }
        }
    }
}
