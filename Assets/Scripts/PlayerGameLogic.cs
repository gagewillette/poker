using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGameLogic : MonoBehaviour
{
    private static Card cardOne;
    private static Card cardTwo;
    public Card[] playerCards = { cardOne, cardTwo };
    
    
    // Start is called before the first frame update
    void Start()
    {
        cardOne = CardDistributor.getCard();
        cardTwo = CardDistributor.getCard();
        
        Debug.Log("Player cards: " + playerCards.ToCommaSeparatedString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
