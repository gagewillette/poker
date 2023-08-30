using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
        
    }
    
    public Suit suit;
    public int cardNum;

    public Card(Suit suit, int cardNum)
    {
        this.suit = suit;
        this.cardNum = cardNum;
    }

    public int getCardNum()
    {
        return this.cardNum;
    }

    public Suit getSuit()
    {
        return this.suit;
    }
    
    public string getSuitString()
    {
        switch (suit)
        {
            case Suit.Club:
                return "Club";
            case Suit.Heart:
                return "Heart";
            case Suit.Spade:
                return "Spade";
            case Suit.Diamond:
                return "Diamond";
        }

        throw new ApplicationException();
    }
}
