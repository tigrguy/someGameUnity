using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public Card SelfCard;

    public TextMeshProUGUI Name;


    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

 
        Name.text = card.Name;
    }

    private void Start()
    {
        ShowCardInfo(CardManag.AllCards[transform.GetSiblingIndex()]);
    }
}
