using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlopMechanic : MonoBehaviour
{
    private UILogic uilog;
    
    
    void Start()
    {
        uilog = gameObject.GetComponent<UILogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            uilog.isFlop = true;
            
        }
    }
}
