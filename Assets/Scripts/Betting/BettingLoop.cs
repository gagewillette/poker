using System;
using System.Collections.Generic;
using UnityEngine;

public class BettingLoop : MonoBehaviour
{
    public Dictionary<int, int> currentPlayerBetsByIndex = new Dictionary<int, int>();

    public static Action newBettingLoop;
    public static Action newHandLoop;

    public void Awake()
    {
    }

    public void Start()
    {
        newBettingLoop += startNewHandLoop;

        newBettingLoop += createNewBettingLoop;
    }

    private void createNewBettingLoop()
    {
        //called to start loop whenever players are to bet (raise, call, all in, etc.)
        
        ZeroOutDict();
    }
    private void startNewHandLoop()
    {
        //called when new cards need to be dealt
        
    }

    private void ZeroOutDict()
    {
        foreach (var cur in currentPlayerBetsByIndex)
        {
            currentPlayerBetsByIndex[cur.Key] = 0;
        }
    }
}