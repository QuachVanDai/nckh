

public class DestroyItemByTime : Destroys
{
    private bool _CanDestroy;
    private void Start()
    {
        _CanDestroy = false;
        Invoke(nameof(isCanDestroy), 6f);
    }
    public bool isCanDestroy()
    {
        _CanDestroy = true;
        return _CanDestroy;
    }
    public override bool CanDestroy()
    {
        return _CanDestroy;
    }
}
