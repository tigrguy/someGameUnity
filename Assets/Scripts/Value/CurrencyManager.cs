using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CurrencyManager : MonoBehaviour
{
    public GameManager GameManager;
    int cristalSave;
    float PlayerHpBar;
    public TextMeshProUGUI cristalText;

    void Awake()
    {
        cristalText.text = PlayerPrefs.GetInt("cristalSave").ToString();
        
    }

    void SaveGame()
    {
        // Получить экземпляр GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();

        // Получить объект ResultGo из экземпляра GameManager
        GameObject resultGo = gameManager.gameObject.transform.Find("ResultGo").gameObject;

        if (resultGo == true)
        {
            PlayerPrefs.SetInt("cristalSave", cristalSave + 10);
            PlayerPrefs.SetFloat("SavedFloat", PlayerHpBar);
            //PlayerPrefs.Save();
            cristalText.text = (cristalSave + 10).ToString();

            Debug.Log("Game data saved!");
        }
        
    }

}

