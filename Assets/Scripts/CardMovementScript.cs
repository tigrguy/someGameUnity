using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSMovementcript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent;
    public GameManager GameManager;
    public bool IsDraggable;

    public AudioSource SwapCard;
    void Awake()
    {
        MainCamera = Camera.allCameras[0];
        GameManager = FindObjectOfType<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = transform.parent;

        IsDraggable = DefaultParent.GetComponent<DropPlaceScript>().Type == FieldType.SELF_HAND &&
                      GameManager.IsPlayerTurn;
        SwapCard.Play();
        if (!IsDraggable)
            return;

        transform.SetParent(DefaultParent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData) 
    {
        //SwapCard.Play();
        if (!IsDraggable)
            return;
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offset;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (!IsDraggable)
            return;
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}