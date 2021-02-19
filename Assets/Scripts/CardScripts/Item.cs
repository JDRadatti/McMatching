using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameObject cardManager;
    private CardManager cardScript;
    private ObjectShake objShake;

    private void Awake()
    {
        cardManager = GameObject.Find("CardManagerObject"); 
        cardScript = cardManager.GetComponent<CardManager>();
        objShake = GetComponent<ObjectShake>();
    }

    public void RunFailedCombineAnimation()
    {
        //anim.SetBool("PlayShake", true);
        objShake.Shake();
    }

    public void ClickedOnTomato()
    {
        cardScript.Movementhandler(this.gameObject);
    }

    public void ClickedOnBread()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnCheese()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnPizza()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnPotato()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChicken()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnBeef()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnFryer()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnHamburger()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnGrilledCheese()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnLettuce()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnFries()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChickenSando()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChickenSandoMeal()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChickenNuggets()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnSalad()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnCheeseburger()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnDeluxeCheeseburger()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnDeluxeHamburger()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnDeluxeChickenSando()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnHambrgerMeal()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnCheeseburgerMeal()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChickenSalad()
    {
        cardScript.Movementhandler(this.gameObject);
    }
    public void ClickedOnChickenNuggetMeal()
    {
        cardScript.Movementhandler(this.gameObject);
    }

    
}
