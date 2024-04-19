using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Card 
{
    public string Name;
    public string Opis;
    public Sprite Logo;
    public int Attack;
    public int Manacost;
    public Card(string name, string opis,string logoPath, int attack, int manacost)
    {
        Name = name;
        Opis = opis;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Manacost = manacost;
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
        CardManag.AllCards.Add(new Card("diplomatia", "Наносит урон дипломатией", "Resources/Sprite/Cards/diplomatia", 15,10));
        CardManag.AllCards.Add(new Card("scream", "Запугивает", "Resources/Sprite/Cards/scream", 25,20));
        CardManag.AllCards.Add(new Card("charm", "Очаровывает", "Resources/Sprite/Cards/charm", 11, 3));
        CardManag.AllCards.Add(new Card("diplomatia", "Дипломатичная карта", "Resources/Sprite/Cards/diplomatia", 10, 40));


    }

}
