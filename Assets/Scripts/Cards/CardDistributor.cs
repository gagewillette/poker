using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardDistributor : MonoBehaviour
{  
    public static Card getCard()
    {
        while (true)
        {
            try
            {
                int rand = Random.Range(1, CardMap.cardMap.Count + 1);

                Card card = CardMap.cardMap[rand];

                CardMap.cardMap.Remove(rand);
                
                return card;
                
            } catch (Exception e) {Debug.Log(e.Message + "   !!TRYING AGAIN!!");}
        }
        
    }
}
