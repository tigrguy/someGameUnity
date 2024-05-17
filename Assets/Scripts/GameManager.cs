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
        int countCard = 0;
        for (int i = 0; i < 10; i++)
        {
            countCard += 1;
            list.Add(CardManag.AllCards[Random.Range(0, CardManag.AllCards.Count)]);
            if (countCard == 2)
            {
                list.Add(CardManag.SpecialCards[Random.Range(0, CardManag.SpecialCards.Count)]);
            }
        }


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

    //public int PlayerMana = 3;
    //public TextMeshProUGUI PlayerManaTxt;

    public float PlayerHP, EnemyHP;
    public TextMeshProUGUI PlayerHPTxt, EnemyHPTxt;

    public GameObject ResultGO;
    public GameObject ResultGOLose;
    public GameObject StopPanel;

    public AudioSource panelSoundWin;
    public AudioSource panelSoundLose;
    public AudioSource panelSoundDamage;

    public List<CardInfoScript> PlayerHandCard = new List<CardInfoScript>(),
                                 EnemyHandCard = new List<CardInfoScript>();



    public WeaknessCardManager weaknessBUFF;
    public WeaknessCardManager weaknessDeBUFF;


    public int extraDamage = 1;
    public Image extraDamageTurn;

    


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
        GenerateRandomValue();
        //ShowMana();
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
    public int randomNumber;
    public EmotionDiceTurn EmotionDiceTurn;
    public void GenerateRandomValue()
    {
        // Генерируем случайное число от 0 до 2
        randomNumber = Random.Range(0, 3);
        EmotionDiceTurn imageUpdater = FindObjectOfType<EmotionDiceTurn>();

        imageUpdater.UpdateImage(randomNumber);

        Debug.Log("Номер кости " + randomNumber);
    }
    

    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeText.text = TurnTime.ToString();

        if (IsPlayerTurn)
        {
            
            while (TurnTime -- > 0)
            {
                TurnTimeText.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);

            }
        }
        else
        {
            while(TurnTime -- > Random.Range(24, 29))
            {
                StopPanel.SetActive(true);
                TurnTimeText.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
            if (EnemyHandCard.Count > 0)
                EnemyTurn(EnemyHandCard);
            PlayerHP = PlayerHP - Random.Range(8, 15);
            panelSoundDamage.Play();
            UpdateHealthBarPlayer();
            ChecnkForResultLose();
            ShowHP();
            ChecnkForResult();
            StopPanel.SetActive(false);
            extraDamageTurns--;

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
        {
            GiveNewCard();
            //PlayerMana = Random.Range(1, 4);
            GenerateRandomValue();
            //ShowMana();
        }

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


    public int extraDamageTurns;
    //public Sprite extraDamageTurn;

    public void WeaklessCard(CardInfoScript card)
    {
        if (card.SelfCard.WeaknessCardManager == WeaknessCardManager.SCARING)
        {
            weaknessBUFF = card.SelfCard.WeaknessCardManager;
        }
        if (card.SelfCard.WeaknessCardManager == WeaknessCardManager.DAMAGE_BOOST)
        {
            extraDamageTurns = 2;
            Debug.Log(4);
        }
    }

    public void DamageHero (CardInfoScript card, bool isEnemyArracked)
    {
        if (isEnemyArracked)
        {

            //EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue);

            //EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue); //оригинал строчка
            if (card.SelfCard.WeaknessCardManager == weaknessBUFF && extraDamageTurns == 0)
            {
                EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack*2, 0, int.MaxValue);
                Debug.Log(card.SelfCard.Attack * 2);
                Debug.Log(1);
            }
            if (card.SelfCard.WeaknessCardManager == weaknessDeBUFF && extraDamageTurns == 0 )
            {
                EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack/2, 0, int.MaxValue);
                Debug.Log(card.SelfCard.Attack / 2);
                Debug.Log(2);
            }
            if (card.SelfCard.WeaknessCardManager != weaknessDeBUFF && card.SelfCard.WeaknessCardManager != weaknessBUFF && extraDamageTurns == 0)
            {
                EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue);
                Debug.Log(card.SelfCard.Attack);
                Debug.Log(3);
            }
            //////////////// ТОЧНО ТАКОЙ ЖЕ КОД НО ДЛЯ БАФФА УРОНА!!!!!!!!!
            //WeaklessCard(card);

            if (extraDamageTurns != 0 && extraDamageTurns < 0)
            {
                Debug.Log(extraDamageTurns + "осталось ходов");
                if (extraDamageTurns != 0 && card.SelfCard.WeaknessCardManager == weaknessBUFF && extraDamageTurns != 0)
                {
                    EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack * 4, 0, int.MaxValue);
                    Debug.Log(card.SelfCard.Attack * 4 + "BUFF дипломатии");
                    Debug.Log(extraDamageTurns + "осталось ходов");
                }
                if (extraDamageTurns != 0 && card.SelfCard.WeaknessCardManager == weaknessDeBUFF && extraDamageTurns != 0)
                {
                    EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack, 0, int.MaxValue);
                    Debug.Log(card.SelfCard.Attack + "BUFF обычной карты");
                    Debug.Log(extraDamageTurns + "осталось ходов");
                }
                if (extraDamageTurns != 0 && card.SelfCard.WeaknessCardManager != weaknessDeBUFF && card.SelfCard.WeaknessCardManager != weaknessBUFF)
                {
                    EnemyHP = Mathf.Clamp(EnemyHP - card.SelfCard.Attack * 2, 0, int.MaxValue);
                    Debug.Log(card.SelfCard.Attack * 2 + "дебафф карты");
                    Debug.Log(extraDamageTurns + "осталось ходов");
                }
            }
            panelSoundDamage.Play();
            Destroy(card.gameObject);
            UpdateHealthBarEnemy();
        }
        else
        {
            //PlayerHP = Mathf.Clamp(PlayerHP - card.SelfCard.Attack, 0, int.MaxValue); это правильный вариант
            //PlayerHP = Mathf.Clamp(PlayerHP - Random.Range(4, 10), 0, int.MaxValue);
            Destroy(card.gameObject);
        }
        ShowHP();
        ChecnkForResultLose();
        ShowHP();
        ChecnkForResult();
    }

    public float maxHealth = 100;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float fillSpeed;
    public void UpdateHealthBarPlayer()
    {
        float targetFillAmount = PlayerHP / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        //healthBarFill.DOFillAmount(targetFillAmount,fillSpeed);


    }
    [SerializeField] private Image healthBarFillEnemy;
    [SerializeField] private TextMeshProUGUI healthTextEnemy;
    [SerializeField] private float fillSpeedEnemy;

    public void UpdateHealthBarEnemy()
    {
        float targetFillAmount = EnemyHP / maxHealth;
        healthBarFillEnemy.fillAmount = targetFillAmount;
        //healthBarFill.DOFillAmount(targetFillAmount,fillSpeed);


    }

    //void ShowMana()
    //{
    //    PlayerManaTxt.text = PlayerMana.ToString();
    //}

    public Button LoadingMenu;

    public Button LoadingScene;


    void ChecnkForResult()
    {
        if (EnemyHP == 0)
        {
            ResultGO.SetActive(true);

            StopAllCoroutines();
            panelSoundWin.Play();

        }
    }
    public Button LoadingMenuLose;
    void ChecnkForResultLose()
    {
        if (PlayerHP <= 0)
        {
            PlayerHP = 0;
            ResultGOLose.SetActive(true);

            StopAllCoroutines();
            panelSoundLose.Play();


        }
    }

}
