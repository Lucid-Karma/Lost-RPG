using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VendorBase : InteractableBase
{
    #region Events
    [HideInInspector]
    public UnityEvent OnButcher = new();
    [HideInInspector]
    public UnityEvent OnBookStore = new();
    [HideInInspector]
    public UnityEvent OnFisher = new();
    #endregion

    protected IShopPanel shopPanel;

    public override void Interact()
    {
        base.Interact();
        EventManager.OnShopping.Invoke();
        Debug.Log("inside Ineract base");
    }
}
