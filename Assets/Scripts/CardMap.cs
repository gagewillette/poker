using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CardMap : MonoBehaviour
{
    [SerializeField] public static Dictionary<int, Card> cardMap = new Dictionary<int, Card>();
    
    private void Start()
    {
        string[] bruh = Directory.GetFiles("Assets/Playing Cards/Resource/Prefab/BackColor_Black");
        
        int i = 0;
        foreach (string cur in bruh)
        {
            //filter
            if (cur.Contains(".meta")) continue;
            if (!cur.Contains("PlayingCards")) continue ;
            if (cur.Contains("Joker")) continue;
            try
            {
                //add to cardmap
                cardMap.Add(i, new Card(getSuit(cur), getNum(cur)));
            }
            catch (ArgumentException e){}

            ;
            i++;
        }
        Debug.Log(cardMap.ToCommaSeparatedString());

        for (int j = 1; j < cardMap.Count + 1; j++)
        {
            Debug.Log(cardMap[j].getSuitString() + "  " + cardMap[j].getCardNum());
        }

    }


    private Card.Suit getSuit(string fileName)
    {
        string[] splits = fileName.Split("_");
        foreach (string cur in splits)
        {
            if (cur.Contains("Spade"))
                return Card.Suit.Spade;
            else if (cur.Contains("Diamond"))
                return Card.Suit.Diamond;
            else if (cur.Contains("Heart"))
                return Card.Suit.Heart;
            else if (cur.Contains("Club"))
                return Card.Suit.Club;
        }

        throw new ArgumentException("Not found");
    }

    private int getNum(string fileName)
    {
        string[] splits = fileName.Split("_");
        string numString = splits[3];

        return Int32.Parse(numString.Substring(numString.Length - 2));
    }
}
