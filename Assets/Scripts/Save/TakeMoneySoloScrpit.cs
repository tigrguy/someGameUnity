using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeMoneySoloScrpit : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        int moneySave = PlayerPrefs.GetInt("MoneyInt");
        moneyText.text = moneySave.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
