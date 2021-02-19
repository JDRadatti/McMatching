using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;

    public Text itemNameText;
    public Image artworkImage;
    public Image backgroundImage;

    private void Awake()
    {
        itemNameText.text = card.itemName;
        artworkImage.sprite = card.artwork;

    }
    
}
