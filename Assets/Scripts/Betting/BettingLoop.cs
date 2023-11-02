using System;
using System.Collections;
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
        newBettingLoop += createNewLoop;
    }

    private void createNewLoop()
    {
        ZeroOutDict();
    }

    private void startNewLoop()
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