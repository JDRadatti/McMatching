using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "Card")]
public class Card : ScriptableObject
{
    #region Card_Atributes
    public string itemName;

    public Sprite artwork;

    public int Tier;
    #endregion

}
