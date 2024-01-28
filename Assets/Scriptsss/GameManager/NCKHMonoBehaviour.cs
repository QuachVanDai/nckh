
using UnityEngine;

public class NCKHMonoBehaviour : MonoBehaviour
{
    
    protected virtual void Reset()
    {

        LoadComponent();
    }
    protected virtual void Awake()
    {
        LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        //this.loadPrefabs();
    }
}
