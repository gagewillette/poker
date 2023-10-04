using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PokerGameLogic : MonoBehaviour
{

    private Card[] publicCards;
    private GameObject winner;

    public static Action onNewPubilcCard;
    public static Action onPreFlop;
        
    // TODO: figure out what the fuck to do with this
    // can be 1 - 10 (Royal Flush, Straight Flush, Four of a Kind, Full House, Flush, Straight, Three of A Kind, Two Pair, Pair, High Card, NOTHING) [<- In order 1 - 11]
    Dictionary<GameObject, int> playerHandValue = new Dictionary<GameObject, int>();

    //dictionaries
    public List<GameObject> players;
    private Dictionary<GameObject, Card[]> playerCardsDict;
    
    public enum GameState
    {
        Preflop,
        Flop,
        Turn,
        River,
        Showdown,
        GameOver
    }
    

    public int currentPlayerIndex = 0;
    public GameState currentState;

    void Start()
    {
        //THIS WILL BREAK THIS WILL BREAK THIS WILL BREAK
        playerCardsDict = GameObject.Find("Player (1)").GetComponent<PlayerClass>().getPlayerCardDict();
        currentState = GameState.Preflop;
        publicCards = GameObject.Find("PublicCards").GetComponent<PublicCardSpawner>().allCards;
        players = playerCardsDict.Keys.ToList();
        Debug.Log("Public cards: " + publicCards.ToCommaSeparatedString());
            
        onNewPubilcCard += FilterFlopped;

        PublicCardSpawner.FlopAction += onFlop;
        PublicCardSpawner.TurnAction += onTurn;
        PublicCardSpawner.RiverAction += onRiver;
    }


    private void Update()
    {
        switch (currentState)
        {
            case GameState.Preflop:
                // Handle preflop actions (e.g., blinds, player bets)
                onPreFlop?.Invoke();
                break;

            case GameState.Flop:
                // Handle flop actions (deal community cards, player bets)
                break;

            case GameState.Turn:
                // Handle turn actions (deal another community card, player bets)
                break;

            case GameState.River:
                // Handle river actions (deal the final community card, player bets)
                break;

            case GameState.Showdown:
                // Determine the winner(s) and distribute the pot
                break;

            case GameState.GameOver:
                // Handle game over conditions
                break;
        }
    }

    private void onFlop()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCardsDict.ToCommaSeparatedString());
    }

    private void onTurn()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCardsDict.ToCommaSeparatedString());
    }

    private void onRiver()
    {
        FilterFlopped();
        onNewPubilcCard?.Invoke();
        Debug.Log(playerCardsDict.ToCommaSeparatedString());
        Debug.Log(publicCards.ToCommaSeparatedString());
        winner = determineWinner(playerCardsDict, publicCards);
    }
    
    private GameObject determineWinner(Dictionary<GameObject, Card[]> playerCardsDict, Card[] publicCards)
    {
        GameObject currentWinner = new GameObject();
        int currentWinnerHandRank = 11;
        
        foreach (var cur in playerCardsDict)
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

        foreach (var cur in playerCardsDict)
        {
            if (cur.Key.GetComponent<PlayerGameLogic>().isPlayerFlopped)
            {
                keysToRemove.Add(cur.Key);
            }
        }

        foreach (var cur in keysToRemove)
        {
            playerCardsDict.Remove(cur);
        }
    }


 

    private void nextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
    }

}