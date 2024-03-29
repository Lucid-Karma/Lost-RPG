using System;
using UnityEngine;

public class MenuPanels : Panel
{
    public Panel EquipmentPanel;
    public Panel QuestPanel;
    public Panel InventoryPanel;
    public Panel TopMenuPanel;
    public Panel SubMenuPanel;

    private bool _isEqOn, _isQuOn, _isInvOn = false;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(InitializeLevelPanels);
        EventManager.OnVillagerInteract.AddListener(HideAllPanels);
        EventManager.OnShopping.AddListener(HideAllPanels);
        EventManager.OnQuest.AddListener(HideAllPanels);
        EventManager.OnDialogueEnd.AddListener(InitializeLevelPanels);
        EventManager.OnPlayerSell.AddListener(InitializeSellVersion);
        EventManager.OnShoppingEnd.AddListener(InitializeLevelPanels);
        //EventManager.OnQuestEnd.AddListener(InitializeLevelPanels);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(InitializeLevelPanels);
        EventManager.OnVillagerInteract.RemoveListener(HideAllPanels);
        EventManager.OnShopping.RemoveListener(HideAllPanels);
        EventManager.OnQuest.RemoveListener(HideAllPanels);
        EventManager.OnDialogueEnd.RemoveListener(InitializeLevelPanels);
        EventManager.OnPlayerSell.RemoveListener(InitializeSellVersion);
        EventManager.OnShoppingEnd.RemoveListener(InitializeLevelPanels);
        //EventManager.OnQuestEnd.RemoveListener(InitializeLevelPanels);
    }


    void Start()
    {
        EquipmentPanel.HidePanel();
        QuestPanel.HidePanel();
        InventoryPanel.HidePanel();
        TopMenuPanel.HidePanel();
        SubMenuPanel.HidePanel();
    }

    private void InitializeLevelPanels()
    {
        TopMenuPanel.ShowPanel();
        SubMenuPanel.ShowPanel();
    }

    private void InitializePanel(Panel panel)
    {
        panel.ShowPanel();
    }

    private void HideAllPanels()
    {
        EquipmentPanel.HidePanel();
        QuestPanel.HidePanel();
        InventoryPanel.HidePanel();
        //TopMenuPanel.HidePanel();
        SubMenuPanel.HidePanel();
    }

    private void InitializeSellVersion()
    {
        if(ItemManager.Instance.type == "Inventory")
            InitializeInventoryPanel();
        else
        {
            InitializeEquipmentPanel();
        }
    }

    #region PublicMethods

    public void InitializeEquipmentPanel()
    {
        if (!_isEqOn)
        {
            EquipmentPanel.ShowPanel();
            _isEqOn = true;
        }
        else
        {
            EquipmentPanel.HidePanel();
            _isEqOn = false;
        }
    }

    public void InitializeQuestPanel()
    {
        if (!_isQuOn)
        {
            QuestPanel.ShowPanel();
            _isQuOn = true;
        }
        else
        {
            QuestPanel.HidePanel();
            _isQuOn = false;
        }
    }

    public void InitializeInventoryPanel()
    {
        if (!_isInvOn)
        {
            InventoryPanel.ShowPanel();
            _isInvOn = true;
        }
        else
        {
            InventoryPanel.HidePanel();
            _isInvOn = false;
        }
    }

    #endregion

}