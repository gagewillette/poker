using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerArray : MonoBehaviour
{
    public static PlayerArray Instance; // Singleton Instance

    public Dictionary<GameObject, Card[]> playerCardsDict = new Dictionary<GameObject, Card[]>();

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            createDict();
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

    private void createDict()
    {
        List<GameObject> players = GameObject.FindGameObjectsWithTag("Player").ToList();
        foreach (GameObject cur in players)
        {
            playerCardsDict.Add(cur, cur.GetComponent<PlayerClass>().getCards());
        }
    }
}