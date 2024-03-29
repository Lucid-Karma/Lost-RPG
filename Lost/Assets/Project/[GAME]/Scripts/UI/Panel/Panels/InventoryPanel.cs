using UnityEngine;

public class InventoryPanel : Panel
{
    [SerializeField] private GameObject exitButton;

    private void OnEnable()
    {
        EventManager.OnPlayerSell.AddListener(() => exitButton.SetActive(true));
        EventManager.OnShoppingEnd.AddListener(() => exitButton.SetActive(false));
    }
    private void OnDisable()
    {
        EventManager.OnPlayerSell.RemoveListener(() => exitButton.SetActive(true));
        EventManager.OnShoppingEnd.RemoveListener(() => exitButton.SetActive(false));
    }

    private void Start()
    {
        exitButton.SetActive(false);
    }
}
