using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardDistributor : MonoBehaviour
{
    
    public static Card getCard()
    {
        int rand = Random.Range(1, CardMap.cardMap.Count + 1);

        Card card = CardMap.cardMap[rand];

        CardMap.cardMap.Remove(rand);
        
        Debug.Log(CardMap.cardMap.ToCommaSeparatedString());
        
        return card;
    }
}
