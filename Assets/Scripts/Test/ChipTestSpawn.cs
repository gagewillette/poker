using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ChipTestSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject blackChip;
    private float frameCounter = 0;
    
    // i could use this as an api
    //basically spawning each chip on top of each other using a height buffer
    //the frame counter is important for this as it determines the heigher buffer
    //on each iteration of the loop
    
    // SpawnChips(GameObject chipSet, int chipCount, Vector3 position)
    // SpawnChips(GameObject chipSet, int chipCount, Transform trans)
    
    
    private void Start()
    {
        
        
        while (frameCounter < 10)
        {
            float bufferHeight = frameCounter * 0.007f;
            GameObject prevSpawn = Instantiate(blackChip,
                new Vector3(transform.position.x, transform.position.y + bufferHeight, transform.position.z),
                transform.rotation);
            prevSpawn.transform.SetParent(gameObject.transform, true);
            
            frameCounter++;
        }
    }
}
