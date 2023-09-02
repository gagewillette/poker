using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    private string texturePath = "/Assets/Playing Cards/Image/PlayingCards/BackColor_Black.png";
    private Card[] playerCards;
    private PlayerGameLogic logic;
    private RawImage cardOneImg;
    private RawImage cardTwoImg;

    [SerializeField]
    private GameObject playerCapsule;
    private Renderer capsuleRend;
    
    // will be true if player wants to flop
    public bool isFlop = false;
    
    private void Start()
    {
        capsuleRend = playerCapsule.GetComponent<Renderer>();
        
        RawImage[] imgComps = gameObject.GetComponentsInChildren<RawImage>();
        Debug.Log(imgComps.ToCommaSeparatedString());
        cardOneImg = imgComps[1];
        cardTwoImg = imgComps[0];
        
        logic = gameObject.GetComponent<PlayerGameLogic>();
        
        playerCards = logic.playerCards;

        string c1Sub = $"{playerCards[0].getSuitString()}{playerCards[0].getNumString()}";
        string c2Sub = $"{playerCards[1].getSuitString()}{playerCards[1].getNumString()}";
        
        Debug.Log(c1Sub + "  " + c2Sub);
        Debug.Log($"{texturePath}/{c1Sub}.png");
        
        cardOneImg.texture = Resources.Load<Texture>($"{c1Sub}");
        cardTwoImg.texture = Resources.Load<Texture>($"{c2Sub}");
    }

    private void Update()
    {
        if (isFlop)
        {
            cardOneImg.texture = Resources.Load<Texture>($"BackColor_Black");
            cardTwoImg.texture = Resources.Load<Texture>($"BackColor_Black");
            
            //render player as gray so other players know
            capsuleRend.material.SetColor("Gray", Color.gray);
            
            isFlop = false;
        }
    }
}
