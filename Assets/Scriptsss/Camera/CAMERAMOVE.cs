
using Unity.Mathematics;
using UnityEngine;

public class CAMERAMOVE : MonoBehaviour
{
    public Transform player;
    public float[] xMax, yMax, xMin, yMin;
    public Vector2[] TopTranForm;
    public Vector2[] EndTranForm;
    public int index=0;
    public bool flat = true;
    private string _playerTag = "player";
    private float _getX, _x;
    private float _getY, _y;
    public GameObject playerObject;
    // Update is called once per frame
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(_playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng có tag là Player.");
        }
    }
    private void Update()
    {
        if (!flat) return;
            playerObject = GameObject.FindGameObjectWithTag(_playerTag);
            if (playerObject != null)
            {
                player = playerObject.transform;
            }

            _x = math.max(xMin[index], player.position.x);
            _getX = math.min(xMax[index], _x);
            /*  TH1:       Nếu player ơ vị trí nhỏ hơn -6;
                    vd player.positon.x =-7 ==> X_min=-6; ==> getX = -6 

               TH2:     Nếu player ở vị trí lớn hơn 6 :
                    vd player.positon.x = 7 ==> X_min= 7 ; ==> getX = 6;

            Muc dich cho toa do X cua Camera  nằm trong khoảng (-6, 6)
            */
            _y = math.max(yMin[index], player.position.y);
            _getY = math.min(yMax[index], _y);
            transform.position = new Vector3(_getX, _getY, transform.position.z);
    }
    public void setTopTranForm(int number)
    {
        flat = false;
        index = number;
        playerObject.transform.position = TopTranForm[index];
        playerObject.GetComponent<Rigidbody2D>().gravityScale =0;
        
    }
    public void setEndTranForm(int number)
    {
        flat = false;
        index = number;
        playerObject.transform.position = EndTranForm[index];
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0;

    }
}
    /*private bool isDragging = false;
    private Vector3 previousMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;
            Vector3 newPosition = transform.position - deltaMousePosition * 0.02f;
    *//*        if (newPosition.y < 0)
            {
                newPosition.y = 0;
            }
            else if (newPosition.y > 3)
            {
                newPosition.y = 3;
            }
            if (newPosition.x <= -1)
            {
                newPosition.x = -1;

            }
            else if (newPosition.x >= 27)
            {
                newPosition.x = 27;
            }*//*
            transform.position = newPosition;
        }

        previousMousePosition = Input.mousePosition;
    }
}
*/