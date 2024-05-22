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
    public static List<Card> AllCards = new List<Card>(); //���� ���� ���� ������
    public static List<Card> SpecialCards = new List<Card>(); // ���� ���� ���� ��������?
    public static List<Card> SpeciaSpecialCards = new List<Card>();
    //�������� ���� ���� ����� � � ��������� ���� �� ���������
}

public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomations", "������� 15 �����", "Resources/Sprite/Cards/diplomations", 15,0, WeaknessCardManager.DEMOCRATY));
        CardManag.AllCards.Add(new Card("scar", "������� 25 �����", "Resources/Sprite/Cards/scar", 25,1, WeaknessCardManager.SCARING));
        CardManag.AllCards.Add(new Card("charming", "������� 11 �����", "Resources/Sprite/Cards/charming", 11, 2, WeaknessCardManager.CHARMING));
        CardManag.AllCards.Add(new Card("diplomation", "������� 10 �����", "Resources/Sprite/Cards/diplomation", 10, 0, WeaknessCardManager.DEMOCRATY));

        //CardManag.SpecialCards.Add(new Card("SpecialCards", "������������� �����", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        CardManag.SpecialCards.Add(new Card("Uwu2", "������������� �����", "Resources/Sprite/Cards/Uwu2", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        //CardManag.SpecialCards.Add(new Card("random", "������������� �����", "Resources/Sprite/Cards/random", 0, 0, GetRandomWeaknessCard()));
        CardManag.SpeciaSpecialCards.Add(new Card("ImScene", "������������� �����", "Resources/Sprite/Cards/ImScene", 0, 0, WeaknessCardManager.DAMAGE_BOOST_ImScene));

    }

    public WeaknessCardManager GetRandomWeaknessCard()
    {
        // �������� ������ ���� �������� ������������
        Array values = Enum.GetValues(typeof(WeaknessCardManager));

        // �������� ��������� ��������
        WeaknessCardManager randomWeaknessCard = (WeaknessCardManager)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        // ���������� ��������� ��������
        return randomWeaknessCard;
    }
}
