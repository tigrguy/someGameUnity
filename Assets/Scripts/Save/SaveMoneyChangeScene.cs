using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveMoneyChangeScene : MonoBehaviour
{


    public TextMeshProUGUI moneyText;

    public int megdu = 0;
    public int zalupa = 0;
    public int summa = 0;
    void Start()
    {
        int moneySave = PlayerPrefs.GetInt("MoneyIntScene");
        SukaRabotai();
        moneyText.text = summa.ToString();
    }

    void SukaRabotai()
    {
        megdu = PlayerPrefs.GetInt("MoneyInt");
        zalupa = PlayerPrefs.GetInt("MoneyIntScene");
        summa = megdu + zalupa;
    }


}
