

public class PlayerUi : NCKHMonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.parent.localScale;
    }
}
