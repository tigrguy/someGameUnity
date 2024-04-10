using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Game
{
    public List<Card> EnemyDeck, EnemyHand,
                      PlayerDeck, PlayerHand;


    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();

        EnemyHand = new List<Card>();
        PlayerHand = new List<Card>();
    }


    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 2; i++)
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
        while (i++ <= 0)
            GiveCardToHand(deck, hand);
    }


    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;

        Card card = deck[0];

        //GameObject CardGO = Instantiate(CardPref, hand, false);
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
            while(TurnTime -- > 27)
            {
                TurnTimeText.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
                
            }
        }
        ChangeTurn();

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


}
