using UnityEngine;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    public int money = 0;
    public int water = 0;
    public int food = 0;

    public bool[] isFull;
    public GameObject[] slots;

    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textWater;
    public TextMeshProUGUI textFood;

    
    void Start()
    {
        UpdateText();
        int moneySave = PlayerPrefs.GetInt("MoneyInt", 90);
        money = moneySave;
        textMoney.text = money.ToString();
    }

    public void UpdateText()
    {
        textMoney.text = money.ToString();
        textWater.text = "Воды: " + water.ToString();
        textFood.text = "Еды: " + food.ToString();
    }
}