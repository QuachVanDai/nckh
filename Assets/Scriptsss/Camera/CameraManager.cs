
using QuachDai.NinjaSchool.Character;
using QuachDai.NinjaSchool.Scenes;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
namespace QuachDai.NinjaSchool.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] MiniSceneData miniSceneData;
        public Player player=>Player.Instance;
        private float _getX, _x;
        private float _getY, _y;
        // Update is called once per frame
     
        private void Update()
        {

            _x = math.max(miniSceneData.xMin, player.transform.position.x);
            _getX = math.min(miniSceneData.xMax, _x);
            /*  TH1:       Nếu player ơ vị trí nhỏ hơn -6;
                    vd player.positon.x =-7 ==> X_min=-6; ==> getX = -6 

               TH2:     Nếu player ở vị trí lớn hơn 6 :
                    vd player.positon.x = 7 ==> X_min= 7 ; ==> getX = 6;

            Muc dich cho toa do X cua Camera  nằm trong khoảng (-6, 6)
            */
            _y = math.max(miniSceneData.yMin, player.transform.position.y);
            _getY = math.min(miniSceneData.yMax, _y);
            transform.position = new Vector3(_getX, _getY, -10);
        }
       
    }
}
 