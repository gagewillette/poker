using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PublicCardSpawner : MonoBehaviour
{
    private Card[] flop = new Card[3];
    private Card turn;
    private Card river;

    private List<Transform> cardLocations;

    private GameObject[] cardPrefabs = new GameObject[5];

    private string path = "Prefab/Black_PlayingCards_";
    private string endPath = "_00.prefab";
    
    
    //TEST VARIABLES
    public bool isFlop = false;
    public bool isTurn = false;
    public bool isRiver= false;
    //END TEST VARIABLES
    
    
    void Start()
    {

        cardLocations  = GameObject.Find("PublicCards").GetComponent<CardPositions>().cardPositions;
        
        int i = 0;
        foreach (var cur in flop)
        {
            flop[i] = CardDistributor.getCard();
            i++;
        }

        turn = CardDistributor.getCard();
        river = CardDistributor.getCard();

        cardPrefabs = getCardPrefabs();
        
        //DEBUG
        foreach (var cur in flop)
        {
            Debug.Log(cur.getSuit() + " " + cur.getCardNum());
        }
        Debug.Log(turn.getSuit() + " " + turn.getCardNum());
        Debug.Log(river.getSuit() + " " + river.getCardNum());
        //END DEBUG
        ;        
        Debug.Log(cardPrefabs.ToCommaSeparatedString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isFlop = true; 
            for (int i = 0; i < 3; i++)
            {
                GameObject prevSpawn = Instantiate(cardPrefabs[i], cardLocations[i].position, cardLocations[i].rotation);
            }
        }

    }

    private GameObject[] getCardPrefabs()
    {
        GameObject[] arr = new GameObject[5];
        int i = 0;
        foreach (var cur in cardPrefabs)
        {
            arr[i] = Resources.Load<GameObject>(path + flop[i].getSuitString() + flop[i].getNumString() + endPath);
            i++;
        }

        return arr;
    }

}
