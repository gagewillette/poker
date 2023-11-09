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
<<<<<<< HEAD
        newBettingLoop += startNewLoop;
=======
        newBettingLoop += createNewBettingLoop;
    }

    private void createNewBettingLoop()
    {
        ZeroOutDict();
>>>>>>> refs/remotes/origin/dev
    }

    private void startNewHandLoop()
    {
<<<<<<< HEAD
        ZeroOutDict();
        
        
    }

    private void startNewHandLoop()
    {
=======
        
>>>>>>> refs/remotes/origin/dev
    }

    private void ZeroOutDict()
    {
        foreach (var cur in currentPlayerBetsByIndex)
        {
            currentPlayerBetsByIndex[cur.Key] = 0;
        }
    }
    
    
}