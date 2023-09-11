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

    // Start is called before the first frame update
    void Start()
    {
        createDict();
        publicCards = GameObject.Find("PublicCards").GetComponent<PublicCardSpawner>().allCards;

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
        winner = determineWinner(playerCards, publicCards);
    }

    public GameObject getWinner()
    {
        return winner;
    }


    private GameObject determineWinner(Dictionary<GameObject, Card[]> playerCards, Card[] publicCards)
    {
        GameObject bestPlayer = null;
        GameObject bestHand = null;

        foreach (var cur in playerCards)
        {
            
            
            
        }
        
        
        return new GameObject();
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
            GameObject.Find("Player").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (1)"),
            GameObject.Find("Player (1)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (2)"),
            GameObject.Find("Player (2)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (3)"),
            GameObject.Find("Player (3)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (4)"),
            GameObject.Find("Player (4)").GetComponent<PlayerGameLogic>().getCards());
    }
}