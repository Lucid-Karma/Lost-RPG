
public class ShoppingPanelBase : Panel
{
    public Panel Butcher;
    public Panel BookStore;
    //public Panel WizardShop;

    protected virtual void OnEnable()
    {
        EventManager.OnButcherInteract.AddListener(InitializeButcherPanel);
        EventManager.OnBookstoreInteract.AddListener(InitializeBookStorePanel);
        //EventManager.OnWizardInteract.AddListener(InitializeWizardShopPanel);
        EventManager.OnShoppingEnd.AddListener(HideAllPanels);
    }
    protected virtual void OnDisable()
    {
        EventManager.OnButcherInteract.RemoveListener(InitializeButcherPanel);
        EventManager.OnBookstoreInteract.RemoveListener(InitializeBookStorePanel);
        //EventManager.OnWizardInteract.RemoveListener(InitializeWizardShopPanel);
        EventManager.OnShoppingEnd.RemoveListener(HideAllPanels);
    }

    protected virtual void Start()
    {
        Butcher.HidePanel();
        BookStore.HidePanel();
        //WizardShop.HidePanel();
    }

    public void InitializeButcherPanel()
    {
        Butcher.ShowPanel();
    }

    public void InitializeBookStorePanel()
    {
        BookStore.ShowPanel();
    }

    //private void InitializeWizardShopPanel()
    //{
    //    WizardShop.ShowPanel(); 
    //}

    protected virtual void HideAllPanels()
    {
        Butcher.HidePanel();
        BookStore.HidePanel();
    }
}
