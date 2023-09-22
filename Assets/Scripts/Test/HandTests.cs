using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HandTests : MonoBehaviour
{
    Card[] playerCards;
    private Card[] publicCards;

    private Card[] allCards;

    private int[] allCardNums;

    enum HandValues
    {
        RoyalFlush = 1,
        StraightFlush = 2,
        FourOfKind = 3,
        FullHouse = 4,
        Flush = 5,
        Straight = 6,
        ThreeOfKind = 7,
        TwoPair = 8,
        Pair = 9,
        HighCard = 10
    }

    public int checkHand(Card[] playerCard, Card[] publicCard)
    {
        playerCards = playerCard;
        publicCards = publicCard;

        allCards = publicCards.Concat(playerCards).ToArray();
        
        allCardNums = new int[]
        {
            allCards[0].getCardNum(), allCards[1].getCardNum(), allCards[2].getCardNum(), allCards[3].getCardNum(),
            allCards[4].getCardNum(), allCards[5].getCardNum(), allCards[6].getCardNum(),
        };
        
       /* if (checkRoyalFLush())
            return (int)HandValues.RoyalFlush;
        if (checkStraightFlush())
            return (int)HandValues.StraightFlush;
        if (checkFourOfKind())
            return (int)HandValues.FourOfKind;
        if (checkFullHouse())
            return (int)HandValues.FullHouse;
        if (checkFlush())
            return (int)HandValues.Flush;*/
        if (checkStraight())
            return (int)HandValues.Straight;
        /*if (checkThreeOfKind())
            return (int)HandValues.ThreeOfKind;
        if (checkTwoPair())
            return (int)HandValues.TwoPair;
        if (checkPair())
            return (int)HandValues.Pair;
        if (checkHighCard())
            return (int)HandValues.HighCard;*/

        return 11;
    }

    private bool checkRoyalFLush()
    {
        throw new System.NotImplementedException();
    }

    private bool checkStraightFlush()
    {
        throw new System.NotImplementedException();
    }

    private bool checkFourOfKind()
    {
        throw new System.NotImplementedException();
    }

    private bool checkFullHouse()
    {
        throw new System.NotImplementedException();
    }

    private bool checkFlush()
    {
        throw new System.NotImplementedException();
    }

    private bool checkStraight()
    {
        Array.Sort(allCardNums);

        int consecutiveCount = 0;
        
        for (int i = 0; i < allCardNums.Length - 1 ; i++)
        {
            int cur = allCardNums[i];

            if (cur + 1 == allCardNums[i + 1])
            {
                consecutiveCount++;
            }

        }

        if (consecutiveCount >= 5)
            return true;
        else
            return false;
    }

    private bool checkThreeOfKind()
    {
        throw new System.NotImplementedException();
    }

    private bool checkTwoPair()
    {
        throw new System.NotImplementedException();
    }

    private bool checkPair()
    {
        throw new System.NotImplementedException();
    }

    private bool checkHighCard()
    {
        throw new System.NotImplementedException();
    }
}