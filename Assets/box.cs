using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw(TagScript.Horizontal)!=0)
        {
            Rigidbody2D.velocity = new Vector2(speed * Input.GetAxisRaw(TagScript.Horizontal), Rigidbody2D.velocity.y);
        }
        if (Input.GetAxisRaw(TagScript.Vertical) != 0)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,speed * Input.GetAxisRaw(TagScript.Vertical) );

        }
    }
}
