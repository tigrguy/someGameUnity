using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public PlayerResources resourcePlayer;
    public int costFood = 10;
    public int costWater = 15;
    public int costSword = 20;
    public int costAxe = 25;

    public GameObject Sword;
    public GameObject Axe;

    public Game game;
    public int Peredatchik_1= 0;
    public int Peredatchik_2 = 0;

    public void BuyFood()
    {
        if (resourcePlayer.money >= costFood)
        {
            resourcePlayer.money -= costFood;
            resourcePlayer.food += 1;
            resourcePlayer.UpdateText();
        }
    }

    public void BuyWater()
    {
        if (resourcePlayer.money >= costWater)
        {
            resourcePlayer.money -= costWater;
            resourcePlayer.water += 1;
            resourcePlayer.UpdateText();
        }
    }

    public void BuySword()
    {
        for (int j = 0; j < resourcePlayer.slots.Length; j++)
        {
            if (resourcePlayer.isFull[j] == false)
            {
                if (resourcePlayer.money >= costSword)
                {
                    resourcePlayer.money -= costSword;
                    resourcePlayer.UpdateText();
                    Instantiate(Sword, resourcePlayer.slots[j].transform);
                    resourcePlayer.isFull[j] = true;
                    Peredatchik_1++;
                    PlayerPrefs.SetInt("Peredatchik_1", 1);
                    PlayerPrefs.Save();
                    Debug.Log("Покупка 1");
                    break;
                }
            }
        }
    }

    public void BuyAxe()
    {
        for (int j = 0; j < resourcePlayer.slots.Length; j++)
        {
            if (resourcePlayer.isFull[j] == false)
            {
                if (resourcePlayer.money >= costAxe)
                {
                    resourcePlayer.money -= costAxe;
                    resourcePlayer.UpdateText();
                    Instantiate(Axe, resourcePlayer.slots[j].transform);
                    resourcePlayer.isFull[j] = true;
                    Peredatchik_2++;
                    PlayerPrefs.SetInt("Peredatchik_2", 2);
                    PlayerPrefs.Save();
                    Debug.Log("Покупка 2");
                    break;
                }
            }
        }
    }


}