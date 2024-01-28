using UnityEngine;

public abstract class Destroys :MonoBehaviour
{

    public virtual void Update()
    {
        this.Destroying();
    }
    public virtual void Destroying()
    {
        if (!CanDestroy()) return;
        this.destroyObject();

    }
    public virtual void destroyObject()
    {
        Destroy(transform.gameObject);
    }
    public abstract bool CanDestroy();

}
