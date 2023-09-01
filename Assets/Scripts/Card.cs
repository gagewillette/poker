using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spade = 4
    }
    
    public Suit suit;
    public int cardNum;
    public GameObject cardObj;

    public Card(Suit suit, int cardNum /* add GameObject cardObj*/)
    {
        this.suit = suit;
        this.cardNum = cardNum;
        this.cardObj = cardObj;
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
    
    public string getNumString()
    {
        return this.cardNum < 10 ? "0" + this.cardNum.ToString() : this.cardNum.ToString();
    }
}
