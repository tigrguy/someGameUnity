using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

<<<<<<< Updated upstream


=======
public enum WeaknessCardManager
{
    DEMOCRATY,
    CHARMING,
    SCARING,
    DAMAGE_BOOST
}
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        CardManag.AllCards.Add(new Card("diplomatia", "Resources/Sprite/Cards/diplomatia", 40,10));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/vodka", 11,20));
        CardManag.AllCards.Add(new Card("vodka", "Resources/Sprite/Cards/vodka", 15, 3));
        CardManag.AllCards.Add(new Card("scream", "Resources/Sprite/Cards/scream", 33, 40));

=======
        CardManag.AllCards.Add(new Card("diplomatia", "������� ���� �����������", "Resources/Sprite/Cards/diplomatia", 15,0, WeaknessCardManager.DEMOCRATY));
        CardManag.AllCards.Add(new Card("scream", "����������", "Resources/Sprite/Cards/scream", 25,1, WeaknessCardManager.SCARING));
        CardManag.AllCards.Add(new Card("charm", "�����������", "Resources/Sprite/Cards/charm", 11, 2, WeaknessCardManager.CHARMING));
        CardManag.AllCards.Add(new Card("diplomatia", "������������� �����", "Resources/Sprite/Cards/diplomatia", 10, 0, WeaknessCardManager.DEMOCRATY));

        //CardManag.SpecialCards.Add(new Card("SpecialCards", "������������� �����", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        //CardManag.SpecialCards.Add(new Card("BOOST", "������������� �����", "Resources/Sprite/Cards/diplomatia", 0, 0, WeaknessCardManager.DAMAGE_BOOST));
        CardManag.SpecialCards.Add(new Card("random", "������������� �����", "Resources/Sprite/Cards/random", 0, 0, GetRandomWeaknessCard()));
>>>>>>> Stashed changes

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
