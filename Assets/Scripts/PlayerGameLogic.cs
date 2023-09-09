using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGameLogic : MonoBehaviour
{
    private static Card cardOne;
    private static Card cardTwo;
    public Card[] playerCards = new Card[2];

    public bool isPlayerFlopped;
    
    [SerializeField]
    private float playerChipBalance = 10000;

    public float playerBuyIn = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        cardOne = CardDistributor.getCard();
        cardTwo = CardDistributor.getCard();
        playerCards[0] = cardOne;
        playerCards[1] = cardTwo;

        //debug player cards to console
        //Debug.Log($"{gameObject.name} cards: Card One: " + cardOne.getCardNum() + " " +  cardOne.getSuitString() + " Card 2: " + cardTwo.getCardNum() + " " + cardTwo.getSuitString());
    }

    public Card[] getCards() { return playerCards; }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
