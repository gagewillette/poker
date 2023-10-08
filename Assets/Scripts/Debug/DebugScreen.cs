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

    //script references
    private Blinds blindsRef;
    private PlayerLook look;

    //mofuckin texts
    public TMP_Text fpsCounter;
    public TMP_Text outlineShaderFrameCounter;
    public TMP_Text gameState;
    public TMP_Text blinds;

    
    private void Awake()
    {
        look = gameObject.transform.parent.GetComponentInChildren<PlayerLook>();
        blindsRef = GameObject.Find("GameLogic").GetComponent<Blinds>();
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
            blinds.text = "";
            return;
        }

        fpsCounter.text = "fps: " + getFPS().ToString();
        outlineShaderFrameCounter.text = "outlineshader.framedelay: " + getOutlineShaderText().ToString();
        gameState.text = getGameState();
        blinds.text = getBlinds();
    }

    //calculate fps from time class
    private float getFPS(){ return Time.frameCount / Time.time; }
    //get frame delay from look script
    private float getOutlineShaderText(){ return look.frameDelay; }

    private string getGameState()
    {
        return GameObject.Find("GameLogic").GetComponent<GameStateManager>().currentState.ToString();
    }

    private string getBlinds()
    {
        return String.Format("Blinds: Small-{0} Big-{1}", blindsRef.smallBlind, blindsRef.bigBlind);
    }


}
