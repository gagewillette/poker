using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Blinds : MonoBehaviour
{
    // blind player indicies
    private int smallBlindPlayerIndex = 1;
    private int bigBlindPlayerIndex = 0;

    //blind values
    public int bigBlind, smallBlind;

    //blind player objects
    private GameObject smallBlindObj, bigBlindObj;
    
    //reference to pokergamelogic
    private PokerGameLogic gameLogic;

    //state
    private GameStateManager stateManager;

    //array reference
    private PlayerArray arraySingleton;

    //player dict
    private GameObject[] playerArray;

    void Awake()
    {
        objectRefs();
        setEvents();
    }

    private void Start()
    {
        setBlinds();
    }


    void setBlinds()
    {
        int totalChips = 0;
        foreach (GameObject cur in gameLogic.players)
        {
            Debug.LogError(cur.GetComponent<PlayerClass>().playerBuyIn);
            totalChips += cur.GetComponent<PlayerClass>().playerBuyIn;
        }

        bigBlind = totalChips / gameLogic.players.Count / 20;
        smallBlind = totalChips / gameLogic.players.Count / 30;
        

        foreach (GameObject cur in playerArray)
        {
            switch (checkBlinds(cur))
            {
                case 0:
                    break;
                case 1:
                    smallBlindObj = cur;
                    break;
                case 2:
                    bigBlindObj = cur;
                    break;
            }
        }
        
    }


    private void SubtractBlinds()
    {
        //get player buy ins and subtract that amount
        smallBlindObj.GetComponent<PlayerClass>().playerBuyIn -= smallBlind;
        bigBlindObj.GetComponent<PlayerClass>().playerBuyIn -= bigBlind;
        
        //move blind indicies to next player
        nextPlayer();
    }
    
    //utils
    void objectRefs()
    {
        stateManager = gameLogic.GetComponent<GameStateManager>();
        gameLogic = gameObject.GetComponent<PokerGameLogic>();
        arraySingleton = GameObject.Find("Singletons").GetComponent<PlayerArray>();
    }

    void setEvents()
    {
        GameStateManager.onPreFlop += SubtractBlinds;
    }

    private void nextPlayer()
    {
        smallBlindPlayerIndex++;
        bigBlindPlayerIndex++;

        if (smallBlindPlayerIndex > 4)
            smallBlindPlayerIndex = 0;
        if (bigBlindPlayerIndex > 4)
            bigBlindPlayerIndex = 0;
    }

    //if player is not a blind returns 0 ; if player is small blind returns 1; if player is big blind returns 2
    private int checkBlinds(GameObject player)
    {
        int playerNum = player.GetComponent<PlayerClass>().getPlayerNum();
        if (playerNum == bigBlindPlayerIndex)
            return 2;
        else if (playerNum == smallBlindPlayerIndex)
            return 1;
        else
            return 0;
    }
}