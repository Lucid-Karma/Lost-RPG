using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : SlotBase
{
    private enum ItemState
    {
        Disabled,
        Sell,
        Use
    }
    private ItemState state;
    private void OnEnable()
    {
        state = ItemState.Disabled;
        EventManager.OnPlayerSell.AddListener(() => state = ItemState.Sell);
        EventManager.OnShoppingEnd.AddListener(() => state = ItemState.Disabled);
    }
    private void OnDisable()
    {
        EventManager.OnPlayerSell.RemoveListener(() => state = ItemState.Sell);
        EventManager.OnShoppingEnd.RemoveListener(() => state = ItemState.Disabled);
    }

    public override void ClearSlot()
    {
        base.ClearSlot();
        state = ItemState.Disabled;
    }

    #region ButtonMethods
    public void UseItem()
    {
        switch (state)
        {
            case ItemState.Disabled:
                break;
            case ItemState.Sell:
                DischargeSlot();
                break;
        }
    }
    #endregion
}
