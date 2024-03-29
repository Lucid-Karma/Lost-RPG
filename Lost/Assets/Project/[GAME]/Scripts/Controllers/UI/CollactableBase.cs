using UnityEngine;

public class CollactableBase : MonoBehaviour, ICollectable
{
    public InventorySO inventory;
    [HideInInspector] public bool isOnMenu = false;
    [HideInInspector] public int itemCount;

    void Start()
    {
        itemCount = 0;
    }
    public virtual void Collect()
    {
        //Debug.Log(itemCount + " collected");
    }
}
