using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Card 
{
    public string Name;
    public Sprite Logo;
    public int Attack;
    public int Defense;
    public Card(string name,string logoPath, int attack, int defense)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
    }

}

public static class CardManag
{
    public static List<Card> AllCards = new List<Card>();
    //добавить лист карт врага и в менеджере ниже их прописать
}


public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomatia", "Resources/Sprite/Cards/diplomatia", 40,1));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/vodka", 11,1));
        CardManag.AllCards.Add(new Card("vodka", "Resources/Sprite/Cards/vodka", 15, 1));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/scream", 33, 1));


    }

}
