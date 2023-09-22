using System;
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

    private GameObject[] cardPrefabs;
    public Card[] allCards;

    private string path = "Black_PlayingCards_";
    private string endPath = "_00";

    //events
    public static Action FlopAction;
    public static Action TurnAction;
    public static Action RiverAction;
    

    //TEST VARIABLES
    public bool isFlop = false;
    public bool isTurn = false;
    public bool isRiver = false;
    //END TEST VARIABLES
    


    void Start()
    {
        cardLocations = GameObject.Find("PublicCards").GetComponent<CardPositions>().cardPositions;

        int i = 0;
        foreach (var cur in flop)
        {
            flop[i] = CardDistributor.getCard();
            i++;
        }

        turn = CardDistributor.getCard();
        river = CardDistributor.getCard();

        allCards = new Card[] { flop[0], flop[1], flop[2], turn, river };

        Debug.Log("PUblic card Spanwer: " + allCards.ToCommaSeparatedString());
        
        cardPrefabs = getCardPrefabs();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnFlop();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnTurn();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnRiver();
        }
    }

    private GameObject[] getCardPrefabs()
    {
        GameObject[] arr = new GameObject[5];
        int i = 0;
        foreach (var cur in allCards)
        {
            arr[i] = Resources.Load<GameObject>(path + cur.getSuitString() + cur.getNumString() + endPath);
            i++;
        }

        return arr;
    }

    void SpawnFlop()
    {
        if (isFlop) return;
        
        FlopAction?.Invoke();
        
        for (int i = 0; i < 3; i++)
        {
            GameObject prevSpawn = Instantiate(cardPrefabs[i], cardLocations[i].position, cardLocations[i].rotation);
            prevSpawn.transform.SetParent(cardLocations[i], true);
        }

        isFlop = true;
    }

    void SpawnTurn()
    {
        if (isTurn) return;
        if (!isFlop) return;

        TurnAction?.Invoke();
        
        GameObject prevSpawn = Instantiate(cardPrefabs[3], cardLocations[3].position, cardLocations[3].rotation);
        prevSpawn.transform.SetParent(cardLocations[3], true);
        isTurn = true;
    }

    void SpawnRiver()
    {
        if (isRiver) return;
        if (!isFlop || !isTurn) return;

        RiverAction.Invoke();
        
        GameObject prevSpawn = Instantiate(cardPrefabs[4], cardLocations[4].position, cardLocations[4].rotation);
        prevSpawn.transform.SetParent(cardLocations[4], true);
        isRiver = true;
    }
}