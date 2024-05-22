using UnityEngine;

public class Shop : MonoBehaviour
{
    public PlayerResources resourcePlayer;
    public int costSword = 20;
    public int costAxe = 25;

    public GameObject Sword;
    public GameObject Axe;

    public void BuySword()
    {
        for (int j = 0; j < resourcePlayer.slots.Length; j++)
        {
            if (!resourcePlayer.isFull[j])
            {
                if (resourcePlayer.money >= costSword)
                {
                    resourcePlayer.ChangeMoney(-costSword);
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
            if (!resourcePlayer.isFull[j])
            {
                if (resourcePlayer.money >= costAxe)
                {
                    resourcePlayer.ChangeMoney(-costAxe);
                    Instantiate(Axe, resourcePlayer.slots[j].transform);
                    resourcePlayer.isFull[j] = true;
                    break;
                }
            }
        }
    }
}
