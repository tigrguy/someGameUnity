using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaknessCardManager
{
    DEMOCRATY,
    CHARMING,
    SCARING,
    DAMAGE_BOOST
}

public struct Card 
{
    public string Name;
    public string Opis;
    public Sprite Logo;
    public int Attack;
    public int Manacost;
    public WeaknessCardManager WeaknessCardManager;

    public Card(string name, string opis,string logoPath, int attack, int manacost, WeaknessCardManager weaknessCard)
    {
        Name = name;
        Opis = opis;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Manacost = manacost;
        WeaknessCardManager =  weaknessCard;
    }

}

public static class CardManag
{
    public static List<Card> AllCards = new List<Card>(); //лист всех карт игрока
    public static List<Card> SpecialCards = new List<Card>(); // лист спец карт дебафФОВ?
    //добавить лист карт врага и в менеджере ниже их прописать
}


public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomatia", "Наносит урон дипломатией", "Resources/Sprite/Cards/diplomatia", 15,10, WeaknessCardManager.DEMOCRATY));
        CardManag.AllCards.Add(new Card("scream", "Запугивает", "Resources/Sprite/Cards/scream", 25,20, WeaknessCardManager.SCARING));
        CardManag.AllCards.Add(new Card("charm", "Очаровывает", "Resources/Sprite/Cards/charm", 11, 3, WeaknessCardManager.CHARMING));
        CardManag.AllCards.Add(new Card("diplomatia", "Дипломатичная карта", "Resources/Sprite/Cards/diplomatia", 10, 40, WeaknessCardManager.DEMOCRATY));

        CardManag.SpecialCards.Add(new Card("SpecialCards", "Дипломатичная карта", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.SCARING));
        CardManag.SpecialCards.Add(new Card("BOOST", "Дипломатичная карта", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));

    }

}
