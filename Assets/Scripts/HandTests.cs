using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        
        allCards = playerCards.Concat(publicCards).ToArray();
        
        
       
        allCardNums = new int[]
        {
            allCards[0].getCardNum(), allCards[1].getCardNum(), allCards[2].getCardNum(), allCards[3].getCardNum(),
            allCards[4].getCardNum(), allCards[5].getCardNum(), allCards[6].getCardNum(),
        };
        
        if (checkRoyalFLush())
            return (int)HandValues.RoyalFlush;
        if (checkStraightFlush())
            return (int)HandValues.StraightFlush;
        if (checkFourOfKind())
            return (int)HandValues.FourOfKind;
        if (checkFullHouse())
            return (int)HandValues.FullHouse;
        if (checkFlush())
            return (int)HandValues.Flush;
        if (checkStraight())
            return (int)HandValues.Straight;
        if (checkThreeOfKind())
            return (int)HandValues.ThreeOfKind;
        if (checkTwoPair())
            return (int)HandValues.TwoPair;
        if (checkPair())
            return (int)HandValues.Pair;
        if (checkHighCard())
            return (int)HandValues.HighCard;

        return 11;
    }

    private bool checkRoyalFLush()
    {
        return allCards.GroupBy(c => c.getSuit())
            .Any(group => group.Count() >= 5 && 
                          group.Any(c => c.getCardNum() == 10) &&
                          group.Any(c => c.getCardNum() == 11) &&
                          group.Any(c => c.getCardNum() == 12) &&
                          group.Any(c => c.getCardNum() == 13) &&
                          group.Any(c => c.getCardNum() == 1));
        
    }

    private bool checkStraightFlush()
    {
        // First, sort the cards by number.
        var cards = allCards.OrderBy(c => c.getCardNum()).ToList();

        // Check for consecutive cards of the same suit
        for (int i = 0; i <= cards.Count - 5; i++) // only go up to the third-to-last card
        {
            if (cards[i].getSuit() == cards[i + 1].getSuit() &&
                cards[i].getSuit() == cards[i + 2].getSuit() &&
                cards[i].getSuit() == cards[i + 3].getSuit() &&
                cards[i].getSuit() == cards[i + 4].getSuit() &&
                cards[i].getCardNum() == cards[i + 1].getCardNum() - 1 &&
                cards[i].getCardNum() == cards[i + 2].getCardNum() - 2 &&
                cards[i].getCardNum() == cards[i + 3].getCardNum() - 3 &&
                cards[i].getCardNum() == cards[i + 4].getCardNum() - 4)
            {
                return true; // straight flush found
            }
        }
        return false;
    }

    private bool checkFourOfKind()
    {
        return allCards.GroupBy(c => c.getCardNum())
            .Any(group => group.Count() == 4);
    }

    private bool checkFullHouse()
    {
        var grouped = allCards.GroupBy(c => c.getCardNum()).OrderByDescending(group => group.Count()).ToList();

        // Ensure that there's at least one group of 3 and another group of 2
        return grouped.Count >= 2 && grouped[0].Count() == 3 && grouped[1].Count() == 2;
    }

    private bool checkFlush()
    {
        return allCards.GroupBy(c => c.getSuit()).Any(group => group.Count() >= 5);
    }

    private bool checkStraight()
    {
        var sortedNumbers = allCards.Select(c => c.getCardNum()).Distinct().OrderBy(n => n).ToList();
        
        for (int i = 0; i <= sortedNumbers.Count - 5; i++)
        {
            // Check for 5 consecutive numbers
            if (sortedNumbers[i] + 1 == sortedNumbers[i + 1] &&
                sortedNumbers[i] + 2 == sortedNumbers[i + 2] &&
                sortedNumbers[i] + 3 == sortedNumbers[i + 3] &&
                sortedNumbers[i] + 4 == sortedNumbers[i + 4])
            {
                return true;
            }
        }

        // Special case for 10, J, Q, K, A
        if (sortedNumbers.Contains(1) && sortedNumbers.Contains(10) &&
            sortedNumbers.Contains(11) && sortedNumbers.Contains(12) && sortedNumbers.Contains(13))
        {
            return true;
        }

        return false;
    }

    private bool checkThreeOfKind()
    {
        return allCards.GroupBy(c => c.getCardNum()).Any(group => group.Count() == 3);
    }

    private bool checkTwoPair()
    {
        var pairs = allCards.GroupBy(c => c.getCardNum())
            .Where(group => group.Count() == 2)
            .ToList();

        return pairs.Count >= 2;
    }

    private bool checkPair()
    {
        var pairs = allCards.GroupBy(c => c.getCardNum())
            .Where(group => group.Count() == 2)
            .ToList();

        return pairs.Count == 1;
    }

    private bool checkHighCard()
    {
        int highCard = playerCards.OrderByDescending(c => c.getCardNum()).First().getCardNum();

        if (highCard == 1 || highCard >= 10)
            return true;
        else
            return false;
    }
}