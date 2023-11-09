using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Networking.PlayerConnection;
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
    
    private void Start()
    {
        objectRefs();
        setEvents();
        setBlinds();
        subtractBlinds();
    }


    void setBlinds()
    {
        
        int totalChips = getTotalChips();
        bigBlind = totalChips / gameLogic.players.Count / 20;
        smallBlind = totalChips / gameLogic.players.Count / 30;


        foreach (GameObject cur in arraySingleton.getPlayerArrray())
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


    private void subtractBlinds()
    {
        //get player buy ins and subtract that amount
        smallBlindObj.GetComponent<PlayerClass>().playerBuyIn -= smallBlind;
        bigBlindObj.GetComponent<PlayerClass>().playerBuyIn -= bigBlind;
    }
    
    //utils
    void objectRefs()
    {
        gameLogic = GetComponent<PokerGameLogic>();
        stateManager = GetComponent<GameStateManager>();
        arraySingleton = GameObject.Find("Singletons").GetComponent<PlayerArray>();
    }

    void setEvents()
    {
        GameStateManager.onPreFlop += subtractBlinds;
        BettingLoop.newHandLoop += newHandLoop;
    }

    //set next player as blind
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

    
    //called when new pairs of cards are dealt to the players
    private void newHandLoop()
    {
        //handle all new betting loop logic here
        
        //call next player
        nextPlayer();
        //subtract blinds from their balance
        setBlinds();
        subtractBlinds();
        //start new betting loop
    }

    private int getTotalChips()
    {
        int val = 0;
        foreach (GameObject cur in arraySingleton.getPlayerArrray())
        {
            val += cur.GetComponent<PlayerClass>().playerBuyIn;
        }
 
        return val;
    }

}