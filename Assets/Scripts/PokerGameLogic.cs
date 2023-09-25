using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PokerGameLogic : MonoBehaviour
{
    private Dictionary<GameObject, Card[]> playerCards = new Dictionary<GameObject, Card[]>();
    private Card[] publicCards;

    private GameObject winner;

    public static Action onNewPubilcCard;
    
    // can be 1 - 10 (Royal Flush, Straight Flush, Four of a Kind, Full House, Flush, Straight, Three of A Kind, Two Pair, Pair, High Card, NOTHING) [<- In order 1 - 11]
    Dictionary<GameObject, int> playerHandValue = new Dictionary<GameObject, int>();

    // Start is called before the first frame update
    void Start()
    {
        createDict();
        publicCards = GameObject.Find("PublicCards").GetComponent<PublicCardSpawner>().allCards;
    
        Debug.Log("Public cards: " + publicCards.ToCommaSeparatedString());
        
        onNewPubilcCard += FilterFlopped;

        PublicCardSpawner.FlopAction += onFlop;
        PublicCardSpawner.TurnAction += onTurn;
        PublicCardSpawner.RiverAction += onRiver;
    }

    private void onFlop()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCards.ToCommaSeparatedString());
    }

    private void onTurn()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCards.ToCommaSeparatedString());
    }

    private void onRiver()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCards.ToCommaSeparatedString());
        Debug.Log(publicCards.ToCommaSeparatedString());
        //winner = determineWinner(playerCards, publicCards);
    }
    
    private GameObject determineWinner(Dictionary<GameObject, Card[]> playerCards, Card[] publicCards)
    {
        GameObject currentWinner = new GameObject();
        int currentWinnerHandRank = 11;
        
        foreach (var cur in playerCards)
        {
            int temp = gameObject.GetComponent<HandTests>().checkHand(cur.Value, publicCards);

            if (temp < currentWinnerHandRank)
                currentWinner = cur.Key;
        }
        
        Debug.Log(currentWinner.gameObject.name);
        
        return currentWinner;
    } 


    private void FilterFlopped()
    {
        List<GameObject> keysToRemove = new List<GameObject>();

        foreach (var cur in playerCards)
        {
            if (cur.Key.GetComponent<PlayerGameLogic>().isPlayerFlopped)
            {
                keysToRemove.Add(cur.Key);
            }
        }

        foreach (var cur in keysToRemove)
        {
            playerCards.Remove(cur);
        }
    }


    private void createDict()
    {
        playerCards.Add(GameObject.Find("Player"),
            GameObject.Find("Player").GetComponent<PlayerClass>().getCards());
        playerCards.Add(GameObject.Find("Player (1)"),
            GameObject.Find("Player (1)").GetComponent<PlayerClass>().getCards());
        playerCards.Add(GameObject.Find("Player (2)"),
            GameObject.Find("Player (2)").GetComponent<PlayerClass>().getCards());
        playerCards.Add(GameObject.Find("Player (3)"),
            GameObject.Find("Player (3)").GetComponent<PlayerClass>().getCards());
        playerCards.Add(GameObject.Find("Player (4)"),
            GameObject.Find("Player (4)").GetComponent<PlayerClass>().getCards());
    }
}