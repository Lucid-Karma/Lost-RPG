using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : SlotBase
{
    private enum EquipmentState
    {
        Disabled,
        Sell,
        Use
    }
    private EquipmentState state;
    private void OnEnable()
    {
        state = EquipmentState.Disabled;
        EventManager.OnPlayerSell.AddListener(() => state = EquipmentState.Sell);
        EventManager.OnShoppingEnd.AddListener(UseState);
    }
    private void OnDisable()
    {
        EventManager.OnPlayerSell.RemoveListener(() => state = EquipmentState.Sell);
        EventManager.OnShoppingEnd.RemoveListener(UseState);
    }

    public override void ClearSlot()
    {
        base.ClearSlot();
        state = EquipmentState.Disabled;
    }

    #region ButtonMethods
    public void UseItem()
    {
        switch (state)
        {
            case EquipmentState.Disabled:
                break;
            case EquipmentState.Sell:
                DischargeSlot();
                break;
            case EquipmentState.Use:
                UseEquipment();
                break;
        }
    }
    #endregion

    #region PrivateMethods
    private void UseState()
    {
        if (!isEmpty)
        {
            state = EquipmentState.Use;
        }
            
    }

    private string _equipmentId;
    private void UseEquipment()
    {
        Debug.Log("inside method");
        _equipmentId = _item.inventory.itemID;
        switch (_equipmentId)
        {
            case "Dagger":
                PlayerEquipment.Instance.AddDagger();
                break;
            case "Sword":
                PlayerEquipment.Instance.AddSword();
                break;
            case "Helmet":
                PlayerEquipment.Instance.AddHelmet();
                break;
        }
    }
    #endregion
}
