using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Card 
{
    public string Name;
   
    public int Attack;

    public Card(string name, int attack)
    {
        Name = name;
        
        Attack = attack;

    }

}

public static class CardManag
{
    public static List<Card> AllCards = new List<Card>();

}


public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomatia", 5));
        CardManag.AllCards.Add(new Card("scream", 5));
    }

}
