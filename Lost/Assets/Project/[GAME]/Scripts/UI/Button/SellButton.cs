using UnityEngine;

public class SellButton : MonoBehaviour
{
    public void Sell()
    {
        EventManager.OnShopDialogueEnd.Invoke();
        EventManager.OnPlayerSell.Invoke();
    }
}
