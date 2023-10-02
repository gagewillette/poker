using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGameLogic : MonoBehaviour
{
    public bool isPlayerFlopped;
    private UILogic uilog;
    
    // Start is called before the first frame update
    void Start()
    {
        uilog = gameObject.GetComponent<UILogic>();

        //debug player cards to console
        //Debug.Log($"{gameObject.name} cards: Card One: " + cardOne.getCardNum() + " " +  cardOne.getSuitString() + " Card 2: " + cardTwo.getCardNum() + " " + cardTwo.getSuitString());
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPlayerFlopped = true;
            uilog.isFlop = true;
        }
    }
}
