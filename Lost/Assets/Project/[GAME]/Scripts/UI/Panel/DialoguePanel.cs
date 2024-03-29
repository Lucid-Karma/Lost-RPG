using UnityEngine;

public class DialoguePanel : Panel
{
    public Panel VillagerPanel;
    public Panel VendorPanel;

    void OnEnable()
    {
        EventManager.OnShopping.AddListener(InitializeVendorPanel);
        EventManager.OnVillagerInteract.AddListener(InitializeVillagerPanel);
        EventManager.OnDialogueEnd.AddListener(HideVillagerPanel);
        EventManager.OnShopDialogueEnd.AddListener(HideVendorPanel);
    }
    void OnDisable() 
    {
        EventManager.OnShopping.RemoveListener(InitializeVendorPanel);
        EventManager.OnVillagerInteract.RemoveListener(InitializeVillagerPanel);
        EventManager.OnDialogueEnd.RemoveListener(HideVillagerPanel);
        EventManager.OnShopDialogueEnd.RemoveListener(HideVendorPanel);
    }

    void Start()
    {
        VillagerPanel.HidePanel();
        VendorPanel.HidePanel();
    }

    private void InitializeVillagerPanel()
    {
        VillagerPanel.ShowPanel();
    }
    private void InitializeVendorPanel()
    {
        VendorPanel.ShowPanel();
        Debug.Log("initializing vendor panel");
    }

    private void HideVillagerPanel()
    {
        VillagerPanel.HidePanel();
    }
    private void HideVendorPanel()
    {
        VendorPanel.HidePanel();
    }

    private void HideAllPanels()        
    {
        VillagerPanel.HidePanel();
        VendorPanel.HidePanel();
    }
}