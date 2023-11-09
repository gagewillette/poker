using System;
using System.Collections.Generic;
using UnityEngine;

public class BettingLoop : MonoBehaviour
{
    public Dictionary<int, int> currentPlayerBetsByIndex = new Dictionary<int, int>();

    public static Action newBettingLoop;

    public void Awake()
    {
    }

    public void Start()
    {
        newBettingLoop += startNewLoop;
    }

    private void startNewLoop()
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