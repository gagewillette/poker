using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinds : MonoBehaviour
{
    // blind indicies
    private int smallBlindPlayerIndex = 0;
    private int bigBlindPlayerIndex;
    
    //reference to pokergamelogic
    private PokerGameLogic gameLogic;
    void Start()
    {
        gameLogic = gameObject.GetComponent<PokerGameLogic>();
    }
    void Update()
    {
        
    }
}
