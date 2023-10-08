using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        gameLogic = gameObject.GetComponent<PokerGameLogic>();
        setBlinds();
    }
    
    

    void setBlinds()
    {
        int totalChips = 0;
        foreach (GameObject cur in gameLogic.players)
        {
            totalChips += cur.GetComponent<PlayerClass>().playerBuyIn;
        }
        
        bigBlind = totalChips / gameLogic.players.Count / 20;
        smallBlind = totalChips / gameLogic.players.Count / 30;
    }
}