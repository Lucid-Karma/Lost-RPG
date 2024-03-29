using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new();
    public static UnityEvent OnGameEnd = new();

    public static UnityEvent OnLevelStart = new();
    public static UnityEvent OnLevelContine = new();
    public static UnityEvent OnLevelFinish = new();

    public static UnityEvent OnLevelSuccess = new();
    public static UnityEvent OnLevelFail = new();

    public static UnityEvent OnRestart = new();

    public static UnityEvent OnMusicOn = new();
    public static UnityEvent OnMusicOff = new();

    // UI
    public static UnityEvent OnInteract = new();
    // dialogue
    public static UnityEvent OnVillagerMeet = new();
    public static UnityEvent OnVillagerInteract = new();
    public static UnityEvent OnDialogueEnd = new();
    //shopping
    public static UnityEvent OnShopping = new();
    public static UnityEvent OnShopDialogueEnd = new();
    public static UnityEvent OnButcherInteract = new();
    public static UnityEvent OnBookstoreInteract = new();
    public static UnityEvent OnFishmongerInteract = new();
    public static UnityEvent OnWizardInteract = new();
    public static UnityEvent OnBlacksmithInteract = new();  //!!!
    public static UnityEvent OnPlayerSell = new();
    public static UnityEvent OnAmountChange = new();
    public static UnityEvent OnShoppingEnd = new();
    //quest
    public static UnityEvent OnQuest = new();
    public static UnityEvent OnQuestEnd = new();

    //public static UnityEvent OnInteractEnd = new();
}
