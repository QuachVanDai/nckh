

public class DestroyItemByTime : Destroys
{
    private bool _CanDestroy;
    private void Start()
    {
        _CanDestroy = false;
        Invoke(nameof(IsCanDestroy), 6f);
    }
    public bool IsCanDestroy()
    {
        _CanDestroy = true;
        return _CanDestroy;
    }
    public override bool CanDestroy()
    {
        return _CanDestroy;
    }
}
