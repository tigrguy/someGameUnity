using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMoney : MonoBehaviour
{
    public int MoneySave = 42;
    public int MoneyPlus = 15;
    public PlayerResources playerResources;
    public void SaveMoneyVoid()
    {
        PlayerPrefs.SetInt("MoneyInt", MoneySave);
        PlayerPrefs.Save();
    }

    public void GetMoneyVoid()
    {
        PlayerPrefs.GetInt("MoneyInt", MoneySave);
        PlayerPrefs.Save();
    }


    public void SaveMoneySuka()
    {
        int plusTwo = PlayerPrefs.GetInt("MoneyInt", MoneySave);
        PlayerPrefs.SetInt("MoneyInt", MoneySave + MoneyPlus );
        PlayerPrefs.Save();
    }

    public void SaveMoneyVoidShop()
    {
        //PlayerPrefs.SetInt("MoneyInt", playerResources.money);
        //PlayerPrefs.SetInt("MoneyShop", playerResources.money_last);
        PlayerPrefs.Save();
    }

    public void SaveMoneyVoidShopAfter()
    {
        int one = PlayerPrefs.GetInt("MoneyInt");
        PlayerPrefs.SetInt("MoneyInt", one + MoneyPlus);
        PlayerPrefs.Save();
    }
    public void SaveMoneyVoidPlus()
    {
        int plus = PlayerPrefs.GetInt("MoneyIntScene");
        int plusTwo = PlayerPrefs.GetInt("MoneyInt", MoneySave);
        int plusSumma = plus + plusTwo;
        PlayerPrefs.SetInt("MoneyIntScene", plusSumma);
        PlayerPrefs.Save();
    }

}
