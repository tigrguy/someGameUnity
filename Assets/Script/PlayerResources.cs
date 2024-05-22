using UnityEngine;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    public int money = 150;
    public bool[] isFull;
    public GameObject[] slots;
    public TextMeshProUGUI textMoney;
    public CurrencyManager currencyManager; // Ссылка на CurrencyManager

    void Start()
    {
        Debug.Log("PlayerResources Start");
        if (currencyManager == null)
        {
            currencyManager = FindObjectOfType<CurrencyManager>();
        }
        LoadResources();
        UpdateText();
        if (currencyManager != null)
        {
            currencyManager.UpdateMoneyText(); // Обновляем текст в CurrencyManager
        }
        Debug.Log("PlayerResources money after Load: " + money);
    }

    public void UpdateText()
    {
        textMoney.text = money.ToString();
    }

    public void SaveResources()
    {
        Debug.Log("Saving money: " + money);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    public void LoadResources()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
            Debug.Log("Loaded money: " + money);
        }
        else
        {
            Debug.Log("No saved money found, setting default value.");
            money = 150; // установите здесь значение по умолчанию, если сохраненных данных нет
        }
    }

    void OnApplicationQuit()
    {
        SaveResources();
    }

    public void ChangeMoney(int amount)
    {
        money += amount;
        SaveResources(); // Сохраняем деньги после изменения
        UpdateText();
        if (currencyManager != null)
        {
            currencyManager.UpdateMoneyText(); // Обновляем текст в CurrencyManager после изменения денег
        }
    }
}
