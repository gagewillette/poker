using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerClass : MonoBehaviour
{
    //object references
    [HideInInspector]
    public PlayerGameLogic logic;
    [HideInInspector]
    public GameObject bodyObject;

    public bool isBigBlind;
    public bool isSmallBlind;

    [SerializeField] private int playerNum;

    private Card cardOne;
    private Card cardTwo;
    
    private Card[] playerCards;
    
    // chip data
    public int playerBuyIn;
    [HideInInspector] public int gameChipCount;
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

    
