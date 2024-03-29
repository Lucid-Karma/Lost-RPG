using UnityEngine;

public class Inventory : CollactableBase
{
    [HideInInspector] public int slotNum;
    public override void Collect()
    {
        base.Collect();
        itemCount ++;
        ItemManager.Instance.UpdateInventory(this, isOnMenu, itemCount);
        
        isOnMenu = true;
    }

    public void BuyItem()
    {
        if (PlayerCoinController.coinAmount >= inventory.itemPurchasePrice)
            PlayerCoinController.coinAmount -= inventory.itemPurchasePrice;
        else return;
        
        itemCount ++;
        ItemManager.Instance.UpdateInventory(this, isOnMenu, itemCount);

        EventManager.OnAmountChange.Invoke();

        if(!isOnMenu)   isOnMenu = true;
    }

    public void SellItem(SlotBase slot)
    {
        if(itemCount > 0)
        {
            itemCount --;
            ItemManager.Instance.DischargeInventory(slot, itemCount);
            PlayerCoinController.coinAmount += inventory.itemSalePrice;                 

            EventManager.OnAmountChange.Invoke();

            if (isOnMenu && itemCount == 0)
            {
                slot.ClearSlot();
                isOnMenu = false;
                slotNum = -1;
            }  
        }
    }
}
