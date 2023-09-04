using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardPositions : MonoBehaviour
{
    [SerializeField] private Transform Card1Pos;
    [SerializeField] private Transform Card2Pos;
    [SerializeField] private Transform Card3Pos;
    [SerializeField] private Transform Card4Pos;
    [SerializeField] private Transform Card5Pos;

    public Transform[] cardPositions;

    private void Start()
    {
        cardPositions = new Transform[5] { Card1Pos, Card2Pos, Card3Pos, Card4Pos, Card5Pos };

        Debug.Log(cardPositions.ToCommaSeparatedString());
    }
}