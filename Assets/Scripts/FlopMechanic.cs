using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlopMechanic : MonoBehaviour
{
    private UILogic uilog;
    private PlayerGameLogic playerLog;
    
    void Start()
    {
        uilog = gameObject.GetComponent<UILogic>();
        playerLog = gameObject.GetComponent<PlayerGameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerLog.isPlayerFlopped = true;
            uilog.isFlop = true;
        }
    }
}
