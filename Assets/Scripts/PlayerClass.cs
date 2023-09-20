using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public PlayerGameLogic logic;
    public GameObject bodyObject;
    
    private Card cardOne;
    private Card cardTwo;
    public Card[] playerCards;

    void Start()
    {
        logic = GetComponent<PlayerGameLogic>();
        bodyObject = GetComponentInChildren<CapsuleCollider>().gameObject;
        
        cardOne = CardDistributor.getCard();
        cardTwo = CardDistributor.getCard();


        playerCards = new[] { cardOne, cardTwo };
    }


    public Card getCardOne()
    {
        return cardOne;
    }

    public Card getCardTwo()
    {
        return cardTwo;
    }

    public Card[] getCards()
    {
        return playerCards;
    }

    public GameObject getPlayerObject()
    {
        return gameObject;
    }

    public GameObject getPlayerBody()
    {
        return bodyObject;
    }
}
