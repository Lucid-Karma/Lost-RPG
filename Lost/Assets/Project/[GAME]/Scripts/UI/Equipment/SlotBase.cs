using UnityEngine;
using UnityEngine.UI;

public class SlotBase : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;
    public Image icon;
    [SerializeField] protected ItemCountTextController _itemCountTextController;
    protected Inventory _item;

    void Start()
    {
        _itemCountTextController = GetComponentInChildren<ItemCountTextController>();

        icon.enabled = false;
    }

    public void AddNewItem(Inventory newItem)
    {
        _item = newItem;
        icon.sprite = _item.inventory.icon;
        icon.enabled = true;
        isEmpty = false;
        _itemCountTextController.UpdateItemText();
    }

    public void DischargeSlot()
    {
        if (_item != null)
        {
            if(!_item.inventory.isUsed)
                _item.SellItem(this);
        }
    }

    public void UpdateItemCountText()
    {
        _itemCountTextController.UpdateItemText();
    }

    public virtual void ClearSlot()
    {
        icon.enabled = false;
        isEmpty = true;
        _item = null;
        _itemCountTextController.HideItemText();
        icon.sprite = null;
    }
}
