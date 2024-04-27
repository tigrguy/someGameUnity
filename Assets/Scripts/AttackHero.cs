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
    public enum Weakness
    {
        DEMOCRATY,
        CHARMING,
        SCARING
    }

    public HeroTyper Type;
    public GameManager GameManager;
    public Weakness weakness = Weakness.DEMOCRATY;


    public void OnDrop(PointerEventData eventData)
    {
        if (!GameManager.IsPlayerTurn)
            return;


        CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();

        if (card && Type == HeroTyper.ENEMY)
        {
            GameManager.DamageHero(card, true);

        }


    }

}
