using UnityEngine;
using TMPro;

public class CoinTextController : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    public TextMeshProUGUI CoinText
    {
        get
        {
            if(coinText == null)
            coinText = GetComponent<TextMeshProUGUI>();

            return coinText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnAmountChange.AddListener(UpdateCoinText);
    }

    private void OnDisable()
    {
        EventManager.OnAmountChange.RemoveListener(UpdateCoinText); 
    }

    public int amount = 0;
    private void UpdateCoinText()
    {
        amount = PlayerCoinController.coinAmount;
        CoinText.text = amount.ToString();
    }
}
