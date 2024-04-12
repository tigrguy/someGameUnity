using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Card 
{
    public string Name;
    public Sprite Logo;
    public int Attack;
    public int Manacost;
    public Card(string name,string logoPath, int attack, int manacost)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Manacost = manacost;
    }

}

public static class CardManag
{
    public static List<Card> AllCards = new List<Card>();
    //�������� ���� ���� ����� � � ��������� ���� �� ���������
}


public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomatia", "Resources/Sprite/Cards/diplomatia", 40,10));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/vodka", 11,20));
        CardManag.AllCards.Add(new Card("vodka", "Resources/Sprite/Cards/vodka", 15, 3));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/scream", 33, 40));


    }

}