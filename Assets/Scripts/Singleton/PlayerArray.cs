using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerArray : MonoBehaviour
{
    public static PlayerArray Instance; // Singleton Instance

    private Dictionary<GameObject, Card[]> playerCardsDict = new Dictionary<GameObject, Card[]>();
    private GameObject[] playerArray;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            createDict();
            createArray();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<GameObject, Card[]> getPlayerCardDict()
    {
        return playerCardsDict;
    }

    public GameObject[] getPlayerArrray()
    {
        return playerArray;
    }

    private void createDict()
    {
        List<GameObject> players = GameObject.FindGameObjectsWithTag("Player").ToList();
        foreach (GameObject cur in players)
        {
            playerCardsDict.Add(cur, cur.GetComponent<PlayerClass>().getCards());
        }
    }

    private void createArray()
    {
        playerArray = playerCardsDict.Keys.ToArray();
    }
}