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


    public void OnDrop(PointerEventData eventData)
    {
        if (!GameManager.IsPlayerTurn)
            return;


        CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();

        if (card && Type == HeroTyper.ENEMY)
        {

            GameManager.WeaklessCard(card);
            GameManager.DamageHero(card, true);

        }

    }

}
