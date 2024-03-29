using UnityEngine;

public class BuyButton : MonoBehaviour
{
    private string role;

    public void Buy()
    {
        role = InteractableBase.interactableRole;

        switch (role)
        {
            case "Butcher":
                EventManager.OnButcherInteract.Invoke();
                break;

            case "Bookseller":
                EventManager.OnBookstoreInteract.Invoke();
                break;

            case "Piscatrix":
                EventManager.OnFishmongerInteract.Invoke();
                break;
            case "Blacksmith":
                EventManager.OnBlacksmithInteract.Invoke();
                break;
        }

        EventManager.OnShopDialogueEnd.Invoke();
    }
}
