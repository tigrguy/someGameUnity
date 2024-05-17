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
    //�������� ���� ���� ����� � � ��������� ���� �� ���������
}

public class CardManager : MonoBehaviour
{
    public void Awake()
    {
        CardManag.AllCards.Add(new Card("diplomatia", "������� ���� �����������", "Resources/Sprite/Cards/diplomatia", 15,0, WeaknessCardManager.DEMOCRATY));
        CardManag.AllCards.Add(new Card("scream", "����������", "Resources/Sprite/Cards/scream", 25,1, WeaknessCardManager.SCARING));
        CardManag.AllCards.Add(new Card("charm", "�����������", "Resources/Sprite/Cards/charm", 11, 2, WeaknessCardManager.CHARMING));
        CardManag.AllCards.Add(new Card("diplomatia", "������������� �����", "Resources/Sprite/Cards/diplomatia", 10, 0, WeaknessCardManager.DEMOCRATY));

        //CardManag.SpecialCards.Add(new Card("SpecialCards", "������������� �����", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        //CardManag.SpecialCards.Add(new Card("BOOST", "������������� �����", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        CardManag.SpecialCards.Add(new Card("random", "������������� �����", "Resources/Sprite/Cards/random", 0, 0, GetRandomWeaknessCard()));

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
