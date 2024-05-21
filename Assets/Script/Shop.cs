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
                    break;
                }
            }
        }
    }
}