using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    //object references
    public PlayerGameLogic logic;
    public GameObject bodyObject;

    //card data
    private Card cardOne;
    private Card cardTwo;
    public Card[] playerCards;

    // chip data
    public int playerBuyIn;
    public int gameChipCount;
    [SerializeField] private int walletChipCount;

    void Start()
    {
        //get object references
        logic = GetComponent<PlayerGameLogic>();
        bodyObject = GetComponentInChildren<CapsuleCollider>().gameObject;

        //get cards from distributor
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
