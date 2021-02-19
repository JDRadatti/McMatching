using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    #region Item_Vars
    public GameObject bread;
    public GameObject cheese;
    public GameObject tomato;
    public GameObject pizza;
    public GameObject potato;
    public GameObject chicken;
    public GameObject beef;
    public GameObject fryer;
    public GameObject grilledCheese;
    public GameObject hamburger;
    public GameObject lettuce;
    public GameObject fries;
    public GameObject salad;
    public GameObject cheeseburger;
    public GameObject deluxeCheeseburger;
    public GameObject deluxeHamburger;
    public GameObject deluxeChickenSando;
    public GameObject friedChicken;
    public GameObject friedChickenMeal;
    public GameObject chickenSalad;
    public GameObject chickenSandoMeal;
    public GameObject hamburgerMeal;
    public GameObject cheeseburgerMeal;
    public GameObject chickenSando;

    private RectTransform breadRT;
    private RectTransform cheeseRT;
    private RectTransform tomatoRT;
    private RectTransform pizzaRT;
    private RectTransform potatoRT;
    private RectTransform chickenRT;
    private RectTransform beefRT;
    private RectTransform fryerRT;
    private RectTransform grilledCheeseRT;
    private RectTransform hamburgerRT;
    private RectTransform lettuceRT;
    private RectTransform friesRT;
    private RectTransform saladRT;
    private RectTransform cheeseburgerRT;
    private RectTransform deluxeCheeseburgerRT;
    private RectTransform deluxeHamburgerRT;
    private RectTransform deluxeChickenSandoRT;
    private RectTransform friedChickenRT;
    private RectTransform friedChickenMealRT;
    private RectTransform chickenSaladRT;
    private RectTransform chickenSandoMealRT;
    private RectTransform hamburgerMealRT;
    private RectTransform cheeseburgerMealRT;
    private RectTransform chickenSandoRT;

    private Dictionary<GameObject, RectTransform> itemRTDictionary;
    private List<GameObject> unlockedObjects;
    public Text unlockedCounterText;

    private int numCards;
    #endregion

    #region Hand_Vars
    private Vector2 leftCardInHand;
    private Vector2 middleCardInHand;
    private Vector2 rightCardInHand;

    private Dictionary<GameObject, Vector2> hand;
    #endregion

    #region Queue_Vars
    private Vector2 leftCardInQueue;
    private Vector2 rightCardInQueue;
    private Vector2 combinedQueue;

    private Dictionary<GameObject, Vector2> queue;
    #endregion

    #region Unity_Methods
    void Start()
    {
        //Initialize Collection Types
        queue = new Dictionary<GameObject, Vector2>();
        hand = new Dictionary<GameObject, Vector2>();
        itemRTDictionary = new Dictionary<GameObject, RectTransform>();

        //Set Hand Postitions
        leftCardInHand = new Vector2(-250, -250);
        middleCardInHand = new Vector2(0, -250);
        rightCardInHand = new Vector2(250, -250);
        //Set Queue Postitions
        leftCardInQueue = new Vector2(-125, 150);
        rightCardInQueue = new Vector2(125, 150);
        combinedQueue = new Vector2(0, 150);

        //Get RectTransform for Item Objects
        breadRT = bread.gameObject.GetComponent<RectTransform>();
        tomatoRT = tomato.gameObject.GetComponent<RectTransform>();
        cheeseRT = cheese.gameObject.GetComponent<RectTransform>();
        pizzaRT = pizza.gameObject.GetComponent<RectTransform>();
        potatoRT = potato.gameObject.GetComponent<RectTransform>();
        chickenRT = chicken.gameObject.GetComponent<RectTransform>();
        beefRT = beef.gameObject.GetComponent<RectTransform>();
        fryerRT = fryer.gameObject.GetComponent<RectTransform>();
        friesRT = fries.gameObject.GetComponent<RectTransform>();
        hamburgerRT = hamburger.gameObject.GetComponent<RectTransform>();
        grilledCheeseRT = grilledCheese.gameObject.GetComponent<RectTransform>();
        lettuceRT = lettuce.gameObject.GetComponent<RectTransform>();
        saladRT = salad.gameObject.GetComponent<RectTransform>();
        cheeseburgerRT = cheeseburger.gameObject.GetComponent<RectTransform>();
        deluxeCheeseburgerRT = deluxeCheeseburger.gameObject.GetComponent<RectTransform>();
        deluxeHamburgerRT = deluxeHamburger.gameObject.GetComponent<RectTransform>();
        deluxeChickenSandoRT = deluxeChickenSando.gameObject.GetComponent<RectTransform>();
        friedChickenRT = friedChicken.gameObject.GetComponent<RectTransform>();
        friedChickenMealRT = friedChickenMeal.gameObject.GetComponent<RectTransform>();
        chickenSaladRT = chickenSalad.gameObject.GetComponent<RectTransform>();
        chickenSandoMealRT = chickenSandoMeal.gameObject.GetComponent<RectTransform>();
        hamburgerMealRT = hamburgerMeal.gameObject.GetComponent<RectTransform>();
        cheeseburgerMealRT = cheeseburgerMeal.gameObject.GetComponent<RectTransform>();
        chickenSandoRT = chickenSando.gameObject.GetComponent<RectTransform>();

        //Fill ItemRTDictionary
        itemRTDictionary.Add(bread, breadRT);
        itemRTDictionary.Add(cheese, cheeseRT);
        itemRTDictionary.Add(tomato, tomatoRT);
        itemRTDictionary.Add(pizza, pizzaRT);
        itemRTDictionary.Add(potato, potatoRT);
        itemRTDictionary.Add(chicken, chickenRT);
        itemRTDictionary.Add(beef, beefRT);
        itemRTDictionary.Add(fryer, fryerRT);
        itemRTDictionary.Add(grilledCheese, grilledCheeseRT);
        itemRTDictionary.Add(hamburger, hamburgerRT);
        itemRTDictionary.Add(fries, friesRT);
        itemRTDictionary.Add(lettuce, lettuceRT);
        itemRTDictionary.Add(salad, saladRT);
        itemRTDictionary.Add(cheeseburger, cheeseburgerRT);
        itemRTDictionary.Add(deluxeCheeseburger, deluxeCheeseburgerRT);
        itemRTDictionary.Add(deluxeHamburger, deluxeHamburgerRT);
        itemRTDictionary.Add(deluxeChickenSando, deluxeChickenSandoRT);
        itemRTDictionary.Add(friedChicken, friedChickenRT);
        itemRTDictionary.Add(friedChickenMeal, friedChickenMealRT);
        itemRTDictionary.Add(chickenSalad, chickenSaladRT);
        itemRTDictionary.Add(chickenSandoMeal, chickenSandoMealRT);
        itemRTDictionary.Add(hamburgerMeal, hamburgerMealRT);
        itemRTDictionary.Add(cheeseburgerMeal, cheeseburgerMealRT);
        itemRTDictionary.Add(chickenSando, chickenSandoRT);


        //Disabled Cards
        pizza.SetActive(false);
        bread.SetActive(false);
        //chicken.SetActive(false);
        beef.SetActive(false);
        potato.SetActive(false);
        cheese.SetActive(false);
        //tomato.SetActive(false);
        fryer.SetActive(false);
        hamburger.SetActive(false);
        grilledCheese.SetActive(false);
        //lettuce.SetActive(false);
        fries.SetActive(false);
        salad.SetActive(false);
        cheeseburger.SetActive(false);
        deluxeCheeseburger.SetActive(false);
        deluxeHamburger.SetActive(false);
        deluxeChickenSando.SetActive(false);
        friedChicken.SetActive(false);
        friedChickenMeal.SetActive(false);
        chickenSalad.SetActive(false);
        chickenSandoMeal.SetActive(false);
        hamburgerMeal.SetActive(false);
        cheeseburgerMeal.SetActive(false);
        chickenSando.SetActive(false);

        numCards = 23;

        //Set initial hand
        AddCardToPosition(chickenRT, leftCardInHand);
        AddCardToPosition(lettuceRT, middleCardInHand);
        AddCardToPosition(tomatoRT, rightCardInHand);

        //Fill hand dictionary
        hand.Add(chicken, leftCardInHand);
        hand.Add(lettuce, middleCardInHand);
        hand.Add(tomato, rightCardInHand);

        /*
        //Add initial objects to unlocked Objects
        unlockedObjects.Add(bread);
        unlockedObjects.Add(cheese);
        unlockedObjects.Add(tomato);
        unlockedObjects.Add(fryer);
        unlockedObjects.Add(potato);
        unlockedObjects.Add(beef);
        unlockedObjects.Add(chicken);
        unlockedObjects.Add(lettuce);
        */
        UpdateUnlockedCounterText();
    }

    private void Awake()
    {
        unlockedObjects = new List<GameObject>();

        //Add initial objects to unlocked Objects
        unlockedObjects.Add(bread);
        unlockedObjects.Add(cheese);
        unlockedObjects.Add(tomato);
        unlockedObjects.Add(fryer);
        unlockedObjects.Add(potato);
        unlockedObjects.Add(beef);
        unlockedObjects.Add(chicken);
        unlockedObjects.Add(lettuce);
    }
    #endregion


    //TODO: if failed combination --> move both cards back to hand
    //TODO: uncolor inventory when unlocked


    #region Refresh_Funcs
    private void Refresh()
    {
        //get new card from unlocked list
        //if the card is already in hand, get new card
        //put card in empty slot in the hand
        int length = unlockedObjects.Count;
        Vector2 posInHand = FindPositionInHand();

        for (int i = 0; i < length; i += 1)
        {
            int rand = Random.Range(0, length);
            GameObject card = unlockedObjects[rand];
            if (!hand.ContainsKey(card))
            {
                AddCardToHand(card, posInHand);
                break;
            }
        }

    }

    
    public void AddCardToHand(GameObject card, Vector2 posInHand)
    {
        if (!hand.ContainsKey(card))
        {
            AddCardToPosition(itemRTDictionary[card], posInHand);
            hand.Add(card, posInHand);
            card.SetActive(true);
        } else
        {
            Debug.Log("Cannot add card to hand... Card is already in the hand");
        }
         
    }

    public bool IsCardInHand(GameObject card)
    {
        if (hand.ContainsKey(card))
        {
            return true;
        }

        return false; 
    }
    public bool IsCardInQueue(GameObject card)
    {
        if (queue.ContainsKey(card))
        {
            return true;
        }

        return false;
    }

    //Discards a random card from the hand and returns the position in the hand that the card was located
    public Vector2 Discard()
    {
        int length = hand.Count;
        int rand = Random.Range(0, length);
        int i = 0;
        foreach (KeyValuePair<GameObject, Vector2> pair in hand)
        {
            if (i == rand)
            {
                hand.Remove(pair.Key);
                pair.Key.SetActive(false);
                return pair.Value;
            }
            i++;
        }

        return Vector2.zero;
    }

    public bool IsLocked(GameObject card)
    {
        if (unlockedObjects.Contains(card))
        {
            return false;
        }
        return true;
    }
    #endregion

    #region Combining_Funcs
    public void Combine()
    {
        if (SpaceInQueue())
        {
            Debug.Log("Cannot combine... The queue is not full");
        }
        else if (queue.Count == 2)
        {
            // Get the objects in the queue
            GameObject card1 = null;
            GameObject card2 = null;
            foreach (KeyValuePair<GameObject, Vector2> pair in queue)
            {
                if (pair.Value == leftCardInQueue)
                {
                    card1 = pair.Key;
                }
                else if (pair.Value == rightCardInQueue)
                {
                    card2 = pair.Key;
                }
                else { Debug.Log("Should not get here"); }
            }

            //Check if the cards in queue can combine
            if (card1 != null && card2 != null)
            {
                GameObject combinedCard = CanCombine(card1, card2);
                if (combinedCard)
                {
                    //perform combining logic
                    
                    AddCardToPosition(itemRTDictionary[combinedCard], combinedQueue);
                    card1.SetActive(false);
                    card2.SetActive(false);
                    combinedCard.SetActive(true);

                    //remove card1 and card2 from the queue
                    queue.Remove(card1);
                    queue.Remove(card2);

                    
                    // move combined card to hand
                    StartCoroutine(MoveFromCombinedToHand(combinedCard));

                    //handle unlocked objects
                    if (!unlockedObjects.Contains(combinedCard))
                    {
                        unlockedObjects.Add(combinedCard);
                    }
                    UpdateUnlockedCounterText();
                    Refresh();
                }
            } 

        }
        else
        {
            Debug.Log("Should never be here");
        }
    }

    
    private GameObject CanCombine(GameObject card1, GameObject card2)
    {
        if (card1 == bread && card2 == cheese || card1 == cheese && card2 == bread)
        {
            return grilledCheese; 
        }
        if (card1 == hamburger && card2 == cheese || card1 == cheese && card2 == hamburger)
        {
            return cheeseburger;
        }
        else if (card1 == bread && card2 == beef || card1 == beef && card2 == bread)
        {
            return hamburger;
        }
        else if (card1 == bread && card2 == chicken || card1 == chicken && card2 == bread)
        {
            return chickenSando;
        }
        else if (card1 == chickenSando && card2 == salad || card1 == salad && card2 == chickenSando)
        {
            return deluxeChickenSando;
        }
        else if (card1 == deluxeChickenSando && card2 == fries || card1 == fries && card2 == deluxeChickenSando)
        {
            return chickenSandoMeal;
        }
        else if (card1 == chicken && card2 == fryer || card1 == fryer && card2 == chicken)
        {
            return friedChicken;
        }
        else if (card1 == potato && card2 == fryer || card1 == fryer && card2 == potato)
        {
            return fries;
        }
        else if (card1 == friedChicken && card2 == fries || card1 == fries && card2 == friedChicken)
        {
            return friedChickenMeal;
        }
        else if (card1 == grilledCheese && card2 == beef || card1 == beef && card2 == grilledCheese)
        {
            return cheeseburger;
        }
        else if (card1 == cheeseburger && card2 == salad || card1 == salad && card2 == cheeseburger)
        {
            return deluxeCheeseburger;
        }
        else if (card1 == deluxeCheeseburger && card2 == fries || card1 == fries && card2 == deluxeCheeseburger)
        {
            return cheeseburgerMeal;
        }
        else if (card1 == hamburger && card2 == salad || card1 == salad && card2 == hamburger)
        {
            return deluxeHamburger;
        }
        else if (card1 == deluxeHamburger && card2 == fries || card1 == fries && card2 == deluxeHamburger)
        {
            return hamburgerMeal;
        }
        else if (card1 == lettuce && card2 == tomato || card1 == tomato && card2 == lettuce)
        {
            return salad;
        }
        else if (card1 == salad && card2 == chicken || card1 == chicken && card2 == salad)
        {
            return chickenSalad;
        }

        return null; 
    }

    private void UpdateUnlockedCounterText()
    {
        unlockedCounterText.text = unlockedObjects.Count + "/" + numCards;
    }
    #endregion

    #region Card_Movement_Funcs
    
    // Checks to make sure the move is valid and then performs the move 
    public void Movementhandler(GameObject card)
    {
        Vector2 moveTo = CalculateMove(card);
        if (moveTo != Vector2.zero)
        {
            MoveCard(itemRTDictionary[card], moveTo);
        }
    }

    //returns the position that the card should move. Returns vector2.zero if no moves are possible
    private Vector2 CalculateMove(GameObject obj)
    {
        if (hand.ContainsKey(obj))
        {
            if (SpaceInQueue())
            {
                Vector2 vect = FindPositionInQueue();
                queue.Add(obj, vect);
                hand.Remove(obj);
                return vect;
            }
            else
            {
                return Vector2.zero;
            }
        }
        else if (queue.ContainsKey(obj))
        {            
            Vector2 vect = FindPositionInHand();
            queue.Remove(obj);
            hand.Add(obj, vect);
            return vect;
        }
        else
        {
            return Vector2.zero;
        }

    }

    // Returns the position in queue that is empty. Returns Vector2.zero if no such value exists
    private Vector2 FindPositionInQueue()
    {
        if (!queue.ContainsValue(leftCardInQueue))
        {
            return leftCardInQueue;
        }
        else if (!queue.ContainsValue(rightCardInQueue))
        {
            return rightCardInQueue;
        }
        else
        {
            return Vector2.zero;
        }
    }

    private Vector2 FindPositionInHand()
    {
        if (!hand.ContainsValue(leftCardInHand))
        {
            return leftCardInHand;
        }
        else if (!hand.ContainsValue(rightCardInHand))
        {
            return rightCardInHand;
        }
        else if (!hand.ContainsValue(middleCardInHand))
        {
            return middleCardInHand;
        }
        else
        {
            return Vector2.zero;
        }

    }
    
    private bool SpaceInQueue()
    {
        if (queue.Count < 2)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }


    private void AddCardToPosition(RectTransform card, Vector2 pos)
    {
        card.localPosition = pos;
    }


    private void MoveCard(RectTransform card, Vector2 to)
    {

        StartCoroutine(MoveCardEnumerator(card, to));
    }

    #endregion

    #region Print_funcs
    private void PrintHand()
    {
        Debug.Log("NEWWWWW: ");
        foreach (KeyValuePair<GameObject, Vector2> card in hand)
        {
            Debug.Log("Key: " + card.Key.name + "Val: " + card.Value);
        }
    }

    private void PrintQueue()
    {
        foreach (KeyValuePair<GameObject, Vector2> card in queue)
        {
            Debug.Log("Key: " + card.Key.name + "Val: " + card.Value);
        }
    }
    #endregion

    #region Enumerators
    IEnumerator MoveCardEnumerator(RectTransform rt, Vector2 targetPos)
    {
        float step = 0;
        while (step < 1)
        {
            rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
            rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveFromCombinedToHand(GameObject combined)
    {
        Vector2 pos = FindPositionInHand();
        hand.Add(combined, pos);
        yield return new WaitForSeconds(1);
        MoveCard(itemRTDictionary[combined], pos);
        yield return null;
    }
    #endregion
}
