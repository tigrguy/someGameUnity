using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMoney : MonoBehaviour
{
    public int MoneySave = 40;
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



}
