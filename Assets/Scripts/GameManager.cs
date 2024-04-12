using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;
using UnityEditor;

public class Game
{
    public List<Card> EnemyDeck, PlayerDeck;
                       


    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();

        //EnemyHand = new List<Card>();
        //PlayerHand = new List<Card>();
    }


    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 10; i++)
            list.Add(CardManag.AllCards[Random.Range(0, CardManag.AllCards.Count)]);
        return list;
    }


}





public class GameManager : MonoBehaviour
{
    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand;
    public GameObject CardPref;
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeText;
    public Button EndTurnButton;


    public int PlayerHP, EnemyHP;
    public TextMeshProUGUI PlayerHPTxt, EnemyHPTxt;

    public GameObject ResultGO;
    public TextMeshProUGUI ResultTxt;

    public List<CardInfoScript> PlayerHandCard = new List<CardInfoScript>(),
                                 EnemyHandCard = new List<CardInfoScript>();


    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }


    void Start()
    {
        Turn = 0;
        CurrentGame = new Game();

        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);

        StartCoroutine(TurnFunc());
    }


    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ <= 1)
            GiveCardToHand(deck, hand);
    }


    void GiveCardToHand(List<Card> deck, Transform hand)
    {
 
        if (deck.Count == 0)
            return;

        Card card = deck[0];

        GameObject CardGO = Instantiate(CardPref, hand, false);
        if (hand == EnemyHand)
        {
            CardGO.GetComponent<CardInfoScript>().HideCardInfo(card);
            EnemyHandCard.Add(CardGO.GetComponent<CardInfoScript>());
        }
        else
        {
            CardGO.GetComponent<CardInfoScript>().ShowCardInfo(card);
            PlayerHandCard.Add(CardGO.GetComponent<CardInfoScript>());
        }

        deck.RemoveAt(0);

    }

    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeText.text = TurnTime.ToString();

        if (IsPlayerTurn)
        {
            while(TurnTime -- > 0)
            {
                TurnTimeText.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
                
            }
        }
        else
        {
            while(TurnTime -- > Random.Range(24, 29))
            {
                TurnTimeText.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
            if (EnemyHandCard.Count > 0)
                EnemyTurn(EnemyHandCard);
            PlayerHP = PlayerHP - Random.Range(4, 10);
            ShowHP();
            ChecnkForResult();

        }
        ChangeTurn();

    }


    void EnemyTurn(List<CardInfoScript> cards)
    {
        int count = cards.Count == 1 ? 1 :
                    Random.Range(0, cards.Count);
    }


    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;

        EndTurnButton.interactable = IsPlayerTurn;

        if (IsPlayerTurn)
            GiveNewCard();

        StartCoroutine(TurnFunc());
    }

    void GiveNewCard()
    {
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
    }


    void ShowHP()
    {
        EnemyHPTxt.text = EnemyHP.ToString();
        PlayerHPTxt.text = PlayerHP.ToString();
    }

    
    public void DamageHero (CardInfoScript card, bool isEnemyArracked)
    {
        if (isEnemyArracked)
        {
            EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue);
            Destroy(card.gameObject);
        }
        else
        {
            //PlayerHP = Mathf.Clamp(PlayerHP - card.SelfCard.Attack, 0, int.MaxValue); это правильный вариант
            //PlayerHP = Mathf.Clamp(PlayerHP - Random.Range(4, 10), 0, int.MaxValue);
            Destroy(card.gameObject);
        }
        ShowHP();
        ChecnkForResult();
    }

    void ChecnkForResult()
    {
        if (EnemyHP == 0 || PlayerHP == 0)
        {
            ResultGO.SetActive(true);
            StopAllCoroutines();

            if (EnemyHP == 0)
            {
                ResultTxt.text = "WIIIIIIIIN";
            }
            else
            {
                ResultTxt.text = "lose(";
            }

        }
    }

}
