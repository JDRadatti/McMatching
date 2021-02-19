using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    #region Item_Vars
    public GameObject bread;
    public GameObject cheese;
    public GameObject tomato;
    public GameObject pizza;

    private RectTransform breadRT;
    private RectTransform cheeseRT;
    private RectTransform tomatoRT;
    private RectTransform pizzaRT;

    private Dictionary<GameObject, RectTransform> itemRTDictionary;
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

        //Fill ItemRTDictionary
        itemRTDictionary.Add(bread, breadRT);
        itemRTDictionary.Add(cheese, cheeseRT);
        itemRTDictionary.Add(tomato, tomatoRT);
        itemRTDictionary.Add(pizza, pizzaRT);

        
        //Disabled Cards
        pizza.SetActive(false);


        //Set initial hand
        AddCardToPosition(breadRT, leftCardInHand);
        AddCardToPosition(cheeseRT, middleCardInHand);
        AddCardToPosition(tomatoRT, rightCardInHand);

        //Fill hand dictionary
        hand.Add(bread, leftCardInHand);
        hand.Add(cheese, middleCardInHand);
        hand.Add(tomato, rightCardInHand);
        
    }

    #endregion


    //TODO: if failed combination --> move both cards back to hand
    //TODO: add refresh (cards shake and then it asks you to select a card and when you do it replaces it with random card) or could just be a clean sweep with random cards
    //TODO: 
    //TODO: finish CanCombine
    //TODO: if CanCombine, move both to middle, disable the cards just combined, place and enable the new card, move the new card to the hand, clear queue, add another card to hand

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
                    StartCoroutine(MoveFromCombinedToHand(combinedCard));
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
        if (card1 == tomato && card2 == bread || card2 == tomato && card1 == bread)
        {
            return pizza; 
        }
        return null; 
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
        yield return new WaitForSeconds(1);
        Vector2 pos = FindPositionInHand();
        MoveCard(itemRTDictionary[combined], pos);
        hand.Add(combined, pos);
        yield return null;
    }
    #endregion
}
