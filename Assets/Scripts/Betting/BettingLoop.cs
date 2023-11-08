using System;
using System.Collections;
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
        newBettingLoop += createNewBettingLoop;
    }

    private void createNewBettingLoop()
    {
        ZeroOutDict();
    }

    private void startNewHandLoop()
    {
        
    }

    private void ZeroOutDict()
    {
        foreach (var cur in currentPlayerBetsByIndex)
        {
            currentPlayerBetsByIndex[cur.Key] = 0;
        }
    }
}