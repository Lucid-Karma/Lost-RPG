
public class CoinProgressBar : ProgressBarBase
{
    void OnEnable()
    {
        EventManager.OnAmountChange.AddListener(GetCurrentFill);
    }
    void OnDisable()
    {
        EventManager.OnAmountChange.RemoveListener(GetCurrentFill);
    }

    public override void GetCurrentFill()
    {
        current = PlayerCoinController.coinAmount;
        base.GetCurrentFill();
    }
}
