using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BettingIndicatorManager : MonoBehaviour
{
    //arrow obj ref
    private GameObject arrow;

    //public get set reference
    [SerializeField] private bool betting;

    private bool prevBetting;

    //player array
    private GameObject[] playerTags;


    private void Awake()
    {
        betting = false;
        arrow = GetComponentInChildren<ArrowRef>().gameObject;
        arrow.SetActive(false);

        playerTags = GameObject.FindGameObjectsWithTag("Player");
    }

    public void Update()
    {
        if (prevBetting != betting)
        {
            if (betting)
            {
                arrow.SetActive(true);
                removeExtraIndicators();
            }
            else
            {
                arrow.SetActive(false);
            }
        }

        prevBetting = betting;
    }

    public void setIsBetting(bool isBetting)
    {
        betting = isBetting;
    }

    public bool getIsBetting()
    {
        return betting;
    }

    public void removeExtraIndicators()
    {
        foreach (var cur in playerTags)
        {
            BettingIndicatorManager curManager = cur.gameObject.GetComponent<BettingIndicatorManager>();

            if (curManager != this && curManager.getIsBetting())
            {
                curManager.setIsBetting(false);
            }
        }
    }
}