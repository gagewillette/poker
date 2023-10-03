using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DebugScreen : MonoBehaviour
{
    [SerializeField] private bool showDebugScreen = false;


    private PlayerLook look;

    public TMP_Text fpsCounter;
    public TMP_Text outlineShaderFrameCounter;
    public TMP_Text gameState;

    private void Awake()
    {
        look = gameObject.transform.parent.GetComponentInChildren<PlayerLook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            showDebugScreen = !showDebugScreen;
        if (!showDebugScreen)
        {
            fpsCounter.text = "";
            outlineShaderFrameCounter.text = "";
            gameState.text = "";
            return;
        }

        fpsCounter.text = "fps: " + getFPS().ToString();
        outlineShaderFrameCounter.text = "outlineshader.framedelay: " + getOutlineShaderText().ToString();
        gameState.text = getGameState();

    }

    //calculate fps from time class
    private float getFPS(){ return Time.frameCount / Time.time; }
    //get frame delay from look script
    private float getOutlineShaderText(){ return look.frameDelay; }

    private string getGameState()
    {
        return GameObject.Find("GameLogic").GetComponent<PokerGameLogic>().currentState.ToString();
    }


}
