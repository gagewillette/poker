using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PokerGameLogic : MonoBehaviour
{
    private Dictionary<GameObject, Card[]> playerCards = new Dictionary<GameObject, Card[]>();
    private Card[] publicCards;

    // Start is called before the first frame update
    void Start()
    {
        createDict();
        publicCards = GameObject.Find("PublicCards").GetComponent<PublicCardSpawner>().allCards;

        PublicCardSpawner.FlopAction += onFlop;
        PublicCardSpawner.TurnAction += onTurn;
        PublicCardSpawner.RiverAction += onRiver;
    }

    private void onFlop()
    {
        filterFlopped();
        Debug.Log(playerCards.ToCommaSeparatedString());
    }

    private void onTurn()
    {
        filterFlopped();
        Debug.Log(playerCards.ToCommaSeparatedString());
    }

    private void onRiver()
    {
        filterFlopped();
        Debug.Log(playerCards.ToCommaSeparatedString());
    }

    private void filterFlopped()
    {
        foreach (var cur in playerCards)
        {
            if (cur.Key.GetComponent<PlayerGameLogic>().isPlayerFlopped)
            {
                playerCards.Remove(cur.Key);
            }
        }
    }


    private void createDict()
    {
        playerCards.Add(GameObject.Find("Player"), GameObject.Find("Player").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (1)"), GameObject.Find("Player (1)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (2)"), GameObject.Find("Player (2)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (3)"), GameObject.Find("Player (3)").GetComponent<PlayerGameLogic>().getCards());
        playerCards.Add(GameObject.Find("Player (4)"), GameObject.Find("Player (4)").GetComponent<PlayerGameLogic>().getCards());
    }
}