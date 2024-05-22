using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public PlayerResources playerResources;
    public TextMeshProUGUI cristalText;

    void Start()
    {
        Debug.Log("CurrencyManager Start");
        if (playerResources == null)
        {
            playerResources = FindObjectOfType<PlayerResources>();
        }

        UpdateMoneyText();
        Debug.Log("CurrencyManager money from PlayerResources: " + playerResources.money);
    }

    public void UpdateMoneyText()
    {
        cristalText.text = playerResources.money.ToString();
        Debug.Log("CurrencyManager displaying money: " + playerResources.money);
    }
}
