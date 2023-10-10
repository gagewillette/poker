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
    public int bigBlind;
    public int smallBlind;

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
    }


    private void SubtractBlinds()
    {
        GameObject smallBlind, bigBlind;
        foreach (GameObject cur in playerArray)
        {
                        
        }
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
        stateManager.onPreFlop += SubtractBlinds;
    }

    private void nextPlayer()
    {
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