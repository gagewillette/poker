using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    private string texturePath = "Assets/Playing Cards/Image/PlayingCards";
    private string[] texturePathSubstring = new string[2];
    private Card[] playerCards;
    private PlayerGameLogic logic;
    private RawImage cardOneImg;
    private RawImage cardTwoImg;
    
    
    private void Start()
    {
        RawImage[] imgComps = gameObject.GetComponentsInChildren<RawImage>();
        cardOneImg = imgComps[1];
        cardTwoImg = imgComps[0];
        
        logic = gameObject.GetComponent<PlayerGameLogic>();
        
        playerCards = logic.playerCards;

        string c1Sub = $"{playerCards[0].getSuitString()}{playerCards[0].getNumString()}";
        string c2Sub = $"{playerCards[1].getSuitString()}{playerCards[1].getNumString()}";
        
        Debug.Log(c1Sub + "  " + c2Sub);
        Debug.Log($"{texturePath}/{c1Sub}.png");
        
        cardOneImg.texture = Resources.Load<Texture2D>($"{texturePath}/{c1Sub}.png");
    }
}
