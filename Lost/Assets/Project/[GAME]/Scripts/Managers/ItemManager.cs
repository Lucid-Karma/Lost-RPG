using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    SlotBase[] _slots;

    [HideInInspector] public int InventoryItemCount = 0;

    [HideInInspector] public string type;
    public void UpdateInventory(Inventory inventoryItem, bool isOnMenu, int count)
    {
        type = inventoryItem.inventory.type;
        if (type == "Inventory")
            _slots = InventoryMenu.GetComponentsInChildren<SlotBase>();
        else if (type == "Equipment")
            _slots = EquipmentMenu.GetComponentsInChildren<SlotBase>();

        for (int i = 0; i < _slots.Length; i++)
        {
            if (!isOnMenu)
            {
                if(_slots[i].isEmpty)
                {
                    InventoryItemCount = count;
                    _slots[i].AddNewItem(inventoryItem);
                    inventoryItem.slotNum = i;
                    break;
                }
            }
            else
            {
                InventoryItemCount = count;
                _slots[inventoryItem.slotNum].UpdateItemCountText();
                break;
            }
        }
    }

    public void DischargeInventory(SlotBase slot, int count)
    {
        InventoryItemCount = count;
        slot.UpdateItemCountText();
    }
}
