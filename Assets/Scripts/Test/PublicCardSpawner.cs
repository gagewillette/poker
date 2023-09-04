using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PublicCardSpawner : MonoBehaviour
{
    private Card[] flop = new Card[3];
    private Card turn;
    private Card river;

    private Transform[] cardLocations;

    private Object[] cardPrefabs = new Object[5];

    private string path = "Prefab/Black_PlayingCards_";
    private string endPath = "_00";
    
    
    //TEST VARIABLES
    public bool isFlop = false;
    public bool isTurn = false;
    public bool isRiver= false;
    //END TEST VARIABLES
    
    
    void Start()
    {
        cardLocations  = GameObject.Find("PublicCards").GetComponent<CardPositions>().cardPositions;
        
        
        for (int i = 0; i < 3; i++)
        {
            flop[i] = CardDistributor.getCard();
        }

        turn = CardDistributor.getCard();
        river = CardDistributor.getCard();

        //DEBUG
        foreach (var cur in flop)
        {
            Debug.Log(cur.getSuit() + " " + cur.getCardNum());
        }
        Debug.Log(turn.getSuit() + " " + turn.getCardNum());
        Debug.Log(river.getSuit() + " " + river.getCardNum());
        //END DEBUG

        getCardPrefabs();
        Debug.Log(cardPrefabs.ToCommaSeparatedString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < 3; i++)
            {
                Object prevSpawn = Instantiate(cardPrefabs[i], cardLocations[i].position, cardLocations[i].rotation);
            }
        }

    }

    private void getCardPrefabs()
    {
        if (!isFlop) return;

        for (int i = 0; i < 3; i++)
        {
            cardPrefabs[i] = Resources.Load<Object>(path + flop[i].getSuitString() + flop[i].getNumString() + endPath);
        }
    }

}
