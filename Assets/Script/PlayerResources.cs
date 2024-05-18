using UnityEngine;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    public int money = 150;
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
    }

    public void UpdateText()
    {
        textMoney.text = "Монет: " + money.ToString();
        textWater.text = "Воды: " + water.ToString();
        textFood.text = "Еды: " + food.ToString();
    }
}