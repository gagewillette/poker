using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettingIndicatorManager : MonoBehaviour
{
    //arrow obj ref
    private GameObject arrow;
    
    //public get set reference
    [SerializeField]
    private bool betting;

    private void Awake()
    {
        betting = false;
        arrow = GetComponentInChildren<ArrowRef>().gameObject;
        arrow.SetActive(false);
    }

    public void Update()
    {
        if (betting)
            arrow.SetActive(true);
        else
            arrow.SetActive(false);
    }

    public void setIsBetting(bool isBetting)
    {
        betting = isBetting;
    }
}
