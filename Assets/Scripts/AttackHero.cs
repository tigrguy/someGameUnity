using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackHero : MonoBehaviour, IDropHandler
{
    public enum HeroTyper
    {
        ENEMY,
        PLAYER
    }


    public HeroTyper Type;
    public GameManager GameManager;
    public CardSMovementcript CardSMovementcript;

    public void OnDrop(PointerEventData eventData)
    {

        if (!GameManager.IsPlayerTurn)
            return;

        CardSMovementcript cardScript = eventData.pointerDrag.GetComponent<CardSMovementcript>();
        //CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();

        if (cardScript != null) // Проверьте, существует ли компонент
        {
            CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();
            Debug.Log(cardScript.IsDraggable + "--"+"IsDraggable");

            if (card && Type == HeroTyper.ENEMY && cardScript.IsDraggable == true)
            {

                GameManager.WeaklessCard(card);
                GameManager.DamageHero(card, true);
            }
            
        }

    }

}
