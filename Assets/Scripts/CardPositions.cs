using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositions : MonoBehaviour
{
    [SerializeField]
    private Transform Card1Pos;
    [SerializeField]
    private Transform Card2Pos;
    [SerializeField]
    private Transform Card3Pos;
    [SerializeField]
    private Transform Card4Pos;
    [SerializeField]
    private Transform Card5Pos;

    public Transform[] cardPositions;
    
    private void Start()
    {
        Destroy(Card1Pos.gameObject);
        Destroy(Card2Pos.gameObject);
        Destroy(Card3Pos.gameObject);
        Destroy(Card4Pos.gameObject);
        Destroy(Card5Pos.gameObject);

        cardPositions[0] = Card1Pos;
        cardPositions[1] = Card2Pos;
        cardPositions[2] = Card3Pos;
        cardPositions[3] = Card4Pos;
        cardPositions[4] = Card5Pos;
    }
}

