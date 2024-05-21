using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_FIELD,
    ENEMY_HAND
}

public class DropPlaceScript : MonoBehaviour, IDropHandler{

    public FieldType Type;
    public CardInfoScript CardInfoScript;
    public GameManager GameManager;
    public EmotionDiceTurn EmotionDiceTurn;
    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card)
            card.DefaultParent = transform;
    }





}