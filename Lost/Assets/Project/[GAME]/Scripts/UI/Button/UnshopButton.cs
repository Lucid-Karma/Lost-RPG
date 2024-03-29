using UnityEngine;

public class UnshopButton : MonoBehaviour
{
    public void EndShop()
    {
        EventManager.OnShoppingEnd.Invoke();
    }
}
