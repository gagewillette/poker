using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadCam : MonoBehaviour
{
    private Camera playerCam;
    private Camera overHead;

    private void Start()
    {
        playerCam = gameObject.GetComponentInChildren<Camera>();
        overHead = GameObject.Find("OverheadCamera").GetComponent<Camera>();
        
        playerCam.enabled = true;
        overHead.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerCam.enabled = false;
            overHead.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerCam.enabled = true;
            overHead.enabled = false;
        }
    }
    
}
