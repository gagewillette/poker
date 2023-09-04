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

    public List<Transform> cardPositions;

    private void Start()
    {
        cardPositions.Add(Card1Pos);
        cardPositions.Add(Card2Pos);
        cardPositions.Add(Card3Pos);
        cardPositions.Add(Card4Pos);
        cardPositions.Add(Card5Pos);
    }
}

