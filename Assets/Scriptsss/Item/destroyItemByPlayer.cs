
using UnityEngine;

public class DestroyItemByPlayer : Destroys
{
    bool isDestroy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isDestroy = true;
        }
    }
    public override bool CanDestroy()
    {
        return isDestroy;
    }
}
