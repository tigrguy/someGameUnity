using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public Card SelfCard;
    public Image Logo;
    public TextMeshProUGUI Name,Opis, Attack, Manacost;
    public TextMeshProUGUI WeaknessCardManager;



    public void HideCardInfo(Card card)
    {
        //SelfCard = card;
        //Name.text = "";
        ShowCardInfo(card);
    }
    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

        Logo.sprite = Resources.Load<Sprite>("Sprite/Cards/" + card.Name);
        Logo.preserveAspect = true;

        Name.text = card.Name;
        Opis.text = SelfCard.Opis.ToString();
        Attack.text = SelfCard.Attack.ToString();
        Manacost.text = SelfCard.Manacost.ToString();
        WeaknessCardManager.text = SelfCard.WeaknessCardManager.ToString();
    }

    private void Start()
    {
       // ShowCardInfo(CardManag.AllCards[transform.GetSiblingIndex()]);

    }
}
