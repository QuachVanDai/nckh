
using UnityEngine;
public class PlayerUi :MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.parent.localScale;
    }
}
