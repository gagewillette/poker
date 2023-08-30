using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMap : MonoBehaviour
{
    [SerializeField] public static Dictionary<int, Card> cardMap = new Dictionary<int, Card>();
    
    private void Start()
    {
        for (int s = 0; s < 4; s++)
        {
            for (int i = 1; i < 14; i++)
            {   
                Card card = new Card()
            }
        }
    }
}
