using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject blackChip;
    [SerializeField] private GameObject redChip;
    [SerializeField] private GameObject blueChip;
    [SerializeField] private GameObject whiteChip;
    [SerializeField] private GameObject greenChip;

    private readonly float blackChipValue = 5;
    private readonly float blueChipValue = 10;
    private readonly float greenChipValue = 20;
    private readonly float whiteChipValue = 50;
    private readonly float redChipValue = 100;

    [SerializeField] private GameObject playerObj;
    
    private Transform[] children;

    [SerializeField] 
    private bool useChipPhysics = false;
    
    private GameObject prevSpawn;

    [SerializeField] private float totalChipCount;
    
    private void Start()
    {
        totalChipCount = playerObj.GetComponent<PlayerGameLogic>().playerBuyIn;
        
        children = getChildren(gameObject.transform);

        foreach (Transform child in children)
        {
            SpawnChips(greenChip, totalChipCount / 5, child);
        }
    }
    
    private Transform[] getChildren(Transform parent)
    {
        Transform[] children = new Transform[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i);
        }

        return children;
    }
    
    private void SpawnChips(GameObject chipSet, float chipCount, Transform trans)
    {
        for (int i = 0; i < chipCount; i++)
        {
            float bufferHeight = i * 0.007f;
            prevSpawn = Instantiate(chipSet,
                new Vector3(trans.position.x, trans.position.y + bufferHeight, trans.position.z),
                trans.rotation);
            prevSpawn.transform.SetParent(trans, true);
            Rigidbody rb = prevSpawn.GetComponent<Rigidbody>();
            rb.isKinematic = !useChipPhysics;                             
        }
    }
}