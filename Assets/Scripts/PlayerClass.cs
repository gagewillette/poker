using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    //object references
    public PlayerGameLogic logic;
    public GameObject bodyObject;

    public bool isBigBlind;
    public bool isSmallBlind;

    [SerializeField] private int playerNum;

    private Card cardOne;
    private Card cardTwo;
    public Card[] playerCards;

    //THIS IS STATIC, IT CONTAINS EVERY PLAYER OBJECT AND THEIR CARDS
    private Dictionary<GameObject, Card[]> playerCardsDict;

    // chip data
    public int playerBuyIn;
    [HideInInspector] public int gameChipCount;
    [SerializeField] private int walletChipCount;

    void Start()
    {
        //get object references
        logic = GetComponent<PlayerGameLogic>();
        bodyObject = GetComponentInChildren<CapsuleCollider>().gameObject;

        playerCardsDict = GameObject.Find("Singletons").GetComponent<PlayerArray>().getPlayerCardDict();

        //get cards from distributor
        cardOne = CardDistributor.getCard();
        cardTwo = CardDistributor.getCard();
        playerCards = new[] { cardOne, cardTwo };
        gameChipCount = playerBuyIn;
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

    public int getPlayerNum()
    {
        return playerNum;
    }

}

    
