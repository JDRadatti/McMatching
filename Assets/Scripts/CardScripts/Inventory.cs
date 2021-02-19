using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private GameObject cardManager;
    private CardManager cardScript;
    public GameObject card;
    private Image icon; 

    private void Awake()
    {
        cardManager = GameObject.Find("CardManagerObject");
        cardScript = cardManager.GetComponent<CardManager>();
        icon = this.GetComponent<Image>();
    }

    private void Start()
    {
        SetLockedColor();
    }

    public void SetLockedColor()
    { 
        if (cardScript.IsLocked(card))
        {
            icon.color = Color.gray;
        }
        else
        {
            icon.color = Color.white;
        }
    }
    public void Update()
    {
        SetLockedColor();
    }

    public void InventoryClickedOn()
    {
        if (!cardScript.IsCardInHand(card) && !cardScript.IsCardInQueue(card) && !cardScript.IsLocked(card))
        {
            Vector2 pos = cardScript.Discard();
            cardScript.AddCardToHand(card, pos);
        }
        else 
        {
            Debug.Log("Card is locked or already in hand");
        }

    }

}
