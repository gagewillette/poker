using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PlayerGameLogic logic;
    public GameObject bodyObject;
    
    private Card cardOne;
    private Card cardTwo;
    public Card[] playerCards = new Card[2];

    void Start()
    {
        logic = GetComponent<PlayerGameLogic>();
        
        cardOne = CardDistributor.getCard();
        cardTwo = CardDistributor.getCard();
        playerCards[0] = cardOne;
        playerCards[1] = cardTwo;
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