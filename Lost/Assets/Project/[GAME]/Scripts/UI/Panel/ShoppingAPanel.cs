using System;
using UnityEngine;

public class ShoppingAPanel : ShoppingPanelBase
{
    [SerializeField] private Panel Fishmonger;
    [SerializeField] private Panel Blacksmith;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnFishmongerInteract.AddListener(InitializeFishmongerPanel);
        EventManager.OnBlacksmithInteract.AddListener(InitializeBlacksmithPanel);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.OnFishmongerInteract.RemoveListener(InitializeFishmongerPanel);
        EventManager.OnBlacksmithInteract.RemoveListener(InitializeBlacksmithPanel);
    }

    private void InitializeBlacksmithPanel()
    {
        Blacksmith.ShowPanel();
    }

    protected override void Start()
    {
        base.Start();
        Fishmonger.HidePanel();
        Blacksmith.HidePanel();
    }

    private void InitializeFishmongerPanel()
    {
        Fishmonger.ShowPanel();
    }

    protected override void HideAllPanels()
    {
        base.HideAllPanels();
        Fishmonger.HidePanel();
        Blacksmith.HidePanel();
    }
}
