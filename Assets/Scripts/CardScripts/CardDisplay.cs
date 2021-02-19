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

    private Color tier1Color;
    private Color tier2Color;
    private Color tier3Color;
    private Color tier4Color;


    private void Awake()
    {
        itemNameText.text = card.itemName;
        artworkImage.sprite = card.artwork;

        tier1Color = new Color(255,255,255);
        tier2Color = new Color(176, 224, 166);
        tier3Color = new Color(240, 230, 152);
        tier4Color = new Color(221, 118, 116);

    }
    /*private void Start()
    {
        if (card.Tier == 1)
        {
            backgroundImage.color = tier1Color;
        }
        else if (card.Tier == 2)
        {
            backgroundImage.color = tier2Color;
        }
        else if (card.Tier == 3)
        {
            backgroundImage.color = tier3Color;
        }
        else if (card.Tier == 4)
        {
            backgroundImage.color = tier4Color;
        }
        else
        {
            Debug.Log("This tier does not exist");
        }
        
    }*/
}
