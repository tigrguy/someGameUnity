using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum WeaknessCardManager
{
    DEMOCRATY,
    CHARMING,
    SCARING,
    NULLE,
    DAMAGE_BOOST,
    DAMAGE_BOOST_ImScene
}

public struct Card
{
    public string Name;
    public string Opis;
    public Sprite Logo;
    public int Attack;
    public int Manacost;
    public WeaknessCardManager WeaknessCardManager;

    public Card(string name, string opis, string logoPath, int attack, int manacost, WeaknessCardManager weaknessCard)
    {
        Name = name;
        Opis = opis;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Manacost = manacost;
        WeaknessCardManager = weaknessCard;
    }

}

public static class CardManag
{
    public static List<Card> AllCards = new List<Card>(); //лист всех карт игрока
    public static List<Card> SpecialCards = new List<Card>(); // лист спец карт дебафФОВ?
    public static List<Card> SpeciaSpecialCards = new List<Card>();
    //добавить лист карт врага и в менеджере ниже их прописать
}

public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomations", "Наносит 15 урона", "Resources/Sprite/Cards/diplomations", 15,0, WeaknessCardManager.DEMOCRATY));
        CardManag.AllCards.Add(new Card("scar", "Наносит 25 урона", "Resources/Sprite/Cards/scar", 25,1, WeaknessCardManager.SCARING));
        CardManag.AllCards.Add(new Card("charming", "Наносит 11 урона", "Resources/Sprite/Cards/charming", 11, 2, WeaknessCardManager.CHARMING));
        CardManag.AllCards.Add(new Card("diplomation", "Наносит 10 урона", "Resources/Sprite/Cards/diplomation", 10, 0, WeaknessCardManager.DEMOCRATY));

        //CardManag.SpecialCards.Add(new Card("SpecialCards", "Дипломатичная карта", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        CardManag.SpecialCards.Add(new Card("Uwu2", "Дипломатичная карта", "Resources/Sprite/Cards/Uwu2", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        //CardManag.SpecialCards.Add(new Card("random", "Дипломатичная карта", "Resources/Sprite/Cards/random", 0, 0, GetRandomWeaknessCard()));
        CardManag.SpeciaSpecialCards.Add(new Card("ImScene", "Дипломатичная карта", "Resources/Sprite/Cards/ImScene", 0, 0, WeaknessCardManager.DAMAGE_BOOST_ImScene));

    }

    public WeaknessCardManager GetRandomWeaknessCard()
    {
        // Получаем список всех значений перечисления
        Array values = Enum.GetValues(typeof(WeaknessCardManager));

        // Выбираем случайное значение
        WeaknessCardManager randomWeaknessCard = (WeaknessCardManager)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        // Возвращаем случайное значение
        return randomWeaknessCard;
    }
}
